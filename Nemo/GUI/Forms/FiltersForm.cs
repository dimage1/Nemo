using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Nemo.GUI
{
    public partial class FiltersForm : DockContent
    {
        private Options _options;
        private MainForm _mainForm;
        public TreeNode ClickedNode;

        public FiltersTreeView FiltersTree
        {
            get { return filtersTreeView; }
        }

		public string Filter
		{
            get
            {
                return FilterStripTextBox.Text;
            }
            set
            {
                FilterStripTextBox.Text = value;
            }
		}

        public FiltersForm(Options options, MainForm main)
        {
            InitializeComponent();
            _options = options;
            _mainForm = main;
        }
        
        public void CreateFilterNodes(List<FilterName> filters)
        {
            this.filtersTreeView.CreateMainNodes(filters);
        }

        private void ExpandStripButton_Click(object sender, EventArgs e)
        {
            filtersTreeView.ExpandAll();
        }

        private void CollapseStripButton_Click(object sender, EventArgs e)
        {
            filtersTreeView.CollapseAll();
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            if (!_options.CustomFilters.BuildFilter(FilterStripTextBox.Text))
            {
                MessageBox.Show(_options.CustomFilters.ErrorMsg, "Error");
                return;
            }
            RenameFilter("");
         }

        public void RenameFilter(string oldName)
        {
            FilterNameForm options = new FilterNameForm(_options, oldName);
            options.ShowDialog(this);
            _mainForm.RefreshFiltersTree();
        }

        private void DeleteStripButton_Click(object sender, EventArgs e)
        {
            _mainForm.DeleteCustomFilter();
        }

        private void UpdateStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = filtersTreeView.SelectedNode;
                if (node.Parent.Name.Equals(FilterName.Custom.ToString()))
                {
                    if (!_options.CustomFilters.BuildFilter(FilterStripTextBox.Text))
                    {
                        MessageBox.Show(_options.CustomFilters.ErrorMsg, "Error");
                        return;
                    }
                    _options.CustomFilters.UpdateFilter(node.Name);
                    try
                    {
                        _options.store();
                    }
                    catch(Exception ee)
                    {
                        MessageBox.Show("Failed to store configuration: " + ee.Message, "Error");
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            FiltersHelpForm help = new FiltersHelpForm(this);
            help.Show();
        }

        private void filtersTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && ClickedNode.Parent.Name.Equals(FilterName.Custom.ToString()))
                _mainForm.DeleteCustomFilter();
            else if (e.KeyCode == Keys.F5)
                _mainForm.MemorizeRefresh(true);
        }

        private void filtersTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ClickedNode = e.Node;
        }
    }
}
