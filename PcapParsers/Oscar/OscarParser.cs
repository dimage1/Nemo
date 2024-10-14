using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPExplorer.Utils;
using System.Text.RegularExpressions;

namespace IPExplorer.PcapParsers
{
	//http://iserverd.khstu.ru/oscar/, 
	//http://dev.aol.com/aim/oscar/

	#region Custom classes
	//Buddy class for storing buddy info
	class Buddy
	{
		//buddy name
		private string _name;
		//TODO: add buddy info if needed

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Buddy(string name)
		{
			_name = name;
		}
	}
	//user to user session Class
	//used to handle users chat dialog
	class OscarSession
	{
		//session buddy (recepient)
		public Buddy Buddy;
		//session history
		public StringBuilder History = new StringBuilder();
		//number of in session messages
		public int MsgNum = 0;

		public OscarSession(string buddy)
		{
			Buddy = new Buddy(buddy);
		}

		public OscarSession(Buddy buddy)
		{
			Buddy = buddy;
		}
	}

	//Custom data type class
	class TLV
	{
		private int _type;
		private int _dataLen;

		public int Type
		{
			get { return _type; }
			set { _type = value; }
		}
		public int DataLen
		{
			get { return _dataLen; }
			set { _dataLen = value; }
		}

		public TLV() { }
		public TLV(int type, int dataLen)
		{
			_type = type;
			_dataLen = dataLen;
		}
	}
	#endregion

	class OscarParser : ChatParser
	{
		#region Enums
		enum ICBMType
		{
			Outgoing = 6,
			Incoming = 7,
			Unknown = -1
		};

		enum SNACFoodgroup
		{
			ICBM = 4,
			Unknown = -1
		}

		enum ICBMChannel
		{
			Simple = 1,
			Rendezvous = 2
		}

		enum RendezvousMsgType
		{
			Request = 0,
			Accept = 1,
			Cancel = 2
		}

		enum RendezvousDataFormat
		{
			Channel2ICQ,
			Unknown
		}

		enum RendezvousPlugin
		{
			None,
			Unknown
		}

		enum MsgType
		{
			MTYPE_PLAIN		=   0x01,	//Plain text (simple) message
			MTYPE_CHAT		=	0x02,	//Chat request message
			MTYPE_FILEREQ	=	0x03,	//File request / file ok message
			MTYPE_URL  		=	0x04,	//URL message (0xFE formatted)
			MTYPE_AUTHREQ  	=	0x06,	//Authorization request message (0xFE formatted)
			MTYPE_AUTHDENY  =	0x07,	//Authorization denied message (0xFE formatted)
			MTYPE_AUTHOK  	=	0x08,	//Authorization given message (empty)
			MTYPE_SERVER  	=   0x09,	//Message from OSCAR server (0xFE formatted)
			MTYPE_ADDED  	=   0x0C,	//"You-were-added" message (0xFE formatted)
			MTYPE_WWP  		=	0x0D,	//Web pager message (0xFE formatted)
			MTYPE_EEXPRESS  =	0x0E,	// Email express message (0xFE formatted)
			MTYPE_CONTACTS  =	0x13,	//Contact list message
			MTYPE_PLUGIN  	=	0x1A,	//Plugin message described by text string
			MTYPE_AUTOAWAY  =	0xE8,	//Auto away message 
			MTYPE_AUTOBUSY  =	0xE9,	//Auto occupied message 
			MTYPE_AUTONA  	=	0xEA,	//Auto not available message 
			MTYPE_AUTODND  	=	0xEB,	//Auto do not disturb message 
			MTYPE_AUTOFFC   =	0xEC,	//Auto free for chat message
			MTYPE_UNKNOWN	=	0x00
		}
		#endregion

		#region Static Properties
		private static byte _SNACID = 0x02;
		private static byte _FLAPSize = 6;
		private static byte _ICBMStartPos = 0x0A;
		private static byte _ICBMCookieLen = 8;
		private static byte _ICBMChannelPos = (byte)(_ICBMStartPos + _ICBMCookieLen + 1 + _FLAPSize);
		private static byte _ICBMBuddyLenPos = (byte)(_ICBMChannelPos + 1);
		private static byte _ICBMBuddyPos = (byte)(_ICBMBuddyLenPos + 1);
		private static int _msgBlockID = 0x2;
		private static int _msgTextID = 0x0101;
		private static int _rendezvousBlockID = 0x05;
		private static int _rendezvousExtensionID = 0x2711;
		#region GUIDS
		private static int _guidLen = 0x10;
		//09461349-4C7F-11D1-8222-444553540000
		private static int []_icqChannel2GUID = {	0x09, 0x46, 0x13, 0x49, 0x4c, 0x7f, 0x11, 0xd1,
													0x82, 0x22, 0x44, 0x45, 0x53, 0x54, 0x00, 0x00};
		//00000000-0000-0000-0000-000000000000
		private static int[] _noPluginGUID = {	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
												0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
		#endregion
		#endregion

		#region Private Properties
		private List<OscarSession> _sessions;
		private OscarSession _session = null;
		private int _pos = 0;
		#endregion

		#region Public Properties
		public List<OscarSession> Sessions
		{
			get { return _sessions; }
		}
		#endregion

		#region Costructor
		//MSN Parser.
		//By now parses msn data to obtain users dialog
		public OscarParser(int port) : base(port)
		{
			_sessions = new List<OscarSession>();
		}
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		#region General
		override protected int parse(ref string data, ref StringBuilder content)
		{
			int mask = (int)EventMask.None;
			//parse only finished block
			if(getDataLen(ref data) + _FLAPSize <= data.Length )
			{
				try
				{
					ICBMType type;
					//parse SNAC block
					if (isSNAC(ref data) && (type = getICBMType(ref data)) != ICBMType.Unknown)
					{
						if (type == ICBMType.Outgoing || type == ICBMType.Incoming)
							parseICBM(ref data, getICBMType(ref data));
					}
					data = string.Empty;
				}
				catch { }
			}
			content.Append("0");
			return mask;
		}

		private OscarSession getSession(string buddy)
		{
			foreach (OscarSession session in _sessions)
			{
				if (session.Buddy.Name.Equals(buddy))
					return session;
			}
			OscarSession ses = new OscarSession(buddy);
			_sessions.Add(ses);
			return ses;
		}

		private void addUserMsgToSession(string msg, ICBMType type)
		{
			if (type == ICBMType.Outgoing)
				addMsgHistory(null, msg, ref _session.History);
			else
				addMsgHistory(_session.Buddy.Name, msg, ref _session.History);
		}

		#endregion


		#region SNAC
		//verifies that FLAP has SNAC block
		private bool isSNAC(ref string data)
		{
			//FLAP id is in the second byte
			return (data[1] == _SNACID);
		}

		#region ICBM
		private void parseICBM(ref string data, ICBMType type)
		{
			int channel = data[_ICBMChannelPos];
			byte buddyLen = (byte)data[_ICBMBuddyLenPos];
			_session = getSession(data.Substring(_ICBMBuddyPos, buddyLen));
			_pos = _ICBMBuddyPos + buddyLen;
			if (type == ICBMType.Incoming)
			{
				getBuddyInfo(ref data, ref _pos, _session.Buddy);
			}
			TLV tlv = new TLV();
			processTLV(ref data, ref _pos, tlv);
			if (channel == (int)ICBMChannel.Simple)
			{
				if (_msgBlockID == tlv.Type)
					parseSimpleMsg(ref data, type);
			}
			else if (channel == (int)ICBMChannel.Rendezvous)
			{
				if(_rendezvousBlockID == tlv.Type)
					parseRendezvous(ref data, type);
			}
		}

		private ICBMType getICBMType(ref string data)
		{
			ICBMType res = ICBMType.Unknown;
			//6th, 7 bytes is foodgroup 00xx
			int startPos = 6;
			if (getValue(ref data, ref startPos) == (byte)SNACFoodgroup.ICBM)
			{
				//8th, 9 bytes is a type(00xx)
				res = (ICBMType)(getValue(ref data, ref startPos));
			}
			return res;
		}

		#region Buddy
		//obtains buddy info from packet data
		//returns posisition of info block end 
		private void getBuddyInfo(ref string data, ref int startPos, Buddy buddy)
		{
			//skip warning level
			startPos += 2;
			//get user info TVL's number
			int userTLVsNum = getValue(ref data, ref startPos);//data[startPos] << 8 + data[++startPos];
			for (int i = 0; i < userTLVsNum; i++)
			{
				processInfoTLV(ref data, ref startPos, buddy);
			}
		}

		//returns position of the byte after TLV
		private void processInfoTLV(ref string data, ref int startPos, Buddy buddy)
		{
			//TODO: add user info updated if needed
			TLV tlv = new TLV();
			processTLV(ref data, ref startPos, tlv);
			startPos += tlv.DataLen;
		}
		#endregion

		#region Simple Message(Channel 1)
		private void parseSimpleMsg(ref string data, ICBMType type)
		{
			/*
			 *  05	 	byte	 	fragment identifier (array of required capabilities)
				01	 	byte	 	fragment version
				xx xx	word	 	TLV.Length
				xx ..	array	 	byte array of required capabilities (1 - text)
				01	 	byte	 	fragment identifier (message text)
				01	 	byte	 	fragment version
				xx xx	word	 	TLV.Length
				00 00	word	 	Message charset number
				ff ff	word	 	Message charset subset
				xx ..	string (ascii)	 	Message text string
			 * */
			TLV tlv = new TLV(); ;
			processTLV(ref data, ref _pos, tlv);
			//skip this TLV block
			_pos += tlv.DataLen;
			processTLV(ref data, ref _pos, tlv);
			//check that next block is message text
			if (_msgTextID == tlv.Type)
			{
				//obtain charset number
				int charset = getValue(ref data, ref _pos);
				//skip charset subset(unusable)
				_pos += 2;
				string msg = data.Substring(_pos, tlv.DataLen - 4); // 4 for charsets
				_session.MsgNum++;
				_msgNum++;
				addUserMsgToSession(msg, type);
				_pos += msg.Length;
			}
		}
		#endregion

		#region Rendezvous Message(Channel 2)
		private void parseRendezvous(ref string data, ICBMType type)
		{
			/*
			00 05	 		word	 	TLV.Type(0x05) - rendezvous message data
			xx xx	 		word	 	TLV.Length
			xx xx	 		word	 	message type (0 - request, 1 - cancel, 2 - accept)
			xx xx xx xx
			xx xx xx xx	 	qword	 	msg-id cookie (same as above)
			xx .. xx	 	guid	 	capability (determines format of message data in "extention data" below)
			
			00 04	 		word	 	TLV.Type(0x04) - external ip
			xx xx	 		word	 	TLV.Length
			xx xx xx xx	 	dword	 	external ip
			00 05	 		word	 	TLV.Type(0x05) - listening port
			xx xx	 		word	 	TLV.Length
			xx xx	 		word	 	listening port
			00 0A	 		word	 	TLV.Type(0x0A) - unknown
			xx xx	 		word	 	TLV.Length
			xx xx	 		word	 	unknown (usually 1)
			00 0B	 		word	 	TLV.Type(0x0B) - unknown
			xx xx	 		word	 	TLV.Length
			xx xx	 		word	 	unknown
			00 0F	 		word	 	TLV.Type(0x0F) - unknown
			00 00	 		word	 	TLV.Length	empty
		
			27 11	 		word	 	TLV.Type(0x2711) - extention data
			xx xx	 		word	 	TLV.Length
			Following contents is capability-specific.*/
			//when data came here we stay at the message type pos
			//skip type and Cookie
			_pos += 10;
			RendezvousDataFormat format = getDataFormat(ref data, ref _pos);
			//skip TLVs until extension data
			TLV tlv = new TLV();
			do
			{
				processTLV(ref data, ref _pos, tlv);
				if(tlv.Type == _rendezvousExtensionID)
				{
					switch (format)
					{
						case RendezvousDataFormat.Channel2ICQ:
							parseChannel2ICQ(ref data, ref _pos, type);
							break;
						default:
							break;
					}
					break;
				}
				else
				{
					_pos += tlv.DataLen;
				}

			}
			while (_pos < data.Length);
		}

		private void parseChannel2ICQ(ref string data, ref int startPos, ICBMType type)
		{
			/*
			Data format description for capability {09461349-4C7F-11D1-8222-444553540000} 
			xx xx	 		word (LE)	length of following data
			xx xx	 		word (LE)	protocol version
			xx .. xx	 	guid (LE)	plugin or zero bytes
			xx xx	 		word	 	unknown
			xx xx xx xx	 	dword (LE)	client capabilities flags
			xx	 			byte	 	unknown
			xx xx	 		word (LE)	seems to be a downcounter
			xx xx	 		word (LE)	length of following data
			xx xx	 		word (LE)	seems to be a downcounter as in first chunk above
			xx ..	 					unknown, usually zeros

			if plugin field in first chunk above is zero,
			here is message, overwise here is plugin-specific data.
			 * */
			int blockLen = getValueInversely(ref data, ref _pos);
			//skip proto
			_pos += 2;
			RendezvousPlugin plugin = getPlugin(ref data, ref _pos);
			//skip remaining data
			_pos += blockLen - 2 - _guidLen;
			blockLen = getValueInversely(ref data, ref _pos);
			//skip this block
			_pos += blockLen;
			//now we are at the beginning of message block
			switch (plugin)
			{
				case RendezvousPlugin.None:
					parseChannel2ICQNoPlugin(ref data, type);
					break;
				default:
					break;
			}
		}

		private void parseChannel2ICQNoPlugin(ref string data, ICBMType type)
		{
			/*
			xx	 	byte	 	message type
			xx	 	byte	 	message flags
			xx xx	word (LE)	status code
			xx xx	word (LE)	priority code
			xx xx	word (LE)	message string length
			xx ..	string	 	message string (null-terminated)
			 * */
			if (data[_pos++] == (int)MsgType.MTYPE_PLAIN)
			{
				_pos += 5;
				int len = getValueInversely(ref data, ref _pos);
				//get real text message, skip last \0
				string msg = data.Substring(_pos, len - 1);
				_session.MsgNum++;
				_msgNum++;
				addUserMsgToSession(msg, type);
				_pos += len;
			}
		}

		private RendezvousDataFormat getDataFormat(ref string data, ref int startPos)
		{
			RendezvousDataFormat res = RendezvousDataFormat.Unknown;
			if (matchGuid(ref data, startPos, _icqChannel2GUID))
			{
				res = RendezvousDataFormat.Channel2ICQ;
			}
			startPos += _guidLen;
			return res;
		}

		private RendezvousPlugin getPlugin(ref string data, ref int startPos)
		{
			RendezvousPlugin res = RendezvousPlugin.Unknown;
			if (matchGuid(ref data, startPos, _noPluginGUID))
			{
				res = RendezvousPlugin.None;
			}
			startPos += _guidLen;
			return res;
		}
		#endregion
		#endregion
		#endregion

		#region OSCAR Utils
		//returns position of the byte after TLV
		private void processTLV(ref string data, ref int startPos, TLV tlv)
		{
			tlv.Type = getValue(ref data, ref startPos);
			tlv.DataLen = getValue(ref data, ref startPos);
			//tlv.Data = data.Substring(startPos, len);
			//startPos += len;
		}

		//obtain length of incoming data
		private int getDataLen(ref string data)
		{
			//block len is in the 4th and 5th bytes
			return ((data[4] << 8) + data[5]);
		}

		//obtain 2 byte integer value
		//and shr pos
		private int getValue(ref string data, ref int startPos)
		{
			return (data[startPos++] << 8) + data[startPos++];
		}

		//obtain 2 byte integer value in reverse order
		//and shr pos
		private int getValueInversely(ref string data, ref int startPos)
		{
			return data[startPos++] + (data[startPos++] << 8);
		}

		//obtain integer value from byte array
		private int getValue(ref string data, ref int startPos, int byteNum)
		{
			int move = (byteNum - 1) << 3;
			int res = 0;
			for (int i = 0; i < byteNum; i++)
			{
				res += data[startPos++] << move;
				move -= 8;
			}
			return res;
		}

		private bool matchGuid(ref string data, int startPos, int[] guid)
		{
			for (int i = 0; i < guid.Length; i++)
			{
				if (data[startPos++] != guid[i])
					return false;
			}
			return true;
		}
		#endregion

		#endregion
	}
}
