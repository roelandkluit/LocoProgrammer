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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocoProgrammerInterfacing
{
	public class LNopcodes
	{
		public enum OPCODE : byte
		{
			// Private Opcode:
			OPC_DEBUG = 0xA8,   // Debug	this is a lie ->	NO
								//<0xA8>,<#1>,<#2>,<CHK>

			//
			//								 FOLLOW ON	RESPONSE
			//								      MSG?	TYPE 
			//**************************
			//* 2 Byte MESSAGE opcodes *
			//* FORMAT = <OPC>,<CKSUM> *
			//**************************

			OPC_IDLE = 0x85,    //FORCE IDLE state,				NO
								//B'cast emerg. STOP
			OPC_GPON = 0x83,    //GLOBAL power ON request		NO
			OPC_GPOFF = 0x82,   //GLOBAL power OFF req			NO
			OPC_BUSY = 0x81,    //MASTER busy code, NUL			NO

			//****************************************
			//* 4 byte MESSAGE OPCODES               *
			//* FORMAT = <OPC>,<ARG1>,<ARG2>,<CKSUM> *
			//****************************************

			OPC_LOCO_ADR = 0xBF,    //REQ  loco ADR				YES	<E7> SLOT READ
									//<0xBF>,<0>,<ADR>,<CHK> REQ loco ADR
									//DATA return <E7>, is SLOT#,DATA that ADR was found in
									//IF ADR not found, MASTER puts ADR in FREE slot
									//and sends DATA/STATUS return <E7>
									//IF no FREE slot,Fail  LACK,0 is returned
									//[<B4>,<3F>,<0>,<CHK>]

			OPC_SW_ACK = 0xBD,  //								YES LACK
								//REQ SWITCH WITH acknowledge function (not DT200)
								//<0xBD>,<SW1>,<SW2>,<CHK> REQ SWITCH function 
								//<SW1>	=<0,A6,A5,A4-A3,A2,A1,A0>, 7 ls adr bits. 
								//A1,A0 select 1 of 4 input pairs in a DS54
								//<SW2>	=<0,0,DIR,ON-A10,A9,A8,A7>, Control bits and 4 MS adr bits.
								//DIR=1 for Closed/GREEN, =0 for Thrown/RED
								//ON=1 for Output ON, =0 FOR output OFF
								//response is <0xB4><3D><00> if DCS100 FIFO is full, command rejected
								//		<0xB4><3D><7F> if DCS100 accepted 

			OPC_SW_STATE = 0xBC,    //REQ state of SWITCH		YES	LACK
									//<0xBC>,<SW1>,<SW2>,<CHK> REQ state of SWITCH

			OPC_RQ_SL_DATA = 0xBB,  //Request SLOT DATA/		YES	<E7> SLOT READ
									//                                status block
									//<0xBB>,<SLOT>,<0>,<CHK>  Request SLOT DATA/status block

			OPC_MOVE_SLOTS = 0xBA,  //MOVE slot SRC to DEST		YES	<E7> SLOT READ
									//<0xBA>,<SRC>,<DEST>,<CHK> Move SRC to DEST if SRC			or LACK  etc
									//is NOT IN_USE,   clr SRC
									//SPECIAL CASES:
									//If SRC=0 (DISPATCH GET), DEST=dont care,
									//  Return SLOT READ DATA of DISPATCH Slot
									//IF SRC=DEST (NULL move) then SRC=DEST is set to IN_USE, 
									//  if legal move
									//If DEST=0, is DISPATCH Put, mark SLOT as DISPATCH
									//RETURN slot status <0xE7> of DESTINATION slot DEST if move legal
									//RETURN Fail LACK code if illegal move <B4>,<3A>,<0>,<chk>
									//illegal to move to/from slots 120/127

			OPC_LINK_SLOTS = 0xB9,  //							YES	<E7> SLOT READ
									//LINK slot ARG1 to slot ARG2
									//<0xB9>,<SL1>,<SL2>,<CHK>  SLAVE slot SL1 to slot SL2
									//Master LINKER sets the SL_CONUP/DN flags appropriately
									//Reply is return of SLOT Status <0xE7>. Inspect to see result of Link
									//invalid Link will return Long Ack Fail <B4>,<39>,<0>,<CHK>

			OPC_UNLINK_SLOTS = 0xB8,    //						YES	<E7> SLOT READ
										// UNLINK slot ARG1 from slot ARG2
										//<0xB8>,<SL1>,<SL2>,<CHK>  UNLINK slot SL1 from SL2
										//UNLINKER executes unlink STRATEGY and returns new SLOT#
										// DATA/STATUS of unlinked LOCO . Inspect data to evaluate UNLINK

			//CODES 0xB8 to 0xBF have responses

			OPC_CONSIST_FUNC = 0xB6,    //							NO
										//SET FUNC bits in a CONSIST uplink element
										//<0xB6>,<SLOT>,<DIRF>,<CHK> UP consist FUNC bits
										//NOTE this SLOT adr is considered in UPLINKED slot space

			OPC_SLOT_STAT1 = 0xB5,  //WRITE slot stat1				NO
									//<0xB5>,<SLOT>,<STAT1>,<CHK> WRITE stat1

			OPC_LONG_ACK = 0xB4,    //Long acknowledge				NO
									//<0xB4>,<LOPC>,<ACK1>,<CHK> Long acknowledge
									//<LOPC> is COPY of OPCODE responding to (msb=0).
									//LOPC=0 (unused OPC) is also VALID fail code
									//<ACK1> is appropriate response code for the OPCode

			OPC_INPUT_REP = 0xB2,   // General SENSOR Input codes	NO
									// <0xB2>, <IN1>, <IN2>, <CHK>
									//<IN1>=<0,A6,A5,A4- A3,A2,A1,A0>, 7 ls adr bits.
									//  A1,A0 select 1 of 4 inputs pairs in a DS54
									//<IN2>=<0,X,I,L- A10,A9,A8,A7>	Report/status bits
									//  and 4 MS adr bits.
									//"I"=0 for DS54 "aux" inputs and 1 for "switch"
									//  inputs mapped to 4K SENSOR space.
									//  (This is effectively a least significant adr bit when
									//  using DS54 input configuration)
									//"L"=0 for input SENSOR now 0V (LO) , 1 for Input sensor >=+6V (HI)
									//"X"=1, control bit , 0 is RESERVED for future!

			OPC_SW_REP = 0xB1,  // Turnout SENSOR state REPORT		NO
								//<0xB1>,<SN1>,<SN2>,<CHK> SENSOR state REPORT
								//<SN1>=<0,A6,A5,A4- A3,A2,A1,A0>, 7 ls adr bits.
								//  A1,A0 select 1 of 4 input pairs in a DS54
								//
								//<SN2>=<0,1,I,L- A10,A9,A8,A7>	Report/status bits and 4 MS adr bits.
								//This <B1> opcode encodes INPUT LEVELS for turnout feedback
								//"I" =0 for "aux" inputs (normally not feedback),
								//    =1 for "switch" input used for turnout feedback for DS54 
								//       ouput/turnout # encoded by A0-A10
								//"L" = 0 for this input 0V (LO), 1= this input > +6V (HI)
								//
								//<SN2>=<0,0,C,T- A10,A9,A8,A7>	Report/status bits and 4 MS adr bits.
								//This <B1> opcode encodes current OUTPUT LEVELS
								//"C" =0 if "Closed" ouput line is OFF,
								//    =1 if "closed" output line is ON (sink current)
								//"T" =0 if "Thrown" output line is OFF,
								//    =1 if "thrown" output line is ON (sink I)

			OPC_SW_REQ = 0xB0,  //REQ SWITCH function				NO
								//<0xB0>,<SW1>,<SW2>,<CHK> REQ SWITCH function 
								//<SW1>	=<0,A6,A5,A4- A3,A2,A1,A0>, 7 ls adr bits.
								//  A1,A0 select 1 of 4 input pairs in a DS54
								//<SW2>	=<0,0,DIR,ON- A10,A9,A8,A7>, Control bits and 4 MS adr bits.
								//DIR=1 for Closed,/GREEN, =0 for Thrown/RED
								//ON=1 for Output ON, =0 FOR output OFF
								//
								//Note-,Immediate response of <0xB4><30><00> if command failed,
								//otherwise no response

			//"A" CLASS codes

			//CODES 0xA8 to 0xAF have responses

			OPC_LOCO_SND = 0xA2,    // SET SLOT sound functions		NO
			OPC_LOCO_DIRF = 0xA1,   // SET SLOT dir,F0-4 state		NO
			OPC_LOCO_SPD = 0xA0,    // SET SLOT speed				NO
									//e.g. <A0><SLOT#><SPD><CHK>


			//******************************************************
			//* 6 Byte MESSAGE OPCODES                             *
			//* FORMAT = <OPC>,<ARG1>,<ARG2>,<ARG3>,<ARG4>,<CKSUM> *
			//******************************************************
			//<reserved>


			//*******************************************************************
			//* VARIABLE Byte MESSAGE OPCODES                                   *
			//* FORMAT = <OPC>,<COUNT>,<ARG2>,<ARG3>,...,<ARG(COUNT-3)>,<CKSUM> *
			//*******************************************************************

			OPC_WR_SL_DATA = 0xEF,  //								YES	LACK
									// WRITE SLOT DATA, 10 bytes
									//<0xEF>,<0E>,<SLOT#>,<STAT>,<ADR>,<SPD>,<DIRF>,<TRK>
									//<SS2>,<ADR2>,<SND>,<ID1>,<ID2>,<CHK> 
									// SLOT DATA WRITE, 10 bytes data /14 byte MSG

			OPC_SL_RD_DATA = 0xE7,  //								NO
									// SLOT DATA return, 10 bytes
									//<0xE7>,<0E>,<SLOT#>,<STAT>,<ADR>,<SPD>,<DIRF>,<TRK>    
									//<SS2>,<ADR2>,<SND>,<ID1>,<ID2>,<CHK> 
									// SLOT DATA READ, 10 bytes data /14 byte MSG
									//
									//NOTE// If STAT2.2=0 EX1/EX2 encodes an ID#,
									//[if STAT2.2=1 the STAT.3=0 means EX1/EX2 are ALIAS]
									//ID1/ID2 are two 7 bit values encoding a 14 bit unique DEVICE usage ID
									//00/00          -means NO ID being used
									//01/00 to 7F/01 -ID shows PC usage.Lo nibble is TYP PC#
									//                (PC can use hi values)
									//00/02 to 7F/03 -SYSTEM reserved
									//00/04 to 7F/7E -NORMAL throttle RANGE

			OPC_SV_PROG = 0xE5,   //								NO
									// move 8 bytes PEER to PEER, SRC->DST
									//<0xE5>,<10>,<SRC>,<DSTL><DSTH>,<PXCT1>,<D1>,<D2>,<D3>,<D4>,
									//<PXCT2>,<D5>,<D6>,<D7>,<D8>,<CHK>
									//SRC/DST are 7 bit args. DSTL/H=0 is BROADCAST msg
									//SRC=0 is MASTER
									//SRC=0x70-0x7E are reserved
									//SRC=7F is THROTTLE msg xfer, <DSTL><DSTH> encode ID#,
									// <0><0> is THROT B'CAST
									//<PXCT1>=<0,XC2,XC1,XC0 - D4.7,D3.7,D2.7,D1.7>
									//XC0-XC2=ADR type CODE-0=7 bit Peer TO Peer adrs
									//			  1=><D1>is SRC HI,<D2>is DST HI
									//<PXCT2>=<0,XC5,XC4,XC3 - D8.7,D7.7,D6.7,D5.7>
									//XC3-XC5=data type CODE- 0=ANSI TEXT string,balance RESERVED

			OPC_IMM_PACKET = 0xED,  //SEND n-byte packet immediate	LACK
									//<0xED>,<0B>,<7F>,<REPS>,<DHI>,<IM1>,<IM2>,<IM3>,<IM4>,<IM5>,<CHK>
									//<DHI>=<0,0,1,IM5.7-IM4.7,IM3.7,IM2.7,IM1.7>
									//in <REPS> D4,5,6=#IM bytes,D3=0(reserved)// D2,1,0=repeat CNT
									//Not limited MASTER then LACK=<B4>,<7D>,<7F>,<chk> if CMD ok
									//IF limited MASTER then  Lim  Masters respond with 
									//  <B4>,<7E>,<lim adr>,<chk>
									//If internal buffer BUSY/full respond with <B4>,<7D>,<0>,<chk>
		}
	}
}
