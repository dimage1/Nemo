using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tamir.IPLib;
using Nemo.Properties;
using Nemo.Core;

namespace Nemo.GUI
{
    public partial class InterfacesForm : Form
    {
        private PcapParser _pcapParser;
        ImageList _images;

        public InterfacesForm(PcapParser pcapParser)
        {
            InitializeComponent();
            _pcapParser = pcapParser;
            _images = new ImageList();
            _images.Images.Add(Resources._interface);
            InterfacesTreeView.ImageList = _images;
            fillInterfacesList();
        }

private void fillInterfacesList()
{
    PcapDeviceList list = _pcapParser.GetInterfaces();
    TreeNode item;
    StringBuilder info = new StringBuilder();
    foreach (PcapDevice dev in list)
    {
        // If the device is a physical network device,
        // lets print some advanced info
        if (dev is NetworkDevice && _pcapParser.TestDevice(dev))
        {
            // Cast to NetworkDevice 
            NetworkDevice netDev = (NetworkDevice)dev;
            item = new TreeNode((netDev.Description.Length > 400) ?
                    netDev.Description.Substring(0, 400) : 
                    netDev.Description, 0, 0);
            // Add advanced info 
            info.Append(String.Format("IP Address:\t\t{0}", 
                dev.PcapIpAddress));
            info.Append(String.Format("\nSubnet Mask:\t\t{0}", 
                netDev.SubnetMask));
            info.Append(String.Format("\nMAC Address:\t\t{0}", 
                netDev.MacAddress));
            info.Append(String.Format("\nDefault Gateway:\t{0}", 
                netDev.DefaultGateway));
            info.Append(String.Format("\nPrimary WINS:\t\t{0}", 
                netDev.WinsServerPrimary));
            info.Append(String.Format("\nSecondary WINS:\t{0}", 
                netDev.WinsServerSecondary));
            info.Append(String.Format("\nDHCP Enabled:\t\t{0}", 
                netDev.DhcpEnabled));
            info.Append(String.Format("\nDHCP Server:\t\t{0}", 
                netDev.DhcpServer));
            info.Append(String.Format("\nDHCP Lease Obtained:\t{0}", 
                netDev.DhcpLeaseObtained));
            info.Append(String.Format("\nDHCP Lease Expires:\t{0}", 
                netDev.DhcpLeaseExpires));
            item.Tag = dev;
            item.ToolTipText = info.ToString();
            info.Length = 0;
            InterfacesTreeView.Nodes.Add(item);
        }
    }
}

        private void InterfacesListView_ItemActivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InterfacesListView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InterfacesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _pcapParser.SetDevice((PcapDevice)e.Node.Tag);
            _pcapParser.StartCapture();
            this.Close();
        }
    }
}
