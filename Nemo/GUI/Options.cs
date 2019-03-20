using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo.Core;
using System.Xml.Linq;
using System.Net;

namespace Nemo.GUI
{
    public class Options
    {
        private const string cFileName = "\\nemo.cfg";
        public static Dictionary<uint, string> ServiceMap;
        public List<FilterName> CheckedFilters = new List<FilterName>();
        public DynamicFilter CustomFilters;
        public Dictionary<string, string> Aliases = new Dictionary<string,string>();
        public List<IPRange> Locals = new List<IPRange>();


        public Options()
        {
            CustomFilters = new DynamicFilter();
            //prepare standard filters
            CheckedFilters.Add(FilterName.Address);
            CheckedFilters.Add(FilterName.Port);
            CheckedFilters.Add(FilterName.Service);
            CheckedFilters.Add(FilterName.Size);
            CheckedFilters.Add(FilterName.Time);
            CheckedFilters.Add(FilterName.Custom);
            //service map with proto names and ports
            ServiceMap = Constants.GetDefaultServiceMap();
            XElement rootXml = null;
            try
            {
                rootXml = XElement.Load(DynamicFilter.WorkingDir + cFileName);
            }
            catch
            {
                return;
            }
            //load filters
            try
            {
                List<XElement> filters = rootXml.Element("filters").Elements("filter").ToList();
                foreach (XElement fil in filters)
                {
                    if (CustomFilters.BuildFilter(fil.Attribute("text").Value))
                        CustomFilters.AddFilter(fil.Attribute("name").Value);
                }
            }
            catch{}
            //load aliases
            try
            {
                List<XElement> aliases = rootXml.Element("aliases").Elements("alias").ToList();
                foreach (XElement al in aliases)
                {
                    try
                    {
                        string ip = al.Attribute("ip").Value;
                        IPAddress.Parse(ip);
                        Aliases[ip] = al.Attribute("name").Value;
                    }
                    catch { }
                }
            }
            catch { }
            //load locals
            try
            {
                List<XElement> locals = rootXml.Element("locals").Elements("local").ToList();
                foreach (XElement loc in locals)
                {
                    IPRange range = new IPRange();
                    if (range.Parse(loc.Attribute("range").Value))
                    {
                        Locals.Add(range);
                    }
                }
            }
            catch { }
            
        }

        public void store()
        {
            XElement rootXml = new XElement("config");
            XElement filtersXml = new XElement("filters");
            List<string> names = CustomFilters.FilterNames;
            string filter;
            XElement filterXml;
            foreach (string name in names)
            {
                filter = CustomFilters.GetFilterText(name);
                filterXml = new XElement("filter");
                filterXml.SetAttributeValue("name", name);
                filterXml.SetAttributeValue("text", filter);
                filtersXml.Add(filterXml);
            }
            rootXml.Add(filtersXml);
            XElement aliasesXml = new XElement("aliases");
            XElement aliasXml;
            foreach (string ip in Aliases.Keys)
            {
                aliasXml = new XElement("alias");
                aliasXml.SetAttributeValue("ip", ip);
                aliasXml.SetAttributeValue("name", Aliases[ip]);
                aliasesXml.Add(aliasXml);
            }
            rootXml.Add(aliasesXml);
            XElement localsXml = new XElement("locals");
            XElement localXml;
            foreach (IPRange range in Locals)
            {
                localXml = new XElement("local");
                localXml.SetAttributeValue("range", range.Text);
                localsXml.Add(localXml);
            }
            rootXml.Add(localsXml);
            rootXml.Save(DynamicFilter.WorkingDir + cFileName);
        }

    }
}
