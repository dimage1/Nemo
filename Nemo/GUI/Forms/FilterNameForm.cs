using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nemo.GUI
{
    public partial class FilterNameForm : Form
    {
        Options _options;
        string _oldName;

        public FilterNameForm(Options options, string oldName)
        {
            InitializeComponent();
            _options = options;
            _oldName = oldName;
            FilterNameTextBox.Text = (string.IsNullOrEmpty(_oldName)) ? "Filter_" + DateTime.Now.ToString("HH:mm:ss") : _oldName;
        }

        private void Rename()
        {
            if (String.IsNullOrEmpty(FilterNameTextBox.Text))
            {
                MessageBox.Show("Please specify non empty name", "Error");
                return;
            }
            bool res = (string.IsNullOrEmpty(_oldName)) ?
                _options.CustomFilters.AddFilter(FilterNameTextBox.Text) :
                _options.CustomFilters.RenameFilter(_oldName, FilterNameTextBox.Text);
            if (!res)
            {
                MessageBox.Show(_options.CustomFilters.ErrorMsg, "Error");
                return;
            }
            try
            {
                _options.store();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Failed to store configuration: " + ee.Message, "Error");
                return;
            }
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void FilterNameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Rename();
            else if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
