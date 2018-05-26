namespace Chooser
{
    partial class OnlineWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineWeb));
            this.lv_onlineview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_onlineview
            // 
            this.lv_onlineview.BackColor = System.Drawing.SystemColors.Window;
            this.lv_onlineview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_onlineview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_onlineview.ContextMenuStrip = this.contextMenuStrip1;
            this.lv_onlineview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_onlineview.ForeColor = System.Drawing.Color.Teal;
            this.lv_onlineview.FullRowSelect = true;
            this.lv_onlineview.GridLines = true;
            this.lv_onlineview.Location = new System.Drawing.Point(0, 0);
            this.lv_onlineview.Name = "lv_onlineview";
            this.lv_onlineview.Size = new System.Drawing.Size(440, 239);
            this.lv_onlineview.SmallImageList = this.imageList1;
            this.lv_onlineview.TabIndex = 0;
            this.toolTip1.SetToolTip(this.lv_onlineview, "双击选中项-使用默认浏览器打开该网站\r\n右击-刷新网络链接状态\r\n");
            this.lv_onlineview.UseCompatibleStateImageBehavior = false;
            this.lv_onlineview.View = System.Windows.Forms.View.Details;
            this.lv_onlineview.DoubleClick += new System.EventHandler(this.lv_onlineview_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "站点名[Site Name]";
            this.columnHeader1.Width = 163;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "域名[Domain Name]";
            this.columnHeader2.Width = 274;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "err.png");
            this.imageList1.Images.SetKeyName(1, "gt.png");
            this.imageList1.Images.SetKeyName(2, "loading.png");
            this.imageList1.Images.SetKeyName(3, "ok.png");
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "右击有惊喜噢~";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新RefreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            // 
            // 刷新RefreshToolStripMenuItem
            // 
            this.刷新RefreshToolStripMenuItem.Name = "刷新RefreshToolStripMenuItem";
            this.刷新RefreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.刷新RefreshToolStripMenuItem.Text = "刷新[Refresh]";
            this.刷新RefreshToolStripMenuItem.Click += new System.EventHandler(this.刷新RefreshToolStripMenuItem_Click);
            // 
            // OnlineWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(440, 239);
            this.Controls.Add(this.lv_onlineview);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnlineWeb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlineWeb";
            this.Load += new System.EventHandler(this.OnlineWeb_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_onlineview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新RefreshToolStripMenuItem;
    }
}