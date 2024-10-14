using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPExplorer.PcapParsers
{
	class SmtpParser : MailParser
	{
		private ushort m_ServerCode = 0;
				
		public SmtpParser(int port)
		{
			m_HeadersParsed = false;
			m_Port = port;
			m_Attachments = new List<Attachment>();
			m_DataSb = new StringBuilder();
		}

		override public int parseData(ref string data, ref StringBuilder content)
		{
			int mask = (int)EventMask.None;
			if (!m_HeadersParsed)
			{
				if (m_IsServer)
				{
					//data sending starts after server send 354 code
					try
					{
						m_ServerCode = UInt16.Parse(data.Split(' ')[0].Replace("\r\n", ""));
						if (m_ServerCode == 354)
						{
							mask |= (int)EventMask.TransactionStarted;
						}
					}
					catch (Exception) { }
					return mask;
				}
				if (m_ServerCode != 354)
				{
					return mask;
				}
				m_Data += data;
				//wait until all headers came!
				if (!m_Data.Contains(m_HeadersEnd))
				{
					return mask;
				}
				processHeader(ref m_Data);
				m_HeadersParsed = true;
				m_DataSb.Append(m_Data);
			}
			else if(!m_IsServer)
			{
				m_DataSb.Append(data);
			}
			return processData(mask, ref content);
		}
	}
}
