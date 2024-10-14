using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPExplorer.PcapParsers
{
	// parsing events
	enum EventMask
	{ 
		None				= 0, 
		Error				= 1, 
		TransactionStarted  = 2,
		TransactionFinished = 4
	};

	abstract class DataParser
	{
		public const string m_HeadersEnd = "\r\n\r\n";
		
		protected bool m_HeadersParsed = false;
		//cumulative data. accumulate while headers is not parsed
		protected String m_Data;
		public int m_Port { get; set; }
		// is server answer?
		public bool m_IsServer { get; set; }


		abstract public int parseData(ref string data, ref StringBuilder content);
		public static string getHeader(ref string data, string headerName)
		{
			int start;
			if((start = data.IndexOf(headerName)) < 0)
			{
				return string.Empty;
			}
			start += headerName.Length;
			int size = data.Substring(start).IndexOf("\r\n");
			return (size > -1) ? data.Substring(start, size) : data.Substring(start);
		}

		abstract public int finish(ref StringBuilder content);
	}
}
