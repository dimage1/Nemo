using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPExplorer.Utils;

namespace IPExplorer.PcapParsers
{
	class HttpParser : DataParser
	{
		private bool m_IsChunked;
		public bool m_IsPost { get; set; }
		// size of http content
		private long m_Size;
		public string m_PostContent{ get; set; }
		private int m_ChunkSize;
		private short m_ServerCode;
		private int m_HeadersSize;

		public static ExcludedFields Fields { get;  set; }
				
		public HttpParser(int port)
		{
			m_Port = port;
			m_HeadersParsed = false;
			m_PostContent = string.Empty;
			m_IsChunked = false;
			m_ChunkSize = -1;
			m_ServerCode = 0;
			m_Data = string.Empty;
		}

		override public int finish(ref StringBuilder content)
		{
			return (int)EventMask.TransactionFinished;
		}

		override public int parseData(ref string data, ref StringBuilder content)
		{
			int mask = (int)EventMask.None;
			if (!m_HeadersParsed)
			{
				if (m_Data.Length == 0 && !data.StartsWith("GET") && !data.StartsWith("POST") &&
					!data.StartsWith("HTTP"))
				{
					return mask;
				}
				m_Data += data;
				//wait until all headers came!
				if (m_Data.ToString().IndexOf(m_HeadersEnd) > -1)
				{
					data = m_Data.ToString();
					m_Data = string.Empty;
				}
				else
				{
					return mask;
				}
				if (data.StartsWith("GET") || data.StartsWith("POST"))
				{
					parseRequest(data);
				}
				if (data.StartsWith("HTTP"))
				{
					parseResponse(data);
				}
				else if (!m_IsPost)
				{
					return mask;
				}
				content.Append(data);
				data = parseHeaders(data);
				if (m_IsChunked && m_Size > 0xFFFFFFF)
				{
					processChunkedData(data);
				}
				mask |= (int)EventMask.TransactionStarted;
			}
			else
			{
				content.Append(data);
				//process chunked data if no size in header
				if (m_IsChunked && m_Size > 0xFFFFFFF)
				{
					processChunkedData(data);
				}
			}
			if (m_IsPost && string.IsNullOrEmpty(m_PostContent))
			{
				//don't store large posts
				m_PostContent = (data.Length > 512) ? data.Substring(0, 512) : data;
			}
			if ((m_Size <= content.Length - m_HeadersSize) || 
				(m_IsChunked && m_ChunkSize == 0 && m_Size > 0xFFFFFFF))
			{
				if (!m_IsPost)
				{
					mask |= finish(ref content);
				}
				else
				{
					content.Length = 0;
					m_IsPost = false;
					m_HeadersParsed = false;
				}
			}
			if (m_ServerCode == 304 || m_ServerCode == 204)
			{
				mask |= finish(ref content);
			}
			return mask;
			
		}

		private string parseHeaders(string data)
		{
			int headersEnd = data.IndexOf(m_HeadersEnd);
			m_HeadersParsed = true;
			m_HeadersSize = headersEnd + 4;
			// obtain headers part from data
			string headers = data.Substring(0, headersEnd + 4);
			// get content length to find when transaction would finished
			string length = getHeader(ref headers, "Content-Length: ");
			m_Size = (!string.IsNullOrEmpty(length)) ? Int64.Parse(length) : m_Size = 0xEFFFFFFFF;
			m_IsChunked = (headers.IndexOf("chunked") >= 0);
			return data.Substring(headersEnd + 4);
		}

		//parse request to find host and path 
		private void parseRequest(string data)
		{
			string []firstSplit = data.Substring(0, data.IndexOf("\r\n")).Split(' ');
			m_IsPost = firstSplit[0].Equals("POST");
		}

		//parse response to server code 
		private void parseResponse(string data)
		{
			string firstString = data.Substring(0, data.IndexOf("\r\n"));
			m_ServerCode = Int16.Parse((firstString.Split(' ')[1]));
		}

		private void processChunkedData(string data)
		{
			int sizeEnd;
			do
			{
				sizeEnd = 0;
				if (m_ChunkSize == -1)
				{
					sizeEnd = data.IndexOf('\r');
					try
					{
						m_ChunkSize = Int32.Parse(data.Substring(0, sizeEnd),
							System.Globalization.NumberStyles.HexNumber);
						// do not take \r\n symbols
						sizeEnd += 2;
					}
					catch (Exception)
					{
						return;
					}
				}
				if (m_ChunkSize == 0)
				{
					return;
				}
				if (data.Length < sizeEnd + m_ChunkSize + 2)
				{
					m_ChunkSize -= data.Length - sizeEnd;
					return;
				}
				data = data.Substring(sizeEnd + 2 + m_ChunkSize);
				m_ChunkSize = -1;
			}
			while(true);
		}
	}
}
