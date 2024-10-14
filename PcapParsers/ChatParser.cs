using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPExplorer.Utils;
using System.Text.RegularExpressions;

namespace IPExplorer.PcapParsers
{
	//base calss for all chat session
	class ChatParser : DataParser
	{
		#region Static Properties

		#endregion

		#region Protected Properties
		//buffers for store data for parsing
		//buffer for client data
		protected string _clientBuffer = string.Empty;
		//buffer for server data
		protected string _serverBuffer = string.Empty;
		protected string _user = string.Empty;
		//full message number of current session
		protected int _msgNum = 0;
		//packet time for history writing
		protected string _time;
		protected bool _isFirstPacket;
		//list of abonents
		protected List<string> _abonents;
		#endregion

		#region Public Properties
		public string User
		{
			get { return _user; }
		}
		
		public int MsgNum
		{
			get { return _msgNum; }
		}
		
		public List<string> Abonents
		{
			get { return _abonents; }
		}

		public TimeSpan Time
		{
			set
			{
				_time = value.ToString();
				_time = _time.Substring(0, _time.LastIndexOf('.'));
			}
		}
		#endregion

		#region Costructor
		//Chat Parser.
		//By now parses msn data to obtain users dialog
		public ChatParser(int port)
		{
			_abonents = new List<string>();
			m_Port = port;
			_isFirstPacket = true;
		}
		#endregion

		#region Public Methods
		override public int finish(ref StringBuilder content)
		{
			int mask = (int)EventMask.TransactionFinished;
			_serverBuffer = string.Empty;
			_clientBuffer = string.Empty;
			if (content.Length == 0)
			{
				addEmptySessionHistory(ref content);
			}
			return mask;
		}

		override public int parseData(ref string data, ref StringBuilder content)
		{
			if (m_IsServer)
			{
				_serverBuffer += data;
				return parse(ref _serverBuffer, ref content);
			}
			else
			{
				_clientBuffer += data;
				return parse(ref _clientBuffer, ref content);
			}
		}
		#endregion

		#region Parsing Methods
		//parse msn data. Client or server
		//obtains command and cat them from data
		virtual protected int parse(ref string data, ref StringBuilder content)
		{
			return 0;
		}

		#endregion

		#region History Formatting Methods
		protected void addServiceHistory(string msg, ref StringBuilder content)
		{
			content.Append(string.Format("{0} <font color='blue'><kbd>{1}</kbd></font><br>", _time, msg));
		}

		protected void addMsgHistory(string user, string msg, ref StringBuilder content)
		{
			content.Append((user == null) ?
				string.Format("{0} <font color='red'>*</font> <kbd>you</kbd> -- <b>{1}</b><br>", _time, msg) :
				string.Format("{0} <font color='green'>*</font> <kbd>{1}</kbd> -- <b>{2}</b><br>", _time, user, msg));
		}

		protected void addEmptySessionHistory(ref StringBuilder content)
		{
			content.Append("<font color='red'>Session is empty</font>");
		}

		protected void addInSessionUserHistory(string msg, string user, ref StringBuilder content)
		{
			content.Append(String.Format(
				"{0} <font color='blue'><kbd>{1}: </kbd></font><font color='green'>* </font>{2}<br>",
				_time, msg, user));
		}
		protected void addFileTransferHistory(string title, string user, string file, string size, ref StringBuilder content)
		{
			content.Append((user == null) ?
				string.Format("{0} <font color='blue'><kbd>{1}. </kbd></font> User: <kbd><font color='red'>" +
				"*</font>you</kbd>, file: <b>{2}</b>, size: {3}<br>",
					_time, title, file, size) :
				string.Format("{0} <font color='blue'><kbd>{1}. </kbd></font> User: <kbd><font color='green'>" +
				"*</font>{2}</kbd> file: <b>{3}</b> size: {4}<br>", _time, title, user, file, size));
		}
		#endregion

	}
}
