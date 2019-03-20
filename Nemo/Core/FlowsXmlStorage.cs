using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Nemo.Core
{
public class FlowsXmlStorage : IFlowsStorage
{
    public FlowsXmlStorage() { }

    public void Store(List<Flow> flows, string path)
    {
        XElement flowsXml = new XElement("Flows");
        XElement flowXml;
        XElement xml;
        //fill XML with flows attributes
        foreach (Flow flow in flows)
        {
            flowXml = new XElement("Flow");
            flowXml.SetAttributeValue("StartTime", 
                flow.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            flowXml.SetAttributeValue("Length", 
                flow.Length.ToString());
            flowXml.SetAttributeValue("Service", 
                flow.ApplicationProto);
            flowXml.SetAttributeValue("Transport", 
                flow.TransportProto.ToString());
            xml = new XElement("Address");
            xml.SetAttributeValue("Src", 
                string.Format("{0}:{1}", flow.IpA, flow.PortA));
            xml.SetAttributeValue("Dst", 
                string.Format("{0}:{1}", flow.IpB, flow.PortB));
            flowXml.Add(xml);
            xml = new XElement("Data");
            xml.SetAttributeValue("PacketsAB", flow.PacketsAB);
            xml.SetAttributeValue("BytesAB", flow.BytesAB);
            xml.SetAttributeValue("PacketsBA", flow.PacketsBA);
            xml.SetAttributeValue("BytesBA", flow.BytesBA);
            flowXml.Add(xml);
            flowsXml.Add(flowXml);
        }
        flowsXml.Save(path);
    }

    public List<Flow> Load(string path)
    {
        List<Flow> res = new List<Flow>();
        List<XElement> flowsXml = 
            XElement.Load(path).Elements().ToList();
        XElement xml;
        Flow flow;
        Match match;
        //load flows from XML
        foreach(XElement flowXml in flowsXml)
        {
            flow = new Flow(); 
            flow.StartTime = 
                DateTime.Parse(flowXml.Attribute("StartTime").Value);
            flow.EndTime = flow.StartTime + 
                TimeSpan.Parse(flowXml.Attribute("Length").Value);
            flow.ApplicationProto = flowXml.Attribute("Service").Value;
            flow.TransportProto = 
                flowXml.Attribute("Transport").Value.ToLower().Equals("tcp") ? 
                TransportProtocol.TCP : TransportProtocol.UDP;
            xml = flowXml.Element("Address");
            match = Regex.Match(xml.Attribute("Src").Value, @"(.+):(\d+)");
            flow.IpA = IPAddress.Parse(match.Groups[1].Value);
            flow.PortA = ushort.Parse(match.Groups[2].Value);
            match = Regex.Match(xml.Attribute("Dst").Value, @"(.+):(\d+)");
            flow.IpB = IPAddress.Parse(match.Groups[1].Value);
            flow.PortB = ushort.Parse(match.Groups[2].Value);
            xml = flowXml.Element("Data");
            flow.PacketsAB = ushort.Parse(xml.Attribute("PacketsAB").Value);
            flow.PacketsBA = ushort.Parse(xml.Attribute("PacketsBA").Value);
            flow.BytesAB = ulong.Parse(xml.Attribute("BytesAB").Value);
            flow.BytesBA = ulong.Parse(xml.Attribute("BytesBA").Value);
            res.Add(flow);
        }
        return res;
    }
}
}
