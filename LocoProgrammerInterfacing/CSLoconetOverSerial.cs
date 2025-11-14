/*
"Commons Clause" License Condition v1.0

The Software is provided to you by the Licensor under the License, as defined below, subject to the following condition.

Without limiting other conditions in the License, the grant of rights under the License will not include, and the License does not grant to you, the right to Sell the Software.

For purposes of the foregoing, "Sell" means practicing any or all of the rights granted to you under the License to provide to third parties,
for a fee or other consideration (including without limitation fees for hosting or consulting/ support services related to the Software),
a product or service whose value derives, entirely or substantially, from the functionality of the Software.
Any license notice or attribution required by the License must also include this Commons Clause License Condition notice.

Software: LocoConnect
License: GPLv3
Licensor: Roeland Kluit

Copyright (C) 2024 Roeland Kluit - v0.6 Februari 2024 - All rights reserved -

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

The Software is provided to you by the Licensor under the License,
as defined, subject to the following condition.

Without limiting other conditions in the License, the grant of rights
under the License will not include, and the License does not grant to
you, the right to Sell the Software.

For purposes of the foregoing, "Sell" means practicing any or all of
the rights granted to you under the License to provide to third
parties, for a fee or other consideration (including without
limitation fees for hosting or consulting/ support services related
to the Software), a product or service whose value derives, entirely
or substantially, from the functionality of the Software.
Any license notice or attribution required by the License must also
include this Commons Clause License Condition notice.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Control = System.Windows.Forms.Control;
using Kluitnet.ComPort.SafeSerialPortModule;

namespace LocoProgrammerInterfacing
{
    public class SerialPortLoconetCommunication : LoconetComsLayer
    {
        private Timer tmr_recieve;
        private Timer tmr_process;
        private string _ComPort = "COM10";
        private Int32 _boudrate = 19200;
        private SafeSerialPort _port;
        private Queue<byte[]> dataToSend = new Queue<byte[]>();
        private byte[] bufferData = new byte[2048];
        private int bufferPos = 0;
        private bool _DoNotUseHandshake = false;

        public SerialPortLoconetCommunication(string ComPortName, Int32 Boudrate = 19200, bool bDoNotUseHandshake = false, Control Owner = null): base(Owner)
        {
            _DoNotUseHandshake = bDoNotUseHandshake;
            _ComPort = ComPortName;
            _boudrate = Boudrate;
            tmr_recieve = new Timer();
            tmr_recieve.Elapsed += tmrSerialInputProcessing;
            tmr_recieve.Enabled = false;
            tmr_recieve.Interval = 10;
            tmr_process = new Timer();
            tmr_process.Elapsed += tmrProcessIncomingPackets;
            tmr_process.Interval = 5;
            tmr_process.Enabled = false;
        }

        private void tmrProcessIncomingPackets(object sender, ElapsedEventArgs e)
        {
            byte[] newMsg = null;
            lock (bufferData)
            {
                int FrameLen = LoconetFrame.GetLengthFromLNHeader(ref bufferData);
                if (FrameLen == 0)
                {
                    //Console.WriteLine("Not Complete");
                }
                else if (FrameLen == -1)
                {
                    //Console.WriteLine("FrameLen error, throw away byte");
                    Array.Copy(bufferData, 1, bufferData, 0, bufferPos);
                    bufferPos -= 1;
                }
                else
                {
                    //Ensure we have all the data
                    if (FrameLen <= bufferPos)
                    {
                        newMsg = new byte[FrameLen];
                        Array.Copy(bufferData, newMsg, FrameLen);
                        bufferPos -= FrameLen;
                        Array.Copy(bufferData, FrameLen, bufferData, 0, bufferPos);
                        if (bufferPos == 0)
                        {
                            tmr_process.Enabled = false;
                        }
                    }
                }
            }
            if (newMsg != null)
            {
                try
                {
                    LoconetFrame loconetFrame = LoconetFrame.fromArray(newMsg);
                    OnLoconetFrameRecieved(loconetFrame);
                }
                catch(Exception es)
                {
                    Console.WriteLine("Cannot parse LoconetFrame: [" + BitConverter.ToString(newMsg) + "]" + es) ;
                }
            }
        }

        private void AddToBuffer(byte[] data, int datalen)
        {
            lock (bufferData)
            {
                if(bufferPos +datalen > bufferData.Length)
                {
                    bufferPos = 0;
                }
                Array.Copy(data, 0, bufferData, bufferPos, datalen);
                bufferPos += datalen;
            }
        }

        public override bool Connected
        {
            get
            {
                return _port.SafeIsOpen;
            }
        }

        private void tmrSerialInputProcessing(object sender, ElapsedEventArgs e)
        {
            tmr_recieve.Enabled = false;
            try
            {
                if (_port == null)
                {
                    Connect();
                }
                else
                {
                    CheckForData();
                }
            }
            finally
            {
                tmr_recieve.Enabled = true;
            }
        }

        public override void Send(LoconetFrame data)
        {
            try
            {
                if (!Connected)
                {
                    base.OnLoconetConnectionClosed();
                    throw new EndOfStreamException("Not connected");
                }
                byte[] datafrm = data.GetBytes();            
                dataToSend.Enqueue(datafrm);
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(null, "Error sending Loconet Serial frame " + e.ToString(), "Loconet Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Disconnect();
            }
        }

        private void CheckForData()
        {
            if (_port.SafeIsOpen)
            {
                byte[] data = new byte[64];

                if (_port.BytesToRead != 0)
                {
                    tmr_process.Enabled = false;
                    while (_port.BytesToRead > 0)
                    {
                        int packetlen = _port.Read(data, 0, data.Length);
                        AddToBuffer(data, packetlen);
                    }
                    tmr_process.Enabled = true;
                }
                else
                {
                    if (dataToSend.Count > 0)
                    {
                        if (_port.CtsHolding || _DoNotUseHandshake)
                        {
                            byte[] packet = dataToSend.Dequeue();
                            //Console.WriteLine("send: " + BitConverter.ToString(packet));

                            foreach (byte b in packet)
                            {
                                _port.Write(new byte[] { b }, 0, 1);
                            }
                        }
                    }
                }
            }
        }

        public override void Disconnect()
        {
            try
            {
                OnLoconetConnectionClosed();
            }
            catch { }
            try
            {
                tmr_process.Enabled = false;
                tmr_recieve.Enabled = false;
                if (_port != null)
                {
                    _port.Close();
                    _port.Dispose();
                }
            }
            finally
            {
                _port = null;
            }
        }

        public override void Dispose()
        {
            Disconnect();
            base.Dispose();
        }

        public override void Connect()
        {
            try
            {
                _port = new SafeSerialPort(_ComPort, _boudrate);
                if (!_port.SafeIsOpen)
                {
                    _port.RtsEnable = true;
                    _port.ReadTimeout = 500;
                    _port.WriteTimeout = 500;
                    _port.StopBits = StopBits.One;
                    _port.DataBits = 8;
                    _port.Parity = Parity.None;
                    if (_DoNotUseHandshake)
                    {
                        _port.Handshake = Handshake.None;                        
                    }
                    else
                    {
                        _port.Handshake = Handshake.RequestToSend;
                    }
                    _port.Open();
                    Console.WriteLine("OpenSucces: " + _ComPort);
                    tmr_recieve.Enabled = true;
                }
                else
                {
                    throw new Exception("Serial Port Open Error on port " + _ComPort);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
