namespace Nemo.GUI
{
    partial class FlowsForm
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
            this.components = new System.ComponentModel.Container();
            this.FlowsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlowsListView = new Nemo.GUI.TreeListView();
            this.DateColumn = new System.Windows.Forms.ColumnHeader();
            this.ServColumn = new System.Windows.Forms.ColumnHeader();
            this.IpAColumn = new System.Windows.Forms.ColumnHeader();
            this.PortAColumn = new System.Windows.Forms.ColumnHeader();
            this.PortBColumn = new System.Windows.Forms.ColumnHeader();
            this.IPBColumn = new System.Windows.Forms.ColumnHeader();
            this.TransportColumn = new System.Windows.Forms.ColumnHeader();
            this.FlowsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowsContextMenu
            // 
            this.FlowsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseToolStripMenuItem,
            this.expandToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.FlowsContextMenu.Name = "FlowsContextMenu";
            this.FlowsContextMenu.Size = new System.Drawing.Size(118, 92);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem1,
            this.selectedToolStripMenuItem1});
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            this.collapseToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.collapseToolStripMenuItem.Text = "Collapse";
            // 
            // allToolStripMenuItem1
            // 
            this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
            this.allToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.allToolStripMenuItem1.Text = "All";
            this.allToolStripMenuItem1.Click += new System.EventHandler(this.allToolStripMenuItem1_Click);
            // 
            // selectedToolStripMenuItem1
            // 
            this.selectedToolStripMenuItem1.Name = "selectedToolStripMenuItem1";
            this.selectedToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.selectedToolStripMenuItem1.Text = "Selected";
            this.selectedToolStripMenuItem1.Click += new System.EventHandler(this.selectedToolStripMenuItem1_Click);
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.selectedToolStripMenuItem});
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.selectedToolStripMenuItem.Text = "Selected";
            this.selectedToolStripMenuItem.Click += new System.EventHandler(this.selectedToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // FlowsListView
            // 
            this.FlowsListView.AllowColumnReorder = true;
            this.FlowsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DateColumn,
            this.TransportColumn,
            this.ServColumn,
            this.IpAColumn,
            this.PortAColumn,
            this.PortBColumn,
            this.IPBColumn});
            this.FlowsListView.ContextMenuStrip = this.FlowsContextMenu;
            this.FlowsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowsListView.FullRowSelect = true;
            this.FlowsListView.GridLines = true;
            this.FlowsListView.ImageListsInitialized = false;
            this.FlowsListView.Location = new System.Drawing.Point(0, 0);
            this.FlowsListView.Name = "FlowsListView";
            this.FlowsListView.Size = new System.Drawing.Size(931, 424);
            this.FlowsListView.TabIndex = 0;
            this.FlowsListView.TileSize = new System.Drawing.Size(3, 3);
            this.FlowsListView.UseCompatibleStateImageBehavior = false;
            this.FlowsListView.View = System.Windows.Forms.View.Details;
            this.FlowsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlowsListView_KeyDown);
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Time";
            this.DateColumn.Width = 163;
            // 
            // ServColumn
            // 
            this.ServColumn.Text = "Service";
            this.ServColumn.Width = 80;
            // 
            // IpAColumn
            // 
            this.IpAColumn.Text = "Source";
            this.IpAColumn.Width = 120;
            // 
            // PortAColumn
            // 
            this.PortAColumn.Text = "SrcPort";
            this.PortAColumn.Width = 50;
            // 
            // PortBColumn
            // 
            this.PortBColumn.Text = "DstPort";
            this.PortBColumn.Width = 55;
            // 
            // IPBColumn
            // 
            this.IPBColumn.Text = "Destination";
            this.IPBColumn.Width = 120;
            // 
            // TransportColumn
            // 
            this.TransportColumn.Text = "Tran";
            this.TransportColumn.Width = 48;
            // 
            // FlowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 424);
            this.CloseButton = false;
            this.Controls.Add(this.FlowsListView);
            this.HideOnClose = true;
            this.Name = "FlowsForm";
            this.TabText = "Flows";
            this.Text = "Flows";
            this.FlowsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeListView FlowsListView;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ColumnHeader IpAColumn;
        private System.Windows.Forms.ColumnHeader PortAColumn;
        private System.Windows.Forms.ColumnHeader IPBColumn;
        private System.Windows.Forms.ColumnHeader PortBColumn;
        private System.Windows.Forms.ColumnHeader ServColumn;
        private System.Windows.Forms.ContextMenuStrip FlowsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader TransportColumn;


    }
}