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
    public partial class FiltersHelpForm : Form
    {
        private FiltersForm _filtersForm;

        public FiltersHelpForm(FiltersForm filtersForm)
        {
            InitializeComponent();
            _filtersForm = filtersForm;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                _filtersForm.Filter += " " + HelpListView.FocusedItem.SubItems[1].Text;
            }
            catch { }
        }
    }
}
