using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;

namespace Nemo.Core
{
    public class CustomFilter
    {
        public string Name;
        public string Text;
        public object Obj;
        public bool Notify = false;

        public CustomFilter(){}
        public CustomFilter(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public CustomFilter(string name, string text, object obj)
        {
            Name = name;
            Text = text;
            Obj  = obj;
        }
    }

    public class DynamicFilter
    {
        private string _errorMsg;
        public static string WorkingDir = string.Empty;
        private List<CustomFilter> _filters;
        private object _obj;
        private string _text;

        public string ErrorMsg
        {
            get { return _errorMsg; }
        }

        public DynamicFilter()
        {
            _filters = new List<CustomFilter>();
        }

        public string Help
        {
            get
            {
                return string.Empty;
            }
        }

        public List<string> FilterNames
        {
            get
            {
                List<string> res = new List<string>();
                foreach (CustomFilter fil in _filters)
                {
                    res.Add(fil.Name);
                }
                return res;
            }
        }

        public bool BuildFilter(string ufilter)
        {
            string filter = prepareFilterString(ufilter);
            if (string.IsNullOrEmpty(filter))
            {
                _obj = null;
                _text = filter;
                return true;
            }
            CompilerParameters loParameters = new CompilerParameters();
            loParameters.ReferencedAssemblies.Add("System.dll");
            loParameters.ReferencedAssemblies.Add(WorkingDir + "\\Nemo.Core.dll");
            string lcCode = 
                @"using System;
                using System.Collections.Generic;
                using Nemo.Core;
                using System.Net;

                namespace Nemo.Dynamic
                {
                    public class FilterDynamic
                    {
                        public bool MatchFilter(Flow flow)
                        {
                           try
                           {
                               return (" + filter + @");
                           }
                           catch{return false;}
                        }

                        public Flow[] FilterFlows(List<Flow> flows, 
                                    DateTime start, DateTime end)
                        {
                           List<Flow> res = new List<Flow>();
                            foreach(Flow flow in flows)
                            {
                                try
                                {
                                    if((" + filter + @") && 
                                        flow.StartTime.CompareTo(start) >= 0 && 
                                        flow.EndTime.CompareTo(end) < 0)
                                    {
                                        res.Add(flow);
                                    }
                                }
                                catch{}
                            }
                            return res.ToArray();
                        }    
                    }    
                }";
            // загружаем код в память
            loParameters.GenerateInMemory = true;
            loParameters.IncludeDebugInformation = true;
            // компилируем код
            CompilerResults loCompiled = CSharpCodeProvider.
                CreateProvider("CSharp").CompileAssemblyFromSource(loParameters, lcCode);
            if (loCompiled.Errors.HasErrors)
            {
                _errorMsg = "Failed to compile filter";
                return false;
            }
            Assembly loAssembly = loCompiled.CompiledAssembly;
            // получаем скомпилированный готовый объект
            _obj = loAssembly.CreateInstance("Nemo.Dynamic.FilterDynamic");
            if (_obj == null)
            {
                _errorMsg = "Couldn't load class.";
                return false;
            }
            _text = ufilter;
            return true;
        }

        public bool AddFilter(string name)
        {
            //verify that name is unique
            foreach (CustomFilter fil in _filters)
            {
                if (fil.Name.Equals(name))
                {
                    _errorMsg = "Dublicate filter name";
                    return false;
                }
            }

           _filters.Add(new CustomFilter(name, _text, _obj));
           return true;
        }

        public string GetFilterText(string filter)
        {
            CustomFilter fil = getFilterByName(filter);
            return (fil == null) ? string.Empty : fil.Text;
        }

        public void ChangeNotify(string filter)
        {
            CustomFilter fil = getFilterByName(filter);
            fil.Notify = !fil.Notify;
        }

        public bool DoNotify(string filter)
        {
            CustomFilter fil = getFilterByName(filter);
            return fil.Notify;
        }

        public bool UpdateFilter(string name)
        {
            CustomFilter filter = getFilterByName(name);
            if (filter != null)
                _filters.Remove(filter);
            return AddFilter(name);
        }

        public void RemoveFilter(string name)
        {
            CustomFilter filter = getFilterByName(name);
            if (filter != null)
                _filters.Remove(filter);
        }

        public bool RenameFilter(string oldName, string newName)
        {        
            //find filter by old name
            CustomFilter filter = getFilterByName(oldName);
            if (filter == null)
            {
                _errorMsg = "Filter '" + oldName + "' does not exist";
                return false;
            }
            if (!oldName.Equals(newName))
            {
                //verify that filter with new name does not exist
                CustomFilter filter1 = getFilterByName(newName);
                if (filter1 != null)
                {
                    _errorMsg = "Filter '" + newName + "' already exists";
                    return false;
                }
            }
            filter.Name = newName;
            return true;
        }
        
        public bool MatchFilter(string filter, Flow flow)
        {
            CustomFilter cFilter = getFilterByName(filter);
            if(cFilter == null)
                return false;
            if (cFilter.Text.Equals(string.Empty))
                return true;

            object[] loCodeParms = new object[1];
            loCodeParms[0] = flow;
            object loResult = cFilter.Obj.GetType().InvokeMember(
                                    "MatchFilter", BindingFlags.InvokeMethod,
                                    null, cFilter.Obj, loCodeParms);
            return (bool)loResult;
        }

        public Flow[] FilterFlows(string filter, List<Flow> flows, 
            DateTime start, DateTime end)
        {
            CustomFilter cFilter = getFilterByName(filter);
            //if filter not found return nothing
            if (cFilter == null)
                return null;

            if (cFilter.Text.Equals(string.Empty))
            {
                return (from f in flows
                        where f.StartTime.CompareTo(start) >= 0 
                        && f.EndTime.CompareTo(end) < 0
                        select f).ToArray();
            }
   
            object[] loCodeParms = new object[3];
            loCodeParms[0] = flows;
            loCodeParms[1] = start;
            loCodeParms[2] = end;
            object loResult = cFilter.Obj.GetType().InvokeMember(
                                    "FilterFlows", BindingFlags.InvokeMethod,
                                    null, cFilter.Obj, loCodeParms);
            Flow[] res = (Flow[])loResult;
            return (from f in res.ToList()
                    orderby f.StartTime
                    select f).ToArray();
        }

        private CustomFilter getFilterByName(string filter)
        {
            CustomFilter cFilter = null;
            //find custom filter by name
            foreach (CustomFilter fil in _filters)
            {
                if (fil.Name.Equals(filter))
                {
                    cFilter = fil;
                    break;
                }
            }
            //if filter not found return nothing
            return cFilter;
        }

        //convert user filter string to valid program filter code
        private string prepareFilterString(string filter)
        {
            filter = filter.ToLower();
            filter = filter.Replace(" ",  string.Empty);

            filter = Regex.Replace(filter, @".*(ip...)==(\d+\.\d+\.\d+\.\d+).*", matchReplacer);
            filter = Regex.Replace(filter, @".*((ip...)&(\d+\.\d+\.\d+\.\d+)/(\d+)).*", matchNetReplacer);
            filter = Regex.Replace(filter, @".*((ip...)&(\d+\.\d+\.\d+\.\d+)/(\d+)).*", matchNetReplacer);
            filter = filter.Replace("localsrc", "flow.IsLocalA");
            filter = filter.Replace("localdst", "flow.IsLocalB");
            filter = filter.Replace("tran=(", "tran.StartsWith(");
            filter = filter.Replace("namesrc=(", "namesrc.StartsWith(");
            filter = filter.Replace("namedst=(", "namedst.StartsWith(");
            filter = filter.Replace("serv=(", "serv.StartsWith(");
            filter = filter.Replace("tran", "flow.TransportProto.ToString().ToLower()");
            filter = filter.Replace("ipsrc", "flow.IpA.ToString()");
            filter = filter.Replace("ipdst", "flow.IpB.ToString()");
            filter = filter.Replace("portsrc", "flow.PortA");
            filter = filter.Replace("portdst", "flow.PortB");
            filter = filter.Replace("bytessrc", "flow.BytesAB");
            filter = filter.Replace("bytesdst", "flow.BytesBA");
            filter = filter.Replace("bytes", "flow.BytesBA + flow.BytesAB");
            filter = filter.Replace("packetssrc", "flow.PacketsAB");
            filter = filter.Replace("packetsdst", "flow.PacketsBA");
            filter = filter.Replace("packets", "flow.PacketsBA + flow.PacketsAB");
            filter = filter.Replace("serv", "flow.ApplicationProto.ToLower()");
            filter = filter.Replace("namesrc", "flow.NameA.ToLower()");
            filter = filter.Replace("namedst", "flow.NameB.ToLower()");
            return filter;
        }

        private string matchReplacer(Match m)
        {
            string res = m.Groups[0].Value.Replace(m.Groups[1].Value, String.Format("{0}.ToString()", m.Groups[1]));
            return  res.Replace(m.Groups[2].Value, String.Format("\"{0}\"" , m.Groups[2]));
        }

        private string matchNetReplacer(Match m)
        {
            try
            {
                int mask = 1 << Int32.Parse(m.Groups[4].Value);
                string replace = string.Format("((flow.{0}.Address&{1})==(IPAddress.Parse(\"{2}\")) .Address)",
                    m.Groups[2].Value.Equals("ipsrc") ? "IpA" : "IpB", mask - 1, m.Groups[3].Value);
                return m.Groups[0].Value.Replace(m.Groups[1].Value, replace);
            }
            catch
            {
                return m.Groups[0].Value;
            }
        }
    }
}
