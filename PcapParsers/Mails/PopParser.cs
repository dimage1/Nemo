using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPExplorer.PcapParsers
{
	class PopParser : MailParser
	{
		private string m_ServerAnswer = string.Empty;
		private string m_Command = string.Empty;
		private bool m_TransactionStarted = false;
		
		public PopParser(int port)
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
				if (!m_TransactionStarted)
				{
					if (!m_IsServer)
					{
						m_Command = data.Split(' ')[0];
					}
					else if (m_Command.Equals("RETR"))
					{
						//data sending starts after server send 354 code
						try
						{
							m_ServerAnswer = data.Split(' ')[0].Replace("\r\n", "");
							if (m_ServerAnswer.Equals("+OK"))
							{
								mask |= (int)EventMask.TransactionStarted;
								m_TransactionStarted = true;
							}
						}
						catch (Exception) { }
						return mask;
					}
					if (!m_TransactionStarted)
					{
						return mask;
					}
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
			else if(m_IsServer)
			{
				m_DataSb.Append(data);
			}
			return processData(mask, ref content);
		}
	}
}
