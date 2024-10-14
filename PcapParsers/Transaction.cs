using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.IPLib;
using Tamir.IPLib.Packets;
using IPExplorer.Utils;
using IPExplorer.PcapParsers;

namespace IPExplorer.PcapParsers
{
	class Transaction
	{
		#region properties
		public static int httpPort	= 80;
		public static int popPort	= 110;
		public static int smtpPort	= 25;
		public static int msnPort	= 1863;
		public static int oscarPort = 5190;
		public static int imapPort	= 143;
		//tcp & ip fields
		private long ip1;
		private long ip2;
		private int port1;
		private int port2;
		//cumulative content data. 
		private StringBuilder data;
		public StringBuilder Data
		{
		  get { return data; }
		}
		//object for data parsing
		private DataParser parser;
		internal DataParser Parser
		{
			get { return parser; }
		}
		
		private string errorMsg;
		public string ErrorMsg
		{
			get { return errorMsg; }
		}
		//transaction protocol
		private Protocol protocol = Protocol.Unknown;
		internal Protocol Protocol
		{
			get { return protocol; }
		}

		#endregion

		public Transaction(TCPPacket packet)
		{
			ip1 = packet.SourceAddressAsLong;
			ip2 = packet.DestinationAddressAsLong;
			port1 = packet.SourcePort;
			port2 = packet.DestinationPort;
			data = new StringBuilder();
			if (port1 == httpPort || port2 == httpPort)
			{
				parser = new HttpParser(httpPort);
				protocol = Protocol.Http;
			}
			else if (port1 == popPort || port2 == popPort)
			{
				parser = new PopParser(popPort);
				protocol = Protocol.Pop;
			}
			else if (port1 == smtpPort || port2 == smtpPort)
			{
				parser = new SmtpParser(smtpPort);
				protocol = Protocol.Smtp;
			}
			else if (port1 == msnPort || port2 == msnPort)
			{
				parser = new MsnParser(msnPort);
				protocol = Protocol.Msn;
			}
            else if ((6891 <= port1 && port1 <= 6900))
            {
                parser = new MsnFtpParser(port1);
                protocol = Protocol.MsnFile;
            }
            else if ((6891 <= port2 && port2 <= 6900))
            {
                parser = new MsnFtpParser(port2);
                protocol = Protocol.MsnFile;
            }
			else if (port1 == oscarPort || port2 == oscarPort)
			{
				parser = new OscarParser(oscarPort);
				protocol = Protocol.Oscar;
			}
			else if (port1 == imapPort || port2 == imapPort)
			{
				parser = new ImapParser(imapPort);
				protocol = Protocol.Imap;
			}
		}

		public bool matchTransaction(TCPPacket packet)
		{
			return ((ip1 == packet.SourceAddressAsLong && port1 == packet.SourcePort &&
				ip2 == packet.DestinationAddressAsLong && port2 == packet.DestinationPort) ||
				(ip2 == packet.SourceAddressAsLong && port2 == packet.SourcePort &&
				ip1 == packet.DestinationAddressAsLong && port1 == packet.DestinationPort));
		}

		public int processPacket(TCPPacket packet)
		{
			//do not parse packets without content data
			if (packet.TCPPacketByteLength - packet.TCPHeaderLength <= 0)
			{
				return (int)EventMask.None;
			}
			//convert packet bytes into the simple string
			parser.m_IsServer = (packet.SourcePort == parser.m_Port);
			string dataStr = null;
			try
			{
				dataStr = new String(packet.Data.Cast<char>().ToArray(), 0, packet.TCPPacketByteLength - packet.TCPHeaderLength);
			}
			catch {}
			try
			{
				parser.m_IsServer = (packet.SourcePort == parser.m_Port);
				if (protocol == Protocol.Msn || protocol == Protocol.Oscar)
				{
					((ChatParser)parser).Time = TimeUtils.getTimeEpoch(packet.Timeval.Seconds, packet.Timeval.MicroSeconds);
				}
				return parser.parseData(ref dataStr, ref data);
			}
			catch (Exception e)
			{
				errorMsg = e.Message;
				return (int)EventMask.Error;
			}
		}
		public void finish()
		{
			parser.finish(ref data);
		}
	}
}
