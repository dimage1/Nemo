using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Nemo.Core
{
    public class Flows
    {
		//список потоков
        public List<Flow> _Flows;
		//карта протоколов
        public static Dictionary<uint, string> ServiceMap;

        public Flows()
        {
            _Flows = new List<Flow>();
        }

        public bool MergeFlow(Flow flow)
        {
            bool flowFound = false;
            for (int i = _Flows.Count - 1; i >= 0; i--)
            {
                if (_Flows[i].MergeFlow(flow))
                {
                    flowFound = true;
                    break;
                }
            }
            //если сответствующий поток не найдем 
			//- создаем новый
            if (!flowFound)
            {
                try
                {
                    flow.ApplicationProto = ServiceMap[flow.PortA];
                }
                catch
                {
                    try
                    {
                        flow.ApplicationProto = ServiceMap[flow.PortB];
                    }
                    catch 
                    {
                        flow.ApplicationProto = "N/A";
                    }
                }
                _Flows.Add(flow);
            }
            return flowFound;
        }

        //returns new flow count
        public int MergeFlows(Flows flows)
        {
            return MergeFlows(flows._Flows);
        }

        public int MergeFlows(List<Flow> flows)
        {
            int result = 0;
            for (int i = flows.Count - 1; i >= 0; i--)
            {
                if (MergeFlow(flows[i]))
                {
                    result++;
                }
            }
            return result;
        }

        //delete flow m atching specified
        //return true if flow found
        public bool DeleteFlow(Flow flow)
        {
            if(flow == null)
                return false;
            foreach(Flow fl in _Flows)
            {
                if (fl.PortA == flow.PortA && fl.PortB == fl.PortB &&
                    fl.IpA.Equals(flow.IpA) && fl.IpB.Equals(flow.IpB) &&
                    fl.StartTime.Equals(flow.StartTime))
                {
                    _Flows.Remove(fl);
                    return true;
                }
            }
            return false;
        }

        //возвращает список всех доступных IP
        public List<string> getIPs()
        {
            List<string> res = new List<string>();
            string ip;
            foreach(Flow flow in _Flows)
            {
                ip = flow.IpA.ToString();
                if(!res.Contains(ip))
                {
                    res.Add(ip);    
                }
                ip = flow.IpB.ToString();
                if (!res.Contains(ip))
                {
                    res.Add(ip);
                }
            }
            return res;
        }

        public Flow[] GetFlowsByDate(DateTime start, DateTime end)
        {
            return (
                from f in _Flows
                where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0
                orderby f.StartTime
                select f).ToArray();
        }

        public Flow[] GetFlowsBySrcAddress(IPAddress ip, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && 
					f.StartTime.CompareTo(end) <= 0 &&  f.IpA.Equals(ip)
                    orderby f.StartTime
                    select f).ToArray();
        }

        public Flow[] GetFlowsByDstAddress(IPAddress ip, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.IpB.Equals(ip)
                    orderby f.StartTime
                    select f).ToArray();
        }

        public Flow[] GetFlowsBySrcName(string name, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.NameA.Equals(name)
                    orderby f.StartTime
                    select f).ToArray();
        }

public Flow[] GetFlowsByDstName(string name, 
    DateTime start, DateTime end)
{
    return (from f in _Flows
            where f.StartTime.CompareTo(start) >= 0 && 
			      f.StartTime.CompareTo(end) <= 0 &&
                  f.NameB.Equals(name)
            orderby f.StartTime
            select f).ToArray();
}

        public Flow[] GetFlowsBySrcPort(ushort port, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.PortA == port
                    orderby f.StartTime
                    select f).ToArray();
        }

        public Flow[] GetFlowsByDstPort(ushort port, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.PortB == port
                    orderby f.StartTime
                    select f).ToArray();
        }

        public Flow[] GetFlowsBySize(uint minSize, uint maxSize, DateTime start, DateTime end)
        {
            Flow[] flows =
                (from f in _Flows
                 where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                    (f.BytesAB + f.BytesBA > minSize)
                 orderby f.StartTime
                 select f).ToArray();

            return (maxSize == 0) ?
                flows  : 
                (from f in flows
                 where f.BytesAB + f.BytesBA <= maxSize
                 select f).ToArray();
        }

        public Flow[] GetFlowsByLength(TimeSpan min, TimeSpan max, DateTime start, DateTime end)
        {
            Flow[] flows = 
                (from f in _Flows
                 where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 
                 orderby  f.StartTime
                 select f).ToArray();
            flows =  (min.TotalMinutes == 0) ? 
                flows :
                (from f in flows
                 where f.Length.TotalSeconds > min.TotalSeconds
                 select f).ToArray();

            return (max.TotalMinutes == 0) ?
                flows :
                (from f in flows
                 where f.Length.CompareTo(max) <= 0
                 select f).ToArray();
        }

        public Flow[] GetFlowsBySrcPortAndTransport(ushort port, TransportProtocol proto, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.PortA == port && f.TransportProto == proto
                    orderby f.StartTime
                    select f).ToArray();
        }

        public Flow[] GetFlowsByDstPortAndTransport(ushort port, TransportProtocol proto, DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.PortB == port && f.TransportProto == proto
                    orderby f.StartTime
                    select f).ToArray();
        }

        public Flow[] GetFlowsByService(string service,  DateTime start, DateTime end)
        {
            return (from f in _Flows
                    where f.StartTime.CompareTo(start) >= 0 && f.StartTime.CompareTo(end) <= 0 &&
                          f.ApplicationProto.Equals(service)
                    orderby f.StartTime
                    select f).ToArray();
        }
    }
}
