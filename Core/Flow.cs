using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Nemo.Core
{
    public enum TransportProtocol { UDP, TCP};
    public enum ApplicationProtocol { FTP, POP };

    public class Flow
	{
		#region Private Properties
		//время начала потока
        private System.DateTime _StartTime = DateTime.MinValue;
		//дата начала потока
        private System.DateTime _StartDate = DateTime.MinValue;
		//время окончания потока
        private System.DateTime _EndTime = DateTime.MinValue;
		//IP источника
        private IPAddress _IpA = IPAddress.None;
		//имя источника. может быть пустым
        private string _NameA = string.Empty;
		//порт источника
        private ushort _PortA = 0;
		//флаг, указывающий локален ли источник
        private bool _IsLocalA = false;
		//IP назначения
        private IPAddress _IpB = IPAddress.None;
		//имя назначения
        private string _NameB = string.Empty;
		//порт назначения
        private ushort _PortB  = 0;
		//флаг, указывающий локален ли получатель
        private bool _IsLocalB = false;
		//протокол транспортного уровня
        private TransportProtocol _TransportProto = 0;
		//протокол уровня приложений
        private string _ApplicationProto = string.Empty;
		//кол-во пакетов от исчтоника
        private uint _PacketsAB = 0;
		//кол-во байт от источника
        private ulong _BytesAB = 0;
		//кол-во пакетов от получателя
        private uint _PacketsBA = 0;
		//кол-во байт от получателя
        private ulong _BytesBA = 0;
		#endregion

		#region Public Properties

        public System.DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
        }
        public System.DateTime StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                if ((this._StartTime != value))
                {
                    this._StartDate = value.Subtract(value.TimeOfDay);
                    this._StartTime = value;
                    this._EndTime = value;
                }
            }
        }
        public System.DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                if ((this._EndTime != value))
                {
                    this._EndTime = value;
                }
            }
        }

        public TimeSpan Length
        {
            get
            {
                return this._EndTime - this._StartTime;
            }
        }

        public IPAddress IpA
        {
            get
            {
                return this._IpA;
            }
            set
            {
                if ((this._IpA != value))
                {
                    this._IpA = value;
                }
            }
        }

        public string NameA
        {
            get
            {
                return this._NameA;
            }
            set
            {
                if ((this._NameA != value))
                {
                    this._NameA = value;
                }
            }
        }

        public string NameB
        {
            get
            {
                return this._NameB;
            }
            set
            {
                if ((this._NameB != value))
                {
                    this._NameB = value;
                }
            }
        }

        public ushort PortA
        {
            get
            {
                return this._PortA;
            }
            set
            {
                if ((this._PortA != value))
                {
                    this._PortA = value;
                }
            }
        }

        public bool IsLocalA
        {
            get
            {
                return this._IsLocalA;
            }
            set
            {
                if ((this._IsLocalA != value))
                {
                    this._IsLocalA = value;
                }
            }
        }

        public bool IsLocalB
        {
            get
            {
                return this._IsLocalB;
            }
            set
            {
                if ((this._IsLocalB != value))
                {
                    this._IsLocalB = value;
                }
            }
        }

        public IPAddress IpB
        {
            get
            {
                return this._IpB;
            }
            set
            {
                if ((this._IpB != value))
                {
                    this._IpB = value;
                }
            }
        }
        public ushort PortB
        {
            get
            {
                return this._PortB;
            }
            set
            {
                if ((this._PortB != value))
                {
                    this._PortB = value;
                }
            }
        }
        public TransportProtocol TransportProto
        {
            get
            {
                return this._TransportProto;
            }
            set
            {
                if ((this._TransportProto != value))
                {                    
                    this._TransportProto = value;
                }
            }
        }
        public string ApplicationProto
        {
            get
            {
                return this._ApplicationProto;
            }
            set
            {
                if ((this._ApplicationProto != value))
                {                    
                    this._ApplicationProto = value;
                }
            }
        }
        public uint PacketsAB
        {
            get
            {
                return this._PacketsAB;
            }
            set
            {
                if ((this._PacketsAB != value))
                {
                    this._PacketsAB = value;
                }
            }
        }
        public ulong BytesAB
        {
            get
            {
                return this._BytesAB;
            }
            set
            {
                if ((this._BytesAB != value))
                {
                    this._BytesAB = value;
                }
            }
        }
        public uint PacketsBA
        {
            get
            {
                return this._PacketsBA;
            }
            set
            {
                if ((this._PacketsBA != value))
                {
                    this._PacketsBA = value;
                }
            }
        }
        public ulong BytesBA
        {
            get
            {
                return this._BytesBA;
            }
            set
            {
                if ((this._BytesBA != value))
                {
                    this._BytesBA = value;
                }
            }
		}
		#endregion

        #region Constructor
        public Flow() { }
        public Flow(IPAddress ip1, ushort port1, IPAddress ip2, ushort port2, TransportProtocol proto) 
        {
            _PacketsAB = 1;
            _IpA = ip1;
            _IpB = ip2;
            _PortA = port1;
            _PortB = port2;
            _TransportProto = proto;

        }
        #endregion

        #region Public Methods
        public bool MatchFlow(IPAddress ip1, ushort port1, IPAddress ip2, ushort port2, uint bytes)
        {
            if(ip1.Equals(_IpA) && port1 == _PortA &&  ip2.Equals(_IpB) && port2 == _PortB)
            {
                _BytesAB += bytes;
                _PacketsAB++;
                return true;
            }
            else if (ip2.Equals(_IpA) && port2 == _PortA && ip1.Equals(_IpB) && port1 == _PortB)
            {
                _BytesBA += bytes;
                _PacketsBA++;
                return true;
            }
            return false;
        }

        public bool MatchIPs(Flow flow)
        {
            if (flow.IpA.Equals(_IpA) && flow.IpB.Equals(_IpB))
            {
                return true;
            }
            else if (flow.IpB.Equals(_IpA) && flow.IpA.Equals(_IpB))
            {
                return true;
            }
            return false;
        }

        public bool MergeFlow(Flow anotherFlow)
        {
            if (!anotherFlow.StartDate.Equals(_StartDate))
                return false;

            bool result = false;
            if (anotherFlow._IpA.Equals(_IpA) && 
				anotherFlow._PortA == _PortA  &&
                anotherFlow._IpB.Equals(_IpB) && 
				anotherFlow._PortB == _PortB)
            {
               
                _BytesAB += anotherFlow._BytesAB;
                _BytesBA += anotherFlow._BytesBA;
                _PacketsAB += anotherFlow._PacketsAB;
                _PacketsBA += anotherFlow._PacketsBA;
                result = true;
            }
            else if(anotherFlow._IpB.Equals(_IpA) && 
				    anotherFlow._PortB == _PortA &&
                    anotherFlow._IpA.Equals(_IpB) && 
				    anotherFlow._PortA == _PortB)
            {
                _BytesAB += anotherFlow._BytesBA;
                _BytesBA += anotherFlow._BytesAB;
                _PacketsAB += anotherFlow._PacketsBA;
                _PacketsBA += anotherFlow._PacketsAB;
                result = true;
            }
            if (result && _EndTime.CompareTo(anotherFlow.EndTime) < 0)
            {
                _EndTime = anotherFlow.EndTime;
            }
            return result;
        }
        #endregion
    }
}
