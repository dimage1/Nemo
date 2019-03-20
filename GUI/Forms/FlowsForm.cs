using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Net;
using System.Collections;
using Nemo.Core;

namespace Nemo.GUI
{
	public partial class FlowsForm : DockContent
	{
        MainForm _main = null;

        public TreeListView FlowsTable
		{
			get { return FlowsListView; }
		}

		public FlowsForm(MainForm main)
		{
			InitializeComponent();
            _main = main;
		}

		private void _flowsListView_MouseLeave(object sender, EventArgs e)
		{
		}

		private void _flowsListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		public void FillFlowsTable(Flow[] flows)
		{
			//clear all nodes from flows table
            FlowsListView.Items.Clear();
            //do nothing if flows obejct is null!
            if (flows == null)
                return;
			FlowsListView.SmallImageList = new ImageList();
			FlowsListView.BeginUpdate();
			foreach (Flow flow in flows)
			{
				addFlow(flow);
			}
			FlowsListView.EndUpdate();
		}

        public void ClearFlowsTable()
        {
            FlowsListView.Items.Clear();
        }

		private void addFlow(Flow flow)
		{
            TreeListNode node = new TreeListNode(new string[] 
					{ flow.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                        flow.TransportProto.ToString(), flow.ApplicationProto,
					  string.IsNullOrEmpty(flow.NameA) ? 
                      flow.IpA.ToString() : flow.NameA, 
                      flow.PortA.ToString(), 
                      flow.PortB.ToString(),
                      string.IsNullOrEmpty(flow.NameB) ? 
                      flow.IpB.ToString() : flow.NameB});

            TreeListNode subnode = new TreeListNode(new string[] 
					{ getSubnodeTimeInfo(flow), "", 
                      (flow.PacketsAB + flow.PacketsBA).ToString() + 
                      " pkt, " + getBytesInfo(flow.BytesBA + flow.BytesAB),
                      flow.PacketsAB.ToString() + " pkt, " + 
                      getBytesInfo(flow.BytesAB), 
                        "----->", "<-----", flow.PacketsBA.ToString() + 
                        " pkt, " + getBytesInfo(flow.BytesBA)});

            setColor(flow,  node, subnode);
            node.Tag = flow;
            node.Nodes.Add(subnode);
            node.Nodes.Add(new TreeListNode(new string[]{}));
            FlowsListView.Nodes.Add(node);
            node.EnsureVisible();
            if (FlowsTable.ExpandedAll)
            {
                FlowsTable.ExpandAll();
            }
 		}

        private void setColor(Flow flow, 
            TreeListNode node, TreeListNode subnode)
        {
            if (flow.IsLocalA && flow.IsLocalB)
            {
                node.BackColor = Color.FromArgb(179, 242, 151);
                subnode.BackColor = Color.FromArgb(209, 248, 192);
            }
            else if (flow.IsLocalA)
            { 
                node.BackColor = Color.FromArgb(254, 224, 180);
                subnode.BackColor = Color.LightYellow;
            }
            else
            {
                node.BackColor = Color.FromArgb(255, 154, 136);
                subnode.BackColor = Color.FromArgb(255, 217, 210);
            }
        }

        private string getBytesInfo(ulong bytes)
        {
            if (bytes > (ulong)Constants.MB)
                return string.Format("{0} mb", 
                    ((double)bytes / (double)Constants.MB).ToString("F02"));
            else if (bytes > (ulong)Constants.KB)
                return string.Format("{0} kb", 
                    ((double)bytes / (double)Constants.KB).ToString("F02"));
            else
                return string.Format("{0} b", bytes);
        }

        private string getBPSInfo(Flow flow)
        {
            return string.Format("{0} bps", 
                (flow.BytesAB + flow.BytesBA) / flow.Length.TotalSeconds);
        }

        private string getSubnodeTimeInfo(Flow flow)
        {
            TimeSpan interval = flow.EndTime - flow.StartTime;
            if(interval.TotalHours > 1)
                return String.Format("     Length: {0} {1}",  
                    interval.TotalHours.ToString("F02"), "hour");
            else if(interval.TotalMinutes > 1)
                return String.Format("     Length: {0} {1}",  
                    interval.TotalMinutes.ToString("F02"), "min");
            else
                return String.Format("     Length: {0} {1}", 
                    interval.TotalSeconds.ToString("F02"), "sec");
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlowsListView.BeginUpdate();
            FlowsListView.ExpandAll();
            FlowsListView.EndUpdate();
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FlowsListView.BeginUpdate();
            FlowsListView.CollapseAll();
            FlowsListView.EndUpdate();
        }

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            expand();
        }

        private void selectedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            collapse();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            store();
        }

        private void collapse()
        {
            FlowsListView.BeginUpdate();
            IEnumerator en = FlowsTable.SelectedItems.GetEnumerator();
            while (en.MoveNext())
            {
                (en.Current as TreeListNode).Collapse();
                (en.Current as TreeListNode).EnsureVisible();

            }
            FlowsListView.EndUpdate();
        }

        private void expand()
        {
            FlowsListView.BeginUpdate();
            IEnumerator en = FlowsTable.SelectedItems.GetEnumerator();
            while (en.MoveNext())
            {
                (en.Current as TreeListNode).Expand();
                (en.Current as TreeListNode).EnsureVisible();
            }
            FlowsListView.EndUpdate();
        }

        private void store()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            string fname;
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            fname = saveDialog.FileName;
            FlowsXmlStorage saver = new FlowsXmlStorage();
            List<Flow> flows = new List<Flow>();
            IEnumerator en = FlowsTable.SelectedItems.GetEnumerator();
            while (en.MoveNext())
            {
                flows.Add((en.Current as TreeListNode).Tag as Flow);
            }
            saver.Store(flows, fname);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFlows();
        }

        private void FlowsListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteFlows();
            else if (e.KeyCode == Keys.F5)
                _main.MemorizeRefresh(true);
        }

        private void deleteFlows()
        {
            IEnumerator en = FlowsTable.SelectedItems.GetEnumerator();
            TreeListNode node;
            while (en.MoveNext())
            {
                node = en.Current as TreeListNode;
                _main.DeleteFlow(node.Tag as Flow);
                node.Nodes.Clear();
                FlowsListView.Nodes.Remove(node);
            }
            _main.MemorizeRefresh(false);
        }
	}
}
