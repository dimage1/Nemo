using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Win32;
using Northwoods.Go;
using Nemo.Core;
using System.Net;

namespace Nemo.GUI
{
    public partial class StatisticsForm : DockContent
    {
        private List<long> _localHosts;
        private List<long> _globalHosts;

        public StatisticsForm()
        {
            InitializeComponent();
            _localHosts = new List<long>();
            _globalHosts = new List<long>();
            StatGrid.IsAccessible = false;
        }

        public void ShowStatistics(Flow[] flows)
        {
            FlowsStat stat = new FlowsStat();
            ulong bytes;
            uint packets;
            TimeSpan time;
            long ip;

            _localHosts.Clear();
            _globalHosts.Clear();

            foreach (Flow flow in flows)
            {
                ip = flow.IpA.Address;
                if (flow.IsLocalA && !_localHosts.Contains(ip))
                    _localHosts.Add(ip);
                else if (!flow.IsLocalA && !_globalHosts.Contains(ip))
                    _globalHosts.Add(ip);

                ip = flow.IpB.Address;
                if (flow.IsLocalB && !_localHosts.Contains(ip))
                    _localHosts.Add(ip);
                else if (!flow.IsLocalB && !_globalHosts.Contains(ip))
                    _globalHosts.Add(ip);
                
                stat.TotalFlows++;
                if (flow.IsLocalA)
                {
                    if (flow.IsLocalB)
                        stat.LocalFlows++;
                    else
                        stat.LocalToGlobalFlows++;
                }
                else
                    stat.GlobalToLocalFlows++;

                bytes = flow.BytesAB + flow.BytesBA;
                packets = flow.PacketsAB + flow.PacketsBA;
                stat.TotalBytes +=  bytes;
                stat.TotalPackets += packets;

                if (bytes > stat.MaxBytes)
                    stat.MaxBytes = bytes;
                if (packets > stat.MaxPackets)
                    stat.MaxPackets = packets;
                if (bytes < stat.MinBytes)
                    stat.MinBytes = bytes;
                if (packets < stat.MinPackets)
                    stat.MinPackets = packets;

                time = flow.Length;
                if (stat.MinLength > time)
                    stat.MinLength = time;
                if (stat.MaxLength < time)
                    stat.MaxLength = time;
                if (stat.MinStartTime > flow.StartTime)
                    stat.MinStartTime = flow.StartTime;
                if (stat.MaxStartTime < flow.StartTime)
                    stat.MaxStartTime = flow.StartTime;
            }
            if(flows.Count() > 0)
            {
                stat.AveragePackets = stat.TotalPackets / stat.TotalFlows;
                stat.AverageBytes = stat.TotalBytes / stat.TotalFlows;
                stat.LocalHosts = _localHosts.Count;
                stat.GlobalHosts = _globalHosts.Count;
                stat.TotalHosts = stat.LocalHosts + stat.GlobalHosts;
                StatGrid.SelectedObject = stat;
            }
        }

        public void Clear()
        {
            StatGrid.SelectedObject = null;
        }
    }

public class FlowsStat
{
    [Description("Total flows number"), Category("Flows")]
    public uint TotalFlows { get; set; }
    [Description("Flows of local nets"), Category("Flows")]
    public uint LocalFlows { get; set; }
    [Description("Flows from local to global nets"), Category("Flows")]
    public uint LocalToGlobalFlows { get; set; }
    [Description("Flows from global to local nets"), Category("Flows")]
    public uint GlobalToLocalFlows { get; set; }

    [Description("Total hosts number"), Category("Hosts")]
    public int TotalHosts { get; set; }
    [Description("Local hosts number"), Category("Hosts")]
    public int LocalHosts { get; set; }
    [Description("Global hosts number"), Category("Hosts")]
    public int GlobalHosts { get; set; }

    [Description("Total packets number"), Category("Packets")]
    public uint TotalPackets { get; set; }
    [Description("Average packets per flow"), Category("Packets")]
    public double AveragePackets { get; set; }
    [Description("Max packets on flow"), Category("Packets")]
    public uint MaxPackets { get; set; }
    [Description("Min packets on flow"), Category("Packets")]
    public uint MinPackets { get; set; }

    [Description("Total bytes number"), Category("Bytes")]
    public ulong TotalBytes { get; set; }
    [Description("Average bytes per flow"), Category("Bytes")]
    public double AverageBytes { get; set; }
    [Description("Max packets on flow"), Category("Bytes")]
    public ulong MaxBytes { get; set; }
    [Description("Min packets on flow"), Category("Bytes")]
    public ulong MinBytes { get; set; }

    [Description("Min flow length"), Category("Time")]
    public TimeSpan MinLength { get; set; }
    [Description("Max flow length"), Category("Time")]
    public TimeSpan MaxLength { get; set; }
    [Description("Min flow start"), Category("Time")]
    public DateTime MinStartTime { get; set; }
    [Description("Max flow start"), Category("Time")]
    public DateTime MaxStartTime { get; set; }

    public FlowsStat()
    {
        TotalFlows = 0;
        LocalFlows = 0;
        LocalToGlobalFlows = 0;
        GlobalToLocalFlows = 0;

        TotalHosts = 0;
        LocalHosts = 0;
        GlobalHosts = 0;

        TotalPackets = 0;
        TotalBytes = 0;
        MinBytes = ulong.MaxValue;
        MinPackets = uint.MaxValue;
        MaxBytes = 0;
        MaxPackets = 0;
        AverageBytes = 0;
        AveragePackets = 0;

        MinLength = TimeSpan.MaxValue;
        MaxLength = TimeSpan.MinValue;
        MinStartTime = DateTime.MaxValue;
        MaxStartTime = DateTime.MinValue;
    }
}
}
