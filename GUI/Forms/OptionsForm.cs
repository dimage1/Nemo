using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Nemo.Core;

namespace Nemo.GUI
{
	public partial class OptionsForm : Form
	{
		private Options _options;
        private Flows _flows;

		public OptionsForm(Options options, Flows flows)
		{
			InitializeComponent();
			_options = options;
			uncheckAllFilters();
			for (int i = 0; i < FiltersTreeView.Nodes.Count; i++)
			{
				TreeNode node = FiltersTreeView.Nodes[i];
				if (node.Text.Equals("Address") && _options.CheckedFilters.Contains(FilterName.Address))
				{
					FiltersTreeView.Nodes[i].Checked = true;
				}
				else if (node.Text.Equals("Port") && _options.CheckedFilters.Contains(FilterName.Port))
				{
					FiltersTreeView.Nodes[i].Checked = true;
				}
				else if (node.Text.Equals("Service") && _options.CheckedFilters.Contains(FilterName.Service))
				{
					FiltersTreeView.Nodes[i].Checked = true;
				}
				else if (node.Text.Equals("Time") && _options.CheckedFilters.Contains(FilterName.Time))
				{
					FiltersTreeView.Nodes[i].Checked = true;
				}
				else if (node.Text.Equals("Size") && _options.CheckedFilters.Contains(FilterName.Size))
				{
					FiltersTreeView.Nodes[i].Checked = true;
				}
				else if (node.Text.Equals("Custom") && _options.CheckedFilters.Contains(FilterName.Custom))
				{
					FiltersTreeView.Nodes[i].Checked = true;
				}
			}
            fillAliases();
            fillLocals();
            _flows = flows;
		}

        private void fillAliases()
        {
            foreach (string ip in _options.Aliases.Keys)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(AliasGridView);
                row.SetValues(ip, _options.Aliases[ip]);
                AliasGridView.Rows.Add(row);
            }
        }

        private void fillLocals()
        {
            foreach (IPRange range in _options.Locals)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(LocalsDataGrid);
                row.SetValues(range.Text);
                LocalsDataGrid.Rows.Add(row);
            }
        }

        private void setNewAliases()
        {
            _options.Aliases.Clear();
            string name = string.Empty;
            string ip = string.Empty;
            foreach (DataGridViewRow row in AliasGridView.Rows)
            {
                
                try
                {
                    name = row.AccessibilityObject.GetChild(2).Value;
                    ip = row.AccessibilityObject.GetChild(1).Value;
                    if (!name.Equals("(null)") && !string.IsNullOrEmpty("(null)"))
                    {
                        //check that ip valid
                        IPAddress.Parse(ip);
                        _options.Aliases[ip] = name;
                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show(String.Format("Invalid alias {0}->{1}: {2}", ip, name, ee.Message), "Error");
                }
            }
        }

        private void setNewLocals()
        {
            _options.Locals.Clear();
            IPRange range = new IPRange();
            foreach (DataGridViewRow row in LocalsDataGrid.Rows)
            {
                if (range.Parse(row.AccessibilityObject.GetChild(1).Value))
                {
                    _options.Locals.Add(range);
                    range = new IPRange();
                }
            }
        }

		private void FiltersClearAllButton_Click(object sender, EventArgs e)
		{
			uncheckAllFilters();
		}

		private void uncheckAllFilters()
		{
			for (int i = 0; i < FiltersTreeView.Nodes.Count; i++)
			{
				FiltersTreeView.Nodes[i].Checked = false;
			}
		}

		private void FiletrsSelectAllButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < FiltersTreeView.Nodes.Count; i++)
			{
				FiltersTreeView.Nodes[i].Checked = true;
			}
		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _options.CheckedFilters.Clear();
            for (int i = 0; i < FiltersTreeView.Nodes.Count; i++)
            {
                TreeNode node = FiltersTreeView.Nodes[i];
                if (node.Checked)
                {
                    if (node.Text.Equals("Address"))
                    {
                        _options.CheckedFilters.Add(FilterName.Address);
                    }
                    else if (node.Text.Equals("Port"))
                    {
                        _options.CheckedFilters.Add(FilterName.Port);
                    }
                    else if (node.Text.Equals("Service"))
                    {
                        _options.CheckedFilters.Add(FilterName.Service);
                    }
                    else if (node.Text.Equals("Time"))
                    {
                        _options.CheckedFilters.Add(FilterName.Time);
                    }
                    else if (node.Text.Equals("Custom"))
                    {
                        _options.CheckedFilters.Add(FilterName.Custom);
                    }
                    else if (node.Text.Equals("Size"))
                    {
                        _options.CheckedFilters.Add(FilterName.Size);
                    }
                }
            }
            setNewAliases();
            setNewLocals();
            try
            {
                _options.store();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Failed to store configuration: " + ee.Message, "Error");
            }
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AutoDnsButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in AliasGridView.SelectedRows)
            {
                try
                {
                    row.AccessibilityObject.GetChild(2).Value = 
                        Dns.GetHostByAddress(IPAddress.Parse(
                        row.AccessibilityObject.GetChild(1).Value)).HostName;
                    AliasGridView.Update();
                }
                catch
                {
                    row.AccessibilityObject.GetChild(1).Value = "!!!" + 
                        row.AccessibilityObject.GetChild(1).Value;
                }
            }
        }

        private void LoadFlowsButton_Click(object sender, EventArgs e)
        {
            List<string> ips = _flows.getIPs();
            List<string> exist = new List<string>();
            foreach (DataGridViewRow row in AliasGridView.Rows)
            {
                exist.Add(row.AccessibilityObject.GetChild(1).Value);
            }
            foreach (string ip in ips)
            {
                if (!exist.Contains(ip))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(AliasGridView);
                    row.SetValues(ip, "");
                    AliasGridView.Rows.Add(row);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool errors = false;
            foreach (DataGridViewRow row in AliasGridView.SelectedRows)
            {
                try
                {
                    IPAddress.Parse(row.AccessibilityObject.GetChild(1).Value);
                }
                catch
                {
                    errors = true;
                    row.AccessibilityObject.GetChild(1).Value = "!!!" + row.AccessibilityObject.GetChild(1).Value;
                }
            }
            MessageBox.Show((errors) ? "Invalid values marked with !!!" : "No errors have been detected", "Verified");
        }

        private void ExamplesButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(LocalsDataGrid);
            row.SetValues("192.168.0.12");
            LocalsDataGrid.Rows.Add(row);
            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(LocalsDataGrid);
            row1.SetValues("10.0.0.0-10.0.0.12");
            LocalsDataGrid.Rows.Add(row1);
            DataGridViewRow row2 = new DataGridViewRow();
            row2.CreateCells(LocalsDataGrid);
            row2.SetValues("10.1.0.0/16");
            LocalsDataGrid.Rows.Add(row2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPRange range = new IPRange();
            bool errors = false;
            foreach (DataGridViewRow row in LocalsDataGrid.SelectedRows)
            {
                if(!range.Parse(row.AccessibilityObject.GetChild(1).Value))
                {
                    errors = true;
                    row.AccessibilityObject.GetChild(1).Value = "!!!" + row.AccessibilityObject.GetChild(1).Value;
                }
            }
            MessageBox.Show((errors) ? "Invalid values marked with !!!" : "No errors have been detected", "Verified");
        }

        private void ExampleAliasButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(AliasGridView);
            row.SetValues("192.168.0.12", "Alice");
            AliasGridView.Rows.Add(row);
            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(AliasGridView);
            row1.SetValues("10.0.0.11", "Bob");
            AliasGridView.Rows.Add(row1);
        }
	}
}
