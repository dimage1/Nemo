namespace Nemo.GUI
{
    partial class InterfacesForm
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
            this.InterfacesTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // InterfacesTreeView
            // 
            this.InterfacesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InterfacesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InterfacesTreeView.ForeColor = System.Drawing.Color.Black;
            this.InterfacesTreeView.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.InterfacesTreeView.ItemHeight = 20;
            this.InterfacesTreeView.LabelEdit = true;
            this.InterfacesTreeView.Location = new System.Drawing.Point(1, 1);
            this.InterfacesTreeView.Name = "InterfacesTreeView";
            this.InterfacesTreeView.ShowLines = false;
            this.InterfacesTreeView.ShowNodeToolTips = true;
            this.InterfacesTreeView.ShowRootLines = false;
            this.InterfacesTreeView.Size = new System.Drawing.Size(474, 151);
            this.InterfacesTreeView.TabIndex = 0;
            this.InterfacesTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.InterfacesTreeView_NodeMouseDoubleClick);
            // 
            // InterfacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(476, 153);
            this.Controls.Add(this.InterfacesTreeView);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfacesForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Interface";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView InterfacesTreeView;



    }
}