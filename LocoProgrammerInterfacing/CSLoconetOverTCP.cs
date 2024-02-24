#pragma warning disable 1587
/** ****************************************************************************
 * @file      MessageReceivedEventArgs.cs
 * @author    Martin Pischky
 * @author    Stefan Bormann
 * @version   \$Id: LoconetOverTcpClient.cs 1073 2020-07-26 05:15:54Z pischky $
 * @copyright Copyright &copy; 2020 by Martin Pischky and Stefan Bormann. All rights reserved.
 **************************************************************************** */
#pragma warning restore

using LocoProgrammerInterfacing;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace net.sf.loconetovertcp
{
    /// <summary>
    /// Enumeration used to classify messages send by LoconetOverTcp server 
    /// or clients.
    /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
    /// </summary>
    [Flags]
    public enum MessageType
    {
        /// <summary>
        /// No messages at all. May be used by filters.
        /// </summary>
        NONE = 0x00,

        /// <summary>
        /// Message type is known. May be protocol error.
        /// </summary>
        UNKNOWN = 0x01,

        /// <summary>
        /// Message starts with "VERSION".
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        VERSION = 0x02,

        /// <summary>
        /// Message starts with "RECEIVE".
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        RECEIVE = 0x04,

        /// <summary>
        /// Message starts with "SEND".
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        SEND = 0x08,

        /// <summary>
        /// Message starts with "SENT". 
        /// This includes "SENT OK", "SENT ERROR".
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        SENT = 0x10,

        /// <summary>
        /// Message starts with "TIMESTAMP".
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        TIMESTAMP = 0x20,

        /// <summary>
        /// Message starts with "BREAK".
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        BREAK = 0x40,

        /// <summary>
        /// Message starts with "ERROR". 
        /// This includes "ERROR MESSAGE", "ERROR LINE", "ERROR CHECKSUM"
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        ERROR = 0x80, // including "ERROR MESSAGE", "ERROR LINE", "ERROR CHECKSUM"

        /// <summary>
        /// All messages. be used by filters.
        /// See <a href="http://loconetovertcp.sourceforge.net/Protocol/LoconetOverTcp.html">Protocol: LoconetOverTcp</a>
        /// </summary>
        ALL = UNKNOWN | VERSION | RECEIVE | SEND | SENT
                    | TIMESTAMP | BREAK,
    }
}

namespace net.sf.loconetovertcp
{
    /// <summary>
    /// Holds the Arguments for a MessageReceivedEvent.
    /// </summary>
    public class MessageReceivedEventArgs
    {
        public static readonly string SVN_ID = "$Id: MessageReceivedEventArgs.cs 1064 2020-07-24 10:47:36Z pischky $";

        /// <summary>
        /// Value for no Timpstamp recevied.
        /// </summary>
        public const Int64 NO_TIMESTAMP = -1L;

        private String messageString = "";
        private MessageType type = MessageType.NONE;
        private Int64 timestamp = NO_TIMESTAMP;

        public MessageReceivedEventArgs(MessageType type, String messageString, Int64 timestamp)
        {
            if (messageString != null)
            {
                this.messageString = messageString;
            }
            this.type = type;
            this.timestamp = timestamp;
        }

        public MessageReceivedEventArgs(MessageType messageType, String messageString) : this(messageType, messageString, NO_TIMESTAMP)
        {
        }

        public MessageType Type
        {
            get
            {
                return type;
            }
        }

        public String MessageString
        {
            get
            {
                return messageString;
            }
        }

        public Int64 Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        public override string ToString()
        {
            return "MessageReceivedEventArgs(" + this.Type + ", \"" + this.MessageString + "\", " + this.Timestamp + ")";
        }

    }
    //public delegate void MessageReceivedEventHandler(object source, MessageReceivedEventArgs e);

    public class LoconetOverTcpClient : LoconetComsLayer
    {        
        public const Int64 NO_TIMESTAMP = -1L;
        private Thread receiveThread = null;
        private bool running = false;
        private NetworkStream stream = null;
        private StreamReader streamReader = null;
        private StreamWriter streamWriter = null;
        private TcpClient tcpClient;
        private MessageType filter = MessageType.ALL;
        public string ServerVersion { get; private set; }
        private Int64 lastTimestamp = NO_TIMESTAMP;
        private string Server = "";
        private UInt16 Port = 5550;

        public LoconetOverTcpClient(String Server, UInt16 Port, Control owner = null):base(owner)
        {
            this.Server = Server;
            this.Port = Port;
        }

        public override void Connect()
        {
            if (tcpClient == null)
            {
                try
                {
                    tcpClient = new TcpClient();                    
                    tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 10000);
                    tcpClient.Connect(Server, Port);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            if (stream == null)
            {
                stream = this.tcpClient.GetStream();
                streamWriter = new StreamWriter(stream, Encoding.ASCII);
                streamReader = new StreamReader(stream, Encoding.ASCII);
                receiveThread = new Thread(runThread);
                running = true;
                receiveThread.Start();
            }
        }

        public override void Disconnect()
        {
            lock (this)
            {
                running = false;
                if (streamReader != null) streamReader.Close();
                if (streamWriter != null) streamWriter.Close();
                if (stream != null) stream.Close();
                streamReader = null;
                streamWriter = null;
                stream = null;

                if (receiveThread != null)
                {
                    if (receiveThread.IsAlive)
                    {
                        //receiveThread.Abort();
                        receiveThread.Join(); //TODO should we add timeout ? Yes we should
                        receiveThread = null;
                    }
                }
            }
        }

        public override bool Connected
        {
            get
            {
                if (tcpClient == null)
                    return false;
                return tcpClient.Connected;
            }
        }

        public override void Send(LoconetFrame data)
        {
            try
            {
                if (!Connected)
                    throw new EndOfStreamException("Not connected");
                string message = data.ToHexString();
                streamWriter.WriteLine("SEND " + message);
                streamWriter.Flush();
            }
            catch(Exception e)
            {
                MessageBox.Show(null, "Error sending Loconet TCP frame " + e.ToString(), "Loconet Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fireMessageReceived(MessageReceivedEventArgs args)
        {
            /*
            Control owner = base.owner;
            if (owner != null && owner.InvokeRequired)
            {
                //lock (MessageReceived) //fails on empty receiver list
                {
                    if (MessageReceived != null)
                    {
                        //FIXME ganz ganz schlecht vom fehlerhandling
                        owner.Invoke(MessageReceived,
                                     new object[] { this, args });
                    }
                }
            }
            else
            {
                {
                    if (MessageReceived != null) MessageReceived(this, args);
                }
            }*/
        }

        private void runThread()
        {
            try
            {
                lastTimestamp = NO_TIMESTAMP;
                String line = null;
                while (running)
                {
                    try
                    {
                        line = streamReader.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException is SocketException)
                        {
                            SocketException socEx = ex.InnerException as SocketException;
                            if (socEx.SocketErrorCode == SocketError.TimedOut)
                            {
                                // socEx.ErrorCode == 10060 // WSAETIMEDOUT
                                Debug.WriteLine("run(): ReadLine: TimedOut");
                                continue;
                            }
                            else if (socEx.SocketErrorCode == SocketError.WouldBlock)
                            {
                                // socEx.ErrorCode == 10035 // WSAEWOULDBLOCK
                                // TODO: this looks like a nice feature of Windows
                                Debug.WriteLine("run(): ReadLine: WouldBlock");
                                continue;
                            }
                            else if (socEx.SocketErrorCode == SocketError.Interrupted)
                            {
                                // socEx.ErrorCode == 10004 // WSAEINTR
                                // this happens when socket is closed (see close())
                                Debug.WriteLine("run(): ReadLine: Interrupted");
                                break;
                            }
                            else
                            {
                                Debug.WriteLine("run(): socEx.ErrorCode=" + socEx.ErrorCode);
                                Debug.WriteLine("run(): socEx.SocketErrorCode=" + socEx.SocketErrorCode);
                                throw ex;
                            }
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    if (line == null)
                    {
                        Debug.WriteLine("run() end of file");
                        break; // EOF: socket closed by server
                    }
                    if (line.TrimEnd() == "") continue;
                    try
                    {
                        this.processLine(line);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Unable to process: " + line + ">" + ex);
                    }
                }
                lastTimestamp = NO_TIMESTAMP;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("run() failed with " + ex.GetType());
                if (ex.InnerException is SocketException)
                {
                    SocketException socEx = ex.InnerException as SocketException;
                    Debug.WriteLine("socEx.ErrorCode=" + socEx.ErrorCode);
                    Debug.WriteLine("socEx.SocketErrorCode=" + socEx.SocketErrorCode);
                }
            }
            finally
            {
                running = false;
            }
            Debug.WriteLine("run() terminated");
        }

        private void processLine(String line)
        {
            MessageReceivedEventArgs msgReceived = this.parseLine(line);
            if (msgReceived.Type == MessageType.VERSION)
            {
                this.ServerVersion = msgReceived.MessageString;
            }
            if ((msgReceived.Type & (MessageType.RECEIVE | MessageType.SEND)) != 0)
            {
                LoconetFrame loconetFrame = LoconetFrame.fromString(msgReceived.MessageString);
                OnLoconetFrameRecieved(loconetFrame);
            }
            if ((msgReceived.Type & this.filter) != 0)
            {
                this.fireMessageReceived(msgReceived);
            }
        }

        /// <summary>
        /// Parse message to a MessageReceivedEventArgs. Timestamp are
        /// added from value of lastTimestamp.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private MessageReceivedEventArgs parseLine(String line)
        {
            if (line == null) throw new ArgumentNullException("line");
            MessageReceivedEventArgs retVal = null;
            if (line.StartsWith("VERSION"))
            {
                retVal = new MessageReceivedEventArgs(MessageType.VERSION, line.Substring(7).TrimStart(), lastTimestamp);
                lastTimestamp = NO_TIMESTAMP; // reset for next call
            }
            else if (line.StartsWith("RECEIVE"))
            {
                retVal = new MessageReceivedEventArgs(MessageType.RECEIVE, line.Substring(7).TrimStart(), lastTimestamp);
                lastTimestamp = NO_TIMESTAMP; // reset for next call
            }
            else if (line.StartsWith("SEND"))
            {
                retVal = new MessageReceivedEventArgs(MessageType.SEND, line.Substring(4).TrimStart(), lastTimestamp);
                lastTimestamp = NO_TIMESTAMP; // reset for next call
            }
            else if (line.StartsWith("SENT"))
            {
                retVal = new MessageReceivedEventArgs(MessageType.SENT, line.Substring(4).TrimStart(), lastTimestamp);
                lastTimestamp = NO_TIMESTAMP;
            }
            else if (line.StartsWith("TIMESTAMP"))
            {
                lastTimestamp = parseTimestamp(line.Substring(9)); // save
                retVal = new MessageReceivedEventArgs(MessageType.TIMESTAMP, line.Substring(9).TrimStart(), lastTimestamp);
            }
            else if (line.StartsWith("BREAK"))
            {
                retVal = new MessageReceivedEventArgs(MessageType.BREAK, line.Substring(5).TrimStart(), lastTimestamp);
                lastTimestamp = NO_TIMESTAMP; // reset for next call
            }
            else if (line.StartsWith("ERROR"))
            {
                retVal = new MessageReceivedEventArgs(MessageType.ERROR, line.Substring(5).TrimStart(), lastTimestamp);
                lastTimestamp = NO_TIMESTAMP; // reset for next call
            }
            else
            {
                retVal = new MessageReceivedEventArgs(MessageType.UNKNOWN, line);
                lastTimestamp = NO_TIMESTAMP; // reset for next call
            }
            return retVal;
        }

        private static Int64 parseTimestamp(String s)
        {
            try
            {
                return Int64.Parse(s.Trim());
            }
            catch (FormatException)
            {
                return NO_TIMESTAMP;
            }
            catch (OverflowException)
            {
                return NO_TIMESTAMP;
            }
        }

    }
}
