using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
namespace IPExplorer.PcapParsers
{
	struct Attachment
	{
		public string name;
		public string encoding;
		public int from;
		public int size;
	}

	class MailParser : DataParser
	{
		protected List<Attachment> m_Attachments;
		protected string m_Boundary = string.Empty;
		protected StringBuilder m_DataSb;
		
		public List<Attachment> Attachments
		{
			get { return m_Attachments; }
		}

		//converts quoted printable string to user readable string
		//TODO: must convert string to current user system encoding
		public static string ConvertFromQuotedPrint(string line)
		{
			Match reg;
			UTF8Encoding utf8 = new UTF8Encoding();
			Encoding enc;
			StringBuilder fline = new StringBuilder();
			do
			{
				//obtain reg data from line
				reg = Regex.Match(line, @"^=\?(.*)\?(.*)\?(.*)\?=(.*)");
				line = (reg.Groups[4] == null) ? null : reg.Groups[4].Value;
				//obtain encoding from line
				enc = Encoding.GetEncoding((string.IsNullOrEmpty(reg.Groups[1].ToString())) ? "utf8" : reg.Groups[1].ToString());
				//convert to base64 if needed
				if (reg.Groups[2].Equals("B"))
				{
					byte[] bytes = System.Convert.FromBase64String(reg.Groups[3].ToString());
					fline.Append(new String(bytes.Cast<char>().ToArray()));
				}
				else
				{
					//TODO: incorrect parsing. fix this,
					//		also must be replaced into the IPE Client
					fline.Append(enc.GetString(Encoding.Convert(utf8, enc,
						reg.Groups[3].ToString().ToCharArray().Cast<byte>().ToArray())));
				}

			}
			while (line != null);
			return fline.ToString();
		}

		public override int parseData(ref string data, ref StringBuilder content)
		{
			throw new NotImplementedException();
		}

		override public int finish(ref StringBuilder content)
		{
			content = m_DataSb;
			m_Data = string.Empty;
			if (!string.IsNullOrEmpty(m_Boundary))
			{
				processAttachments(content.ToString());
			}
			return (int)EventMask.TransactionFinished;
		}

		protected void processHeader(ref string data)
		{
			m_Boundary	= getHeader(ref data, "boundary=").Replace("\"", "");
		}

		protected int processData(int mask, ref StringBuilder content)
		{
			int size = m_DataSb.Length;
			if (size > 5 &&
				((m_DataSb[size - 1] == '\n' && m_DataSb[size - 2] == '\r' && m_DataSb[size - 3] == '.' &&
				m_DataSb[size - 4] == '\n' && m_DataSb[size - 5] == '\r') ||
				(m_DataSb[size - 2] == '\n' && m_DataSb[size - 3] == '\r' && m_DataSb[size - 4] == '.' &&
				m_DataSb[size - 5] == '\n' && m_DataSb[size - 6] == '\r')))
			{
				mask |= finish(ref content);
			}
			return mask;
		}

		protected void processAttachments(string data)
		{
			string bound = "\r\n--" + m_Boundary;
			//attachment header
			string header;
			string disposition;
			string name;
			int tmp;
			int start;
			int offset = 0;
			int ind;
			bool end = false;

			//find attachments until boundary can be found
			while ((start = data.IndexOf(bound)) > -1)
			{
				ind = start + bound.Length;
				offset += ind;
				data = data.Substring(ind);
				try
				{
					header = data.Substring(0, data.IndexOf("\r\n\r\n"));
				}
				catch
				{
					return;
				}
				ind = header.Length + 4;
				data = data.Substring(ind);
				//now offset - beginning of attachment data
				offset += ind;
				//ind - length of attachment data
				try
				{
					ind = data.IndexOf(bound);
					data = data.Substring(ind);
					//multipart ends only if bound + "--" came
					if (data.StartsWith(bound + "--"))
					{
						end = true;
					}
				}
				catch 
				{
					ind = data.Length;
					end = true;
				}
				//some mail agents distinct fields in one header by \r\n\t -
				//we replace it with ' ' to parse header as 1 string
				header = header.Replace("\r\n\t", " ");
				disposition = getHeader(ref header, "Content-Disposition: ");
				if(!disposition.Contains("attachment") ||
					string.IsNullOrEmpty(name = getHeader(ref disposition, "filename=").Replace("\"", "")))
				{
					offset += ind;
					if(end)
					{
						return;
					}
					else
					{
						continue;
					}
				}
				Attachment	attch;
				attch.from = offset;
				attch.size = ind;

				if ((tmp = name.IndexOf(';')) > -1)
				{
					name = name.Substring(0, tmp);
				}
				attch.name = name;
				offset += ind;
				header = header.ToLower();
				attch.encoding = getHeader(ref header, "content-transfer-encoding: ");
				m_Attachments.Add(attch);
				if (end)
				{
					return;
				}
			}
		}
	}
}
