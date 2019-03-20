using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nemo.Core;

namespace Nemo.GUI
{
	public enum NodeTag
	{
		Clearable = 0,
		NonClearable = 1,
		Viewable = 2
	}

	public partial class FiltersTreeView : TreeView
    {
        public FiltersTreeView()
        {
            InitializeComponent();
            this.ImageList = null;
        }

        private void fillImages(List<FilterName> CheckedFilters)
        {
            if (this.ImageList == null)
                this.ImageList = new ImageList();
            else            
                this.ImageList.Images.Clear();
            this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterSelected);
            for (int i = 0; i < CheckedFilters.Count; i++)
            {
                switch (CheckedFilters[i])
                {
                    case FilterName.Address:
                        this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterAddress);
                        break;
                    case FilterName.Port:
                        this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterPort);
                        break;
                    case FilterName.Service:
                        this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterService);
                        break;
                    case FilterName.Size:
                        this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterSize);
                        break;
                    case FilterName.Time:
                        this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterTime);
                        break;
                    case FilterName.Custom:
                        this.ImageList.Images.Add(global::Nemo.Properties.Resources.filterCustom);
                        break;
                }
            }
            this.ImageList.Images.Add(global::Nemo.Properties.Resources.Warning);
        }       

        public void CreateMainNodes(List<FilterName> CheckedFilters)
        {
            fillImages(CheckedFilters);
            this.Nodes.Clear();
			TreeNode node;
            TreeNode subNode;
            TreeNode subsubNode;

            for (int i = 0; i < CheckedFilters.Count; i++)
            {
				//0 tag for clearable nodes, 1 for not
				switch (CheckedFilters[i])
                {
                    case FilterName.Address:
                        node = CreateNode(FilterName.Address.ToString(), FilterName.Address, NodeTag.NonClearable, i + 1);
                        subNode = CreateNode("Source", FilterName.AddressSrc, NodeTag.Clearable, i + 1);
                        node.Nodes.Add(subNode);
                        subNode = CreateNode("Destination", FilterName.AddressDst, NodeTag.Clearable, i + 1);
                        node.Nodes.Add(subNode);
                        this.Nodes.Add(node);
                        break;
                    case FilterName.Port:
                        node = CreateNode(FilterName.Port.ToString(), FilterName.Port, NodeTag.NonClearable, i + 1);
                        subNode = CreateNode("Source", FilterName.PortSrc, NodeTag.NonClearable, i + 1);
                        subsubNode = CreateNode("Tcp", FilterName.PortSrcTcp, NodeTag.Clearable, i + 1);
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = CreateNode("Udp", FilterName.PortSrcUdp, NodeTag.Clearable, i + 1);
                        subNode.Nodes.Add(subsubNode);
                        node.Nodes.Add(subNode);
                        subNode = CreateNode("Destination", FilterName.PortDst, NodeTag.NonClearable, i + 1);
                        subsubNode = CreateNode("Tcp", FilterName.PortDstTcp, NodeTag.Clearable, i + 1);
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = CreateNode("Udp", FilterName.PortDstUdp, NodeTag.Clearable, i + 1);
                        subNode.Nodes.Add(subsubNode);
                        node.Nodes.Add(subNode);
                        this.Nodes.Add(node);
                        break;
                    case FilterName.Service:
                        node = CreateNode(FilterName.Service.ToString(), FilterName.Service, NodeTag.Clearable, i + 1);
						this.Nodes.Add(node);
                        break;
                    case FilterName.Size:
                        node = CreateNode(FilterName.Size.ToString(), FilterName.Size, NodeTag.Clearable, i + 1);
 						this.Nodes.Add(node);
						break;
                    case FilterName.Time:
                        node = CreateNode(FilterName.Time.ToString(), FilterName.Time, NodeTag.NonClearable, i + 1);
                        subNode = CreateNode("Start", FilterName.TimeStart, NodeTag.Clearable, i + 1);
                        node.Nodes.Add(subNode);
                        subNode = CreateNode("Length", FilterName.TimeLength, NodeTag.Clearable, i + 1);
                        node.Nodes.Add(subNode);
						this.Nodes.Add(node);
                        break;
                    case FilterName.Custom:
                        node = CreateNode("Custom", FilterName.Custom, NodeTag.Clearable, i + 1);
						this.Nodes.Add(node);
                        break;
                }
            }
			CollapseAll();
        }

        private TreeNode CreateNode(string text,  FilterName filter, NodeTag tag, int imgNum)
        {
            TreeNode node= new TreeNode(text, imgNum, imgNum);
            node.Name = filter.ToString();
            node.Tag = tag;
            return node;
        }

        public void ClearNodes()
        {
			clearNodes(this.Nodes);
        }

        public void RefreshNodeChildren(FilterName filter, Dictionary<string, int> children, ContextMenuStrip menu,  DynamicFilter dynamic)
        {
            string nodeKey = filter.ToString();
            TreeNode[] nodes = Nodes.Find(nodeKey, true);
            if (nodes.Count() != 1)
                return;
            TreeNode node = nodes[0];

            node.Nodes.Clear();
            List<string> list = children.Keys.ToList();
            list.Sort();
			TreeNode childNode;
            foreach (string child in list)
            {
                string text = String.Format("{0} ({1})", child, children[child].ToString());
				childNode = new TreeNode(text, 
                    (node.Name.Equals(FilterName.Custom.ToString()) && dynamic.DoNotify(child)) ? 
                    this.ImageList.Images.Count - 1 : node.ImageIndex, 0);
				childNode.Name = child;
                childNode.Tag = NodeTag.Viewable;
                childNode.ContextMenuStrip = menu;
                node.Nodes.Add(childNode);
            }
        }

		private void clearNodes(TreeNodeCollection treeNodes)
		{
			foreach (TreeNode node in treeNodes)
			{
				if ((NodeTag)node.Tag == NodeTag.Clearable)
					node.Nodes.Clear();
				else
					clearNodes(node.Nodes);
			}
		}
    }
}
