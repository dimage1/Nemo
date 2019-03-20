namespace Nemo.GUI
{
    partial class FiltersHelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Numeric. Operations: ==  !=  >  <  *  / % -  +  &  |  >>  <<", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("String. Operations: ==  =()  !=", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("IP. Operations: ==  &", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Boolean.  Operations:   !", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("General Samples. Operations: ! && ||", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "ipsrc",
            "ipsrc == 192.168.0.12"}, -1, System.Drawing.Color.Maroon, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ipdst", System.Drawing.Color.Maroon, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ipdst & 192.168.0.0/24", System.Drawing.Color.Red, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "portsrc",
            "portsrc == 110"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "portdst",
            "portdst > 10000"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "bytessrc",
            "bytessrc & 511 == 0"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "bytesdst",
            "bytesdst < 100"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "bytes",
            "(bytes >> 2) == 4"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "packetssrc",
            "packetssrc > 64 * 512"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "packetsdst",
            "packetsdst == 0"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "packets",
            "(packets << 2) == 16"}, -1, System.Drawing.Color.Purple, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "serv",
            "serv == \"pop3\""}, -1, System.Drawing.Color.Green, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "namesrc",
            "namesrc != \"localhost\""}, -1, System.Drawing.Color.Green, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "namedst",
            "namedst = (\"goo\")"}, -1, System.Drawing.Color.Green, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "----",
            "namesrc == \"alice\" && bytes > 10000"}, -1, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "----",
            "serv == \"http\" && (ipsrc & 192.168.10.0/24) && ipdst == 65.123.11.11"}, -1, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "----",
            "packets > 1000000 && !(serv == \"pop3\" || serv == \"smtp\") "}, -1, System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "----",
            "(bytes / packets < 40) || bytes < 512"}, -1, System.Drawing.Color.Black, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "tran",
            "tran == \"TCP\""}, -1, System.Drawing.Color.Green, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem(new string[] {
            "localsrc",
            "localsrc"}, -1, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))), System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem(new string[] {
            "localdst",
            "!localdst"}, -1, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))), System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem(new string[] {
            "----",
            "localsrc && localdst"}, -1);
            this.panel1 = new System.Windows.Forms.Panel();
            this.HelpListView = new System.Windows.Forms.ListView();
            this.NameColumn = new System.Windows.Forms.ColumnHeader();
            this.ExampleColumn = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.HelpListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 559);
            this.panel1.TabIndex = 0;
            // 
            // HelpListView
            // 
            this.HelpListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.ExampleColumn});
            this.HelpListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpListView.FullRowSelect = true;
            this.HelpListView.GridLines = true;
            listViewGroup1.Header = "Numeric. Operations: ==  !=  >  <  *  / % -  +  &  |  >>  <<";
            listViewGroup1.Name = "NumericViewGroup";
            listViewGroup2.Header = "String. Operations: ==  =()  !=";
            listViewGroup2.Name = "StringViewGroup";
            listViewGroup3.Header = "IP. Operations: ==  &";
            listViewGroup3.Name = "IptViewGroup";
            listViewGroup4.Header = "Boolean.  Operations:   !";
            listViewGroup4.Name = "BoolGroup";
            listViewGroup5.Header = "General Samples. Operations: ! && ||";
            listViewGroup5.Name = "GeneralViewGroup";
            this.HelpListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            listViewItem1.Group = listViewGroup3;
            listViewItem1.ToolTipText = "Source IP equals to 192.168.0.12";
            listViewItem2.Group = listViewGroup3;
            listViewItem2.ToolTipText = "Destination IP from 192.168.0.0/24 subnet";
            listViewItem3.Group = listViewGroup1;
            listViewItem3.ToolTipText = "Source Port";
            listViewItem4.Group = listViewGroup1;
            listViewItem4.ToolTipText = "Destination Port";
            listViewItem5.Group = listViewGroup1;
            listViewItem5.ToolTipText = "Source Bytes";
            listViewItem6.Group = listViewGroup1;
            listViewItem6.ToolTipText = "Destination Bytes";
            listViewItem7.Group = listViewGroup1;
            listViewItem7.ToolTipText = "Sum of Source and Destination Bytes with right shift";
            listViewItem8.Group = listViewGroup1;
            listViewItem8.ToolTipText = "Source Packets";
            listViewItem9.Group = listViewGroup1;
            listViewItem9.ToolTipText = "Destination Packets";
            listViewItem10.Group = listViewGroup1;
            listViewItem10.ToolTipText = "Sum of Source and Destination Packets with left shift";
            listViewItem11.Group = listViewGroup2;
            listViewItem11.ToolTipText = "Service is pop3";
            listViewItem12.Group = listViewGroup2;
            listViewItem12.ToolTipText = "Source Name not equals to \"localhost\"";
            listViewItem13.Group = listViewGroup2;
            listViewItem13.ToolTipText = "Destination name starts with \"goo\"";
            listViewItem14.Group = listViewGroup5;
            listViewItem14.ToolTipText = "Source Name equals to \"alice\" and total Bytes number greater then 1000";
            listViewItem15.Group = listViewGroup5;
            listViewItem15.ToolTipText = "Service is HTTP, Source IP from 192.168.10.0/24 subnet and Destination IP equals " +
                "to 65.123.11.11";
            listViewItem16.Group = listViewGroup5;
            listViewItem16.ToolTipText = "Total Packets number greater then 1 million and Service is not mail";
            listViewItem17.Group = listViewGroup5;
            listViewItem17.ToolTipText = "Average Bytes per Packet less then 40 or total Bytes number less then 512";
            listViewItem18.Group = listViewGroup2;
            listViewItem18.ToolTipText = "Transport equals to TCP";
            listViewItem19.Group = listViewGroup4;
            listViewItem19.ToolTipText = "Source host is local";
            listViewItem20.Group = listViewGroup4;
            listViewItem20.ToolTipText = "Destination host is not local";
            listViewItem21.Group = listViewGroup5;
            listViewItem21.ToolTipText = "Local Flows only";
            this.HelpListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21});
            this.HelpListView.LabelEdit = true;
            this.HelpListView.Location = new System.Drawing.Point(0, 0);
            this.HelpListView.Name = "HelpListView";
            this.HelpListView.ShowItemToolTips = true;
            this.HelpListView.Size = new System.Drawing.Size(415, 559);
            this.HelpListView.TabIndex = 0;
            this.HelpListView.UseCompatibleStateImageBehavior = false;
            this.HelpListView.View = System.Windows.Forms.View.Details;
            this.HelpListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 72;
            // 
            // ExampleColumn
            // 
            this.ExampleColumn.Text = "Example";
            this.ExampleColumn.Width = 338;
            // 
            // FiltersHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 559);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltersHelpForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Custom Filters Help";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView HelpListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader ExampleColumn;
    }
}