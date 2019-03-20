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
    public enum LinkStatus { LocalOnly, LocalOut, OutLocal}

    public class HostLink
    {
        public GoLabeledLink Link;
        public LinkStatus Status = LinkStatus.LocalOnly;
        public List<Flow> Flows = new List<Flow>();
        //true if a->b and b->a
        public bool Doubled = false;

        public HostLink(Flow flow, GoLabeledLink link)
        {
            if (!flow.IsLocalA)
            {
                Status = LinkStatus.OutLocal;
            }
            else if(!flow.IsLocalB)
            {
                Status = LinkStatus.LocalOut;
            }
            Link = link;
            Flows.Add(flow);
        }

        public bool MatchLink(Flow flow)
        {
            return Flows[0].MatchIPs(flow);
        }

        public void AddFlow(Flow flow)
        {
            if (Status != LinkStatus.OutLocal && !flow.IsLocalA)
            {
                Status = LinkStatus.OutLocal;
            }
            else if (!flow.IsLocalB && Status == LinkStatus.LocalOnly)
            {
                Status = LinkStatus.LocalOut;
            }
            if (Flows[0].IpA.Equals(flow.IpB))
                Doubled = true;
            Flows.Add(flow);
        }

    }

    public partial class MapForm : DockContent
    {
        //view for map show
        GoView mapView;
        //imag list for host picture
        private ImageList imageList;
        //dictionary of links between hosts. key is IP1+IP2
        private Dictionary<ulong, GoLabeledLink> linksMap;
        //dictionary of hosts. key is int IPAddr of the host
        private Dictionary<uint, GoIconicNode> hostsMap;
        //dictionary of hosts. key is int IPAddr of the host
        private Dictionary<uint, GoIconicNode> localsMap;
        Dictionary<uint, GoIconicNode> utilMap;
        private List<HostLink> links = new List<HostLink>();
        

        public  MapForm()
        {
            InitializeComponent();

            linksMap = new Dictionary<ulong, GoLabeledLink>();
            hostsMap = new Dictionary<uint, GoIconicNode>();
            localsMap = new Dictionary<uint, GoIconicNode>();
            imageList = new ImageList();
            imageList.Images.Add(global::Nemo.Properties.Resources.filterAddress);
            // create a Go view (a Control) and add to the form
            mapView = new GoView();
            mapView.ImageList = imageList;
            mapView.Dock = DockStyle.Fill;
            mapView.Document.LinksLayer.AllowDelete = true;
            mapView.Document.LinksLayer.AllowInsert = false;
            mapView.Document.LinksLayer.AllowLink = false;
            MapPanel.Controls.Add(mapView);
        }

        public void ShowMap(Flow[] flows)
        {
            uint    ip1;
            uint    ip2;
            GoIconicNode n1;
            GoIconicNode n2;

            hostsMap.Clear();
            localsMap.Clear();
            linksMap.Clear();
            links.Clear();
            mapView.Document.Clear();

            foreach (Flow flow in flows)
            {
                ip1 = (uint)flow.IpA.Address;
                ip2 = (uint)flow.IpB.Address;
                
                if (flow.IsLocalA)
                    utilMap = localsMap;
                else
                    utilMap = hostsMap;

                if (!utilMap.ContainsKey(ip1))
                {
                    n1 = addMapHost(ip1, string.IsNullOrEmpty(flow.NameA) ? flow.IpA.ToString() : flow.NameA);
                }
                else
                {
                    n1 = utilMap[ip1];
                }
                if (flow.IsLocalB)
                    utilMap = localsMap;
                else
                    utilMap = hostsMap;
                if (!utilMap.ContainsKey(ip2))
                {
                    n2 = addMapHost(ip2, string.IsNullOrEmpty(flow.NameB) ? flow.IpB.ToString() : flow.NameB);
                }
                else
                {
                    n2 = utilMap[ip2];
                }

                int i;
                for(i = 0; i < links.Count; i++)   
                {
                    if (links[i].MatchLink(flow))
                    {
                        links[i].AddFlow(flow);
                        break;
                    }
                }
                if (i == links.Count)
                {
                    links.Add(new HostLink(flow, getMapLink(n1, n2)));
                }
            }
            paintMap();
        }

        public void Clear()
        {
            mapView.Document.Clear();
        }

        private GoIconicNode addMapHost(uint ip, string ipStr)
        {
            GoIconicNode n = new GoIconicNode();
            n.Initialize(null, 0, ipStr);
            // labels are editable, but may be disabled by setting goView1.AllowEdit to false
            n.Editable = true;
            n.Label.Editable = false;
            n.Label.FontSize = 8;
            n.Icon.Size = new SizeF(16, 16);
            // port is whole icon, but linking may be disabled by setting goView1.AllowLink to false
            n.Port.Bounds = n.Icon.Bounds;
            utilMap.Add(ip, n);
            return n;
        }

        private GoLabeledLink getMapLink(GoIconicNode n1, GoIconicNode n2)
        {
            GoLabeledLink link = new GoLabeledLink();
            link.Style = GoStrokeStyle.Bezier;
            link.ToolTipText = n1.Text + ", " + n2.Text;
            link.ToArrow = true;
            link.ToArrowLength = 9;
            link.ToArrowShaftLength = 6;
            link.ToArrowFilled = true;
            link.Shadowed = false;
            n1.Port.AddDestinationLink(link);
            n2.Port.AddSourceLink(link);
            return link;
        }

        private void paintMap()
        {
            paintHosts();
            paintLinks();
        }

        private void paintHosts()
        {
            int i = 1;
            //шаг отступа хоста
            int step = 100;
            // x,y - координаты последнего добавленного хоста
            //localsMap - список локальных хостов
            int x = ((int)Math.Ceiling(Math.Sqrt(localsMap.Values.Count) / 2)) * step + 100;
            int memx = x;
            int y;
            //коэффициент для нахождения следующей позиции хоста
            int xk = 0;
            int yk = 1;
            //границы квадрата хостов(top = right, left = bottom)                                                                 
            int left, top;
            left = top = y = x;
            //для каждого хоста из списка
            foreach (GoIconicNode host in localsMap.Values)
            {
                if (i == 1)
                {
                    //рисуем первый хост
                    host.Location = new PointF(x, y);
                }
                else
                {
                    //если идем вверх и верхняя граница достигнута
                    if (yk == 1 && y == top)
                    {
                        //если достигнута и правая граница - меняем позицию
                        //не меняем направление
                        if (x == top)
                        {
                            left -= step;
                            top += step;

                        }
                        //иначе идем влево
                        else
                        {
                            yk = 0;
                            xk = -1;
                        }
                    }
                    //если идем вниз и нижняя граница достигнута - идём  вправо
                    else if (yk == -1 && y == left)
                    {
                        yk = 0;
                        xk = 1;
                    }
                    //если идем  влево и левая граница достигнута - идём вниз
                    else if (xk == -1 && x == left)
                    {
                        yk = -1;
                        xk = 0;
                    }
                    //если идем вправо и правая граница достигнута - идём вниз
                    else if (xk == 1 && x == top)
                    {
                        yk = 1;
                        xk = 0;
                    }
                    //вычисляем координаты для хоста
                    x += xk * step;
                    y += yk * step;
                }
                host.Location = new PointF(x, y);
                //добавляем хост в карту
                mapView.Document.Add(host);
                i++;
            }
            //рисуем внешние хосты 
            paintNotLocalHosts(memx * 2 + 50);
        }

        private void paintNotLocalHosts(int x)
        {
            int y = 50;
            int i = 0;

            //рисуем внешние хосты сверху вниз
            foreach (GoIconicNode host in hostsMap.Values)
            {
                host.Location = new PointF(x, y);
                mapView.Document.Add(host);
                y += 35;
                i++;
            }
        }

        private void paintLinks()
        {
            StringBuilder builder = new StringBuilder();
            Pen pen = null;
            foreach (HostLink link in links)
            {
                builder.Length = 0;
                foreach (Flow flow in link.Flows)
                {
                    if (flow.IpA.Equals(link.Flows[0].IpA))
                    {
                        builder.Append(String.Format("{0}->{1}\n", flow.PortA, flow.PortB));
                    }
                    else
                    {
                        builder.Append(String.Format("{1}<-{0}\n", flow.PortA, flow.PortB));
                    }
                }
                link.Link.ToolTipText = builder.ToString();
                if (link.Doubled)
                {
                    link.Link.FromArrow = true;
                    link.Link.FromArrowLength = 4;
                    link.Link.FromArrowShaftLength = 2;
                    link.Link.FromArrowFilled = true;
                }
                else
                {
                    link.Link.Shadowed = true;
                    link.Link.FromArrowStyle = GoStrokeArrowheadStyle.Circle;
                    link.Link.FromArrowLength = 3;
                    link.Link.FromArrowShaftLength = 3;
                    link.Link.FromArrow = true;
                }
                switch (link.Status)
                {
                    case LinkStatus.LocalOnly: pen = new Pen(Color.LightGreen); break;
                    case LinkStatus.LocalOut: pen = new Pen(Color.FromArgb(235, 219, 20)); break;
                    case LinkStatus.OutLocal: pen = new Pen(Color.FromArgb(255, 154, 136)); break;
                    default: break;
                }
                link.Link.Pen = pen; 
                link.Link.Visible = true;
                link.Link.Shadowed = false;
                mapView.Document.LinksLayer.Add(link.Link);

            }
        }
    }
}
