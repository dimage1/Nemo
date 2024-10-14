using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPExplorer.PcapParsers;

namespace IPExplorer.PcapParsers
{
    class MsnFtpParser : DataParser
    {
        private bool _parse  = false;
        private int _length = 0;
        private string _header = string.Empty;
        private int _needHeader = 0;
        private int y = 0;
       
        public MsnFtpParser(int port)
		{
			m_Port = port;
		}

        override public int finish(ref StringBuilder content)
        {
            return (int)EventMask.TransactionFinished;            
        }

        override public int parseData(ref string data, ref StringBuilder content)
        {
            //start transfer command
			if (data.StartsWith("TFR"))
            {
                _parse = true;                    
            }            
            else if (data.StartsWith("BYE") || data.StartsWith("CCL"))
            {
                _parse = false;
            }
            else if (_parse)
            {
                parseBlock (0, ref data, ref content);
            }
            return (int)EventMask.None;                
        }

        private void parseBlock(int pos, ref string data, ref StringBuilder content)
        {
            //3 - length of header abc: 
			//a - code(0 - has more data, 1 - no data)
			//b + 256 * c = block length
			if (_header.Length < 3)
            {
                _needHeader = 3 - _header.Length;
                if (data.Length - pos > _needHeader)
                {
                    _header += data.Substring(pos, _needHeader);
                    pos += _needHeader;
                    //obtain block length
					_length = _header[1] + 256 * _header[2];
                }
                else
                {
                    _header += data.Substring(pos);
                    return;
                }
            }
            if (_length > data.Length - pos)
            {
                _length -= data.Length - pos;
                content.Append(data.Substring(pos));
                return;
            }
            else
            {
                _header = string.Empty;
                content.Append(data.Substring(pos, _length));
                pos += _length;
                parseBlock(pos, ref data, ref content);
            }
        }
         
    }
}
