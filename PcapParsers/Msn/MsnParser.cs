using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPExplorer.Utils;
using System.Text.RegularExpressions;

namespace IPExplorer.PcapParsers
{
    class MsnTransaction
    {
        private string _Cookie = string.Empty;
        private string _File = string.Empty;
        private string _size = string.Empty;

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string Cookie
        {
            get
            {
                return this._Cookie;
            }
            set
            {
                if ((this._Cookie != value))
                {
                    this._Cookie = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return this._File;
            }
            set
            {
                if ((this._File != value))
                {
                    this._File = value;
                }
            }
        }
    }
	class MsnParser : ChatParser
	{
		#region Static Properties
		private static string _infoCmd = "IRO";
		private static string _msgCmd = "MSG";
		private static string _outCmd = "OUT";
		private static string _userCmd = "USR";
		private static string _answerCmd = "ANS";
		private static string _joinCmd = "JOI";
		private static string _byeCmd = "BYE";
		#endregion

		#region Private Properties
        private List<MsnTransaction> MsnFiles = new List<MsnTransaction>();
		#endregion

		#region Costructor
		//MSN Parser.
		//By now parses msn data to obtain users dialog
		public MsnParser(int port) : base(port)	{}
		#endregion

		#region Parsing Methods
		//parse msn data. Client or server
		//obtains command and cat them from data
		override protected int parse(ref string data, ref StringBuilder content)
		{
			int mask = (int)EventMask.None;
			Match reg;
			while (!string.IsNullOrEmpty(data))
			{
				//examine if there are any ready command lines in the buffer
				reg = Regex.Match(data, @"(.+)\r\n(.*)");
				if (!reg.Success)
					break;
				//1st packet must be
				//ANS - on session inviting
				//USR - on session creating
				//also we can obtain user name from this commands
				if (_isFirstPacket)
				{
					_isFirstPacket = false;
					if (data.StartsWith(_userCmd))
					{
						addServiceHistory("Session started", ref content);
						getUserNameFromCmd(reg.Groups[1].Value);
						data = reg.Groups[2].Value;
						continue;
					}
					else if (data.StartsWith(_answerCmd))
					{
						addServiceHistory("You was invited into the session", ref content);
						getUserNameFromCmd(reg.Groups[1].Value);
						data = reg.Groups[2].Value;
						continue;
					}
				}
				//on abonents info command
				if (data.StartsWith(_infoCmd))
				{
					parseInfoCmd(reg.Groups[1].Value, ref content);
					data = reg.Groups[2].Value;	
				}
				else if (data.StartsWith(_joinCmd))
				{
					parseJoinCmd(reg.Groups[1].Value, ref content);
					data = reg.Groups[2].Value;	
				}
				//on out(close)  command
				else if (data.StartsWith(_outCmd) || data.StartsWith(_byeCmd))
				{
					addServiceHistory("Session closed", ref content);
					mask |= finish(ref content);
					break;
				}
				//on message command
				else if (data.StartsWith(_msgCmd))
				{
					if (!parseMsgCmd(ref data, ref content))
						break;
				}
				//on other commands
				else
				{
					//just delete command from buffer
					data = reg.Groups[2].Value;
				}
			}
			return mask;
		}

		//parse MSG command
		//returns true if command succesfully parsed(complete)
		private bool parseMsgCmd(ref string data, ref StringBuilder content)
		{
			bool result = false;
			//in format:
			//MSG <user_mail> <user_nick> <length>
			//out format:
			//MSG <TrID> <ACK_TYPE> <length>\r\n<HEADERS>\r\n\r\n<message>
			//Match reg = Regex.Match(data, @"MSG (.+) (.+) (\d+)\r\n(.+)\r\n\r\n(.+)");
			string line = data.Substring(0, data.IndexOf("\r\n") + 2);
			data = data.Substring(line.Length);
			Match reg = Regex.Match(line, @"MSG (.+) (.+) (\d+)\r\n");
			//if msg match valid format
			if (reg.Success)
			{
				//obtain msg len
				int len = Int32.Parse(reg.Groups[3].Value);
				if (len == 0)
				{
					result = true;
				}
				//verify that msg is not empty and all msg bytes came
				else if (len >= data.Length)
				{
					//obtain ContentType from header
					string headers = data.Substring(0, data.IndexOf(m_HeadersEnd) + 4);
					string contentType = getHeader(ref headers, "Content-Type:");
					string msgUser = (m_IsServer) ? reg.Groups[1].Value + " (" + reg.Groups[2].Value + ')' : null;
					//store only text/plain message
					if (contentType.Contains("text/plain"))
					{
						_msgNum++;
						//get user name.
						addMsgHistory(msgUser, data.Substring(headers.Length, len - headers.Length), ref content);
					}
                    else if (contentType.Contains("text/x-msmsgsinvite"))
					{
						parseMsgInviteCmd(data.Substring(headers.Length, len - headers.Length), ref content);
					}
					//update data like cutting the msg cmd from it
					data = (len > data.Length) ? data.Substring(len) : string.Empty;
					result = true;
				}
			}
			return result;
		}

		//parse IRO commands to add abonent into content
		//also fills _abonents list
		private void parseInfoCmd(string line, ref StringBuilder content)
		{
			//IRO 1 1 2 example@passport.com Mike
			Match reg = Regex.Match(line, @"IRO \d+ \d+ \d+ (\S+) (\S+)");
			string abon = reg.Groups[1].Value; 
			//add abonent into the abonent list if it's not here yet
			if (!_abonents.Contains(abon))
			{
				_abonents.Add(abon);
			}
			abon += " (" + reg.Groups[2].Value + ')';
			addInSessionUserHistory("Session user", abon, ref content);
			_msgNum++;
		}

		private void parseJoinCmd(string line, ref StringBuilder content)
		{
			//JOI name_123@hotmail.com Name_123\r\n
			Match reg = Regex.Match(line, @"JOI (\S+) (\S+)");
			string abon = reg.Groups[1].Value;
			//add abonent into the abonent list if it's not here yet
			if (!_abonents.Contains(abon))
			{
				_abonents.Add(abon);
			}
			abon += " (" + reg.Groups[2].Value + ')';
			_msgNum++;
		}
		
		//obtain user mail address from USR or ANS commands
		private void getUserNameFromCmd(string line)
		{
			Match reg = Regex.Match(line, @".+ \d+ (\S+) .+");
			_user = reg.Groups[1].Value;
		}

		private void parseMsgInviteCmd(string data, ref StringBuilder content)
		{
			string headers = data.Substring(0, data.IndexOf(m_HeadersEnd) + 4);
            MsnTransaction msnfile = new MsnTransaction();
            msnfile.Cookie = getHeader(ref headers, "Invitation-Cookie:");
            msnfile.Name = getHeader(ref headers, "Application-File:");
            if (!string.IsNullOrEmpty(msnfile.Name) && 
                getHeader(ref headers, "Invitation-Command:").Contains("INVITE"))
            {
                msnfile.Name = getHeader(ref headers, "Application-File:");
                msnfile.Size = getHeader(ref headers, "Application-FileSize:").Trim(); 
                MsnFiles.Add(msnfile);
            }            
            else if (getHeader(ref headers, "Invitation-Command:").Contains("ACCEPT"))
            {
                for (int i = 0; i < MsnFiles.Count; i++)
                {
                    if (MsnFiles[i].Cookie.Equals(msnfile.Cookie))
                    {
                        addFileTransferHistory("Sending file",_user, MsnFiles[i].Name,
                            MsnFiles[i].Size, ref content);
                        MsnFiles.RemoveAt(i);
						_msgNum++;
                        break;
                    }
                }                
            }
            else if (getHeader(ref headers, "Invitation-Command:").Contains("CANCEL"))
            {
                for (int i = 0; i < MsnFiles.Count; i++)
                {
                    if (MsnFiles[i].Cookie.Equals(msnfile.Cookie))
                    {
                        addFileTransferHistory("Sending file cancelled", _user, MsnFiles[i].Name,
                            MsnFiles[i].Size, ref content);
                        MsnFiles.RemoveAt(i);
						_msgNum++;
                        break;
                    }
                }               
            }
		}

		#endregion
	}
}
