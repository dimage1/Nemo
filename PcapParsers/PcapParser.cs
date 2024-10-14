using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tamir.IPLib;
using Tamir.IPLib.Packets;
using Tamir.IPLib.Packets.Util;
using IPExplorer.DBs;
using IPExplorer.DBs.Tables;
using IPExplorer.Utils;

namespace IPExplorer.PcapParsers
{
	class PcapParser
	{
		#region Properties
		private List<Transaction> m_Transactions;
		//folder for storing out files in
		public string m_OutFolder { get; set; }
		public string errorMsg { get; set; }
		public int m_FileId { get; set; }        
		private IPEOracleProvider db;
		//data for proxy files writing
		private StringBuilder m_Data;
		//packets for join
		private List<Packet> m_JPackets;
		//index List of joining packets
		private List<int> m_JIndexes;
		//parse result
		private bool m_Result;
		private PcapDevice device;
        public int m_FlowId;
		#endregion

		#region Constructor
		public PcapParser(IPEOracleProvider dbc)
		{
			errorMsg = String.Empty;
			m_Transactions = new List<Transaction>();
			db = dbc;
		}
		#endregion

		#region Append Pcaps

		public void appendPcaps(string[] pcaps, string outPath)
		{
			PcapDevice locDev = null;
			for (int i = 0; i < pcaps.Length; i++)
			{
				try
				{
					//Get an offline file pcap device
					if (i > 0)
					{
						locDev = SharpPcap.GetPcapOfflineDevice(pcaps[i]);
						//Open the device for capturing
						locDev.PcapOpen();
						//Register our handler function to the 'packet arrival' event
						locDev.PcapOnPacketArrival +=
							new SharpPcap.PacketArrivalEvent(onAppendPacketArrival);
						locDev.PcapCapture(SharpPcap.INFINITE);
					}
					//Get an offline file pcap device
					else
					{
						device = SharpPcap.GetPcapOfflineDevice(pcaps[0]);
						//Open the device for capturing
						device.PcapOpen();
						device.PcapDumpOpen(outPath);
						//Register our handler function to the 'packet arrival' event
						device.PcapOnPacketArrival +=
							new SharpPcap.PacketArrivalEvent(onAppendPacketArrival);
						device.PcapCapture(SharpPcap.INFINITE);
					}
				}
				catch (Exception e)
				{
					errorMsg = e.Message;
					continue;
				}
				//Close the pcap device
				if (i > 0)
				{
					locDev.PcapClose();
				}
			}
			try
			{
				device.PcapDumpFlush();
				device.PcapDumpClose();
				device.PcapClose();
			}
			catch { }
		}

		/// <summary>
		/// Calls every time packet arrivals from file to join
		/// </summary>
		private void onAppendPacketArrival(object sender, Packet packet)
		{
            device.PcapDump(packet);
		}
		#endregion

		#region Join Pcaps
		public void joinPcaps(string[] pcaps, string outPath)
		{
			m_JPackets = new List<Packet>();
			m_JIndexes = new List<int>();
			for (int i = 0; i < pcaps.Length; i++)
			{
				try
				{
					//Get an offline file pcap device
					device = SharpPcap.GetPcapOfflineDevice(pcaps[i]);
					//Open the device for capturing
					device.PcapOpen();
				}
				catch (Exception e)
				{
					errorMsg = e.Message;
					continue;
				}
				//Register our handler function to the 'packet arrival' event
				device.PcapOnPacketArrival +=
					new SharpPcap.PacketArrivalEvent(onJoinPacketArrival);

				//Start capture 'INFINTE' number of packets
				//This method will return when EOF reached.
				try
				{
					device.PcapCapture(SharpPcap.INFINITE);
				}
				catch { }
				//Close the pcap device
				if (i < pcaps.Length - 1)
				{
					device.PcapClose();
				}
			}
			writeJoiningPackets(outPath);
			m_JPackets.Clear();
			m_JIndexes.Clear();
		}
		/// <summary>
		/// Calls every time packet arrivals from file to join
		/// </summary>
		private void onJoinPacketArrival(object sender, Packet packet)
		{
			m_JPackets.Add(packet);
			int count = m_JIndexes.Count;
			// if 1st packet - just add 0 index
			if (count == 0)
			{
				m_JIndexes.Add(0);
			}
			else
			{
				int i;
				//find the place for current packet
				for (i = 0; i < count; i++)
				{
					if (isTimevalGreater(m_JPackets[m_JIndexes[i]].Timeval, packet.Timeval))
					{
						m_JIndexes.Insert(i, count);
						break;
					}
				}
				if (i == count)
				{
					m_JIndexes.Add(count);
				}
			}
		}
		//returns true if first greater then second
		//used microseconds and seconds for high precision
		private bool isTimevalGreater(Timeval first, Timeval second)
		{
			return ((first.Seconds > second.Seconds) ||
				(first.Seconds == second.Seconds && first.MicroSeconds > second.MicroSeconds));
		}

		//write reordering packets data into one file
		private void writeJoiningPackets(string outPath)
		{
			device.PcapDumpOpen(outPath);
			for (int i = 0; i < m_JIndexes.Count; i++)
			{
				device.PcapDump(m_JPackets[m_JIndexes[i]]);
			}
			device.PcapDumpFlush();
			device.PcapDumpClose();
			device.PcapClose();
		}
		#endregion

		#region Parse Pcap
		//parse pcap file using SharpPcap lib
		public bool parseFile(string fileName, int firstId)
		{
			try
			{
				//Get an offline file pcap device
				device = SharpPcap.GetPcapOfflineDevice(fileName);
				//Open the device for capturing
				device.PcapOpen();
			}
			catch (Exception e)
			{
				errorMsg = e.Message;
				return false;
			}
			//Register our handler function to the 'packet arrival' event
			device.PcapOnPacketArrival +=
				new SharpPcap.PacketArrivalEvent(onPacketArrival);

			m_Result = true;
			m_FileId = firstId;
			//Start capture 'INFINTE' number of packets
			//This method will return when EOF reached.
			try
			{
				device.PcapCapture(SharpPcap.INFINITE);
			}
			catch (Exception)
			{
                m_Result = false;
			}
			//Close the pcap device
			device.PcapClose();
			//write last data if pcap without correct end
			while (m_Transactions.Count > 0)
			{
				m_Transactions[0].finish();
				m_Data = m_Transactions[0].Data;
				writeData(m_Transactions[0]);
				m_Transactions.RemoveAt(0);
			}            
			return m_Result;
		}

		/// <summary>
		/// Parses tcp data. Calls every time packet arrivals from file
		/// </summary>
		private void onPacketArrival(object sender, Packet packet)
		{
			if (packet is TCPPacket && m_Result)
			{
				TCPPacket tcpPacket = (TCPPacket)packet;
				Transaction tran = null;
				int i;
				for (i = 0; i < m_Transactions.Count; i++)
				{
					tran = m_Transactions[i];
					if (tran.matchTransaction(tcpPacket))
					{
						break;
					}
					else
					{
						tran = null;
					}
				}
				//if packet not matches any transactions
				if (tran == null)
				{
					//create new for it
					tran = new Transaction(tcpPacket);
					if (tran.Protocol != Protocol.Unknown)
					{
						m_Transactions.Add(tran);
					}
					else
					{
						return;
					}
				}
				int mask = tran.processPacket(tcpPacket);
				if ((mask & (int)EventMask.Error) > 0)
				{
					m_Result = false;
					errorMsg += tran.ErrorMsg;
					return;
				}
				else if ((mask & (int)EventMask.TransactionFinished) > 0)
				{
					m_Data = tran.Data;
					writeData(tran);
					m_Transactions.Remove(tran);
				}
			}
		}

		/// <summary>
		/// Writes all data into the file
		/// </summary>
		private void writeData(Transaction tran)
		{
			if (m_Data.Length == 0)
			{
				return;
			}
			try
			{
				string path;
				if (tran.Protocol == Protocol.Smtp || tran.Protocol == Protocol.Pop)
				{
					path = m_OutFolder + "Mail\\";
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					path += m_FileId + ".msg";
					MailParser mail = (MailParser)tran.Parser;
					if (mail.Attachments.Count > 0)
					{
						writeAttachments(mail.Attachments);
					}
				}
				else if (tran.Protocol == Protocol.Http)
				{
					path = m_OutFolder + "HTTP\\";
					HttpParser httpTr = (HttpParser)tran.Parser;
					if (!string.IsNullOrEmpty(httpTr.m_PostContent))
					{
						db.SetDBHttpPost(httpTr.m_PostContent, m_FileId);
					}
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					path += m_FileId;
				}
				else if (tran.Protocol == Protocol.Msn)
				{
					path = m_OutFolder + "MSN\\";
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					path = path + m_FileId + ".html";
					updateMsnDB((MsnParser)tran.Parser);
				}
				else if (tran.Protocol == Protocol.MsnFile)
				{
					path = m_OutFolder + "FILE\\";
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					path = path + m_FileId;
				}
				else if(tran.Protocol == Protocol.Oscar)
				{
					OscarParser op = tran.Parser as OscarParser;
					Msn msn = new Msn(m_FlowId, op.MsgNum, Msn_Type.Session);
					db.InsertDBMsn(msn);
					User user = new User(m_FlowId);
					user.Type = UserType.Name;
					user.UserName = op.User;
					db.InsertDBUser(user);
					path = m_OutFolder + "OSCAR\\";
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					writeOscarSessions(op.Sessions, path);
					return;
				}
				else if (tran.Protocol == Protocol.Imap)
				{
					return;
				}
				else
				{
					errorMsg = "Unhandled protocol";
					m_Result = false;
					return;
				}
				m_FileId++;
				FileStream writer = new FileStream(
						path, FileMode.Create);
				writer.Write(m_Data.ToString().ToCharArray().Cast<byte>().ToArray(), 0, m_Data.Length);
				writer.Flush();
				writer.Close();
			}
			catch (Exception e)
			{
				errorMsg = e.Message;
				m_Result = false;
			}
		}

		//TODO: temp
		//adds msn info into the DB
		//temprory. this info must be obtained from netlook xml,
		//but now it's dummy.
		private void updateMsnDB(MsnParser msn)
		{
			Msn msns = new Msn();
			msns.FlowID = m_FileId;
			msns.MsgNum = msn.MsgNum;
			db.UpdateMsnDb(msns);
			User user = new User(m_FlowId, string.Empty, UserType.Email);
			//db.InsertDBUser(user);
			user.FlowID = m_FlowId;
			for (int i = 0; i < msn.Abonents.Count(); i++)
			{
				user.UserName = msn.Abonents[i];
				db.InsertDBUser(user);
			}
		}

		private void writeOscarSessions(List<OscarSession> sessions, string path)
		{
			User user = new User(m_FlowId);
			user.Type = UserType.Name;
			foreach (OscarSession ses in sessions)
			{
				//do not store empty sessions
				if (ses.MsgNum <= 0)
					continue;
				//insert oscar session info				
				db.InsertDBOscar(new Oscar(m_FlowId, ses.MsgNum));
				user.UserName = ses.Buddy.Name;
				db.InsertDBUser(user);
				//write content data
				StreamWriter sw = File.CreateText(path + db.MaxOscarID + ".html");
				sw.Write(ses.History.ToString());
				sw.Flush();
				sw.Close();
			}
		}

		/// <summary>
		/// Writes attachments of the mail into the corresponding files
		/// also decoded them into valid form
		/// </summary>
		private void writeAttachments(List<Attachment> attList)
		{
			byte[] bytes;
			FileStream writer;
			string content;
			string ext;
			string path;
			for (int i = 0; i < attList.Count; i++)
			{
				try
				{
					ext = Path.GetExtension(attList[i].name);
					//attList[i].name.Substring(attList[i].name.LastIndexOf('.'));
				}
				catch (Exception)
				{
					ext = string.Empty;
				}
				//add attahcment name to db
				MailAttachment aDb = new MailAttachment();
                Files file = new Files();
				aDb.MailID = m_FileId;
				file.Name = attList[i].name;
                file.Extension = Path.GetExtension(file.Name).ToLower();
                if (string.IsNullOrEmpty(file.Extension))
                    file.Extension = ".";
                file.FlowID = m_FlowId;                
				db.InsertFile(file);
                db.InsertMailAttachments(aDb);
                if (!Directory.Exists(m_OutFolder + "File\\"))
                {
                    Directory.CreateDirectory(m_OutFolder + "File\\");
                }
                path = m_OutFolder + "File\\" + db.MaxFileID.ToString();
				//converting may fall if attachment endoced but no all data exists
				try
				{
					if (attList[i].encoding.ToLower().Equals("base64"))
					{
						content = m_Data.ToString().Substring(attList[i].from, attList[i].size);
						bytes = Convert.FromBase64String(content);
						writer = new FileStream(path, FileMode.Append);
						writer.Write(bytes, 0, bytes.Length);
						writer.Flush();
						writer.Close();
					}
					else if (attList[i].encoding.ToLower().Equals("x-uue"))
					{
						int size;
						bytes = xuueDecode(attList[i].from, attList[i].size, out size);
						writer = new FileStream(path, FileMode.Append);
						writer.Write(bytes, 0, size);
						writer.Flush();
						writer.Close();
					}
					else
					{
						StreamWriter sw = File.AppendText(path);
						sw.Write(m_Data.ToString().Substring(attList[i].from, attList[i].size));
						sw.Flush();
						sw.Close();
					}
				}
				catch
				{
					System.IO.File.Create(path);
				}
			}
		}
		#endregion

		#region XUUE decoding
		/// <summary>
		/// perfomes xuue decoding on data
		/// returns decoded bytes and bytes num in out param
		/// </summary>
		private byte[] xuueDecode(int from, int size, out int outSize)
		{
			string content = m_Data.ToString().Substring(from, size);
			//find the beginning of data
			content = content.Substring(content.IndexOf("\r\n") + 2);
			content = content.Substring(0, content.IndexOf("end\r\n"));
			byte[] res = new byte[content.Length * 2];
			int n;
			outSize = 0;
			byte ch;
			//i +=2 to skip \r\n in the end of encoded string
			for (int i = 0; i < content.Length; i += 2)
			{
				//obtain number of chars in current string before encoding
				n = DEXUUE(content[i++]);
				for (; n > 0; i += 4, n -= 3)
				{
					//decode bytes
					if (n >= 3)
					{
						ch = (byte)(DEXUUE(content[i]) << 2 | DEXUUE(content[i + 1]) >> 4);
						res[outSize++] = ch;
						ch = (byte)(DEXUUE(content[i + 1]) << 4 | DEXUUE(content[i + 2]) >> 2);
						res[outSize++] = ch;
						ch = (byte)(DEXUUE(content[i + 2]) << 6 | DEXUUE(content[i + 3]));
						res[outSize++] = ch;
					}
					else
					{
						if (n >= 1)
						{
							ch = (byte)(DEXUUE(content[i]) << 2 | DEXUUE(content[i + 1]) >> 4);
							res[outSize++] = ch;
						}
						if (n >= 2)
						{
							ch = (byte)(DEXUUE(content[i + 1]) << 4 | DEXUUE(content[i + 2]) >> 2);
							res[outSize++] = ch;
						}
					}
				}
			}
			return res;
		}
		/// <summary>
		/// Converts xuue encoded byte into the clean byte 
		/// </summary>
		private byte DEXUUE(char b)
		{
			byte cb = (byte)b;
			// ''' -> ' ' due to xuue encoding
			if (cb == 96)
			{
				cb = 32;
			}
			return (byte)((cb - 32) & 63);
		}
		#endregion
	}
}
