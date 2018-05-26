namespace Chooser
{
    partial class DeveloperInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeveloperInfo));
            this.lv_workspace = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lv_workspace
            // 
            this.lv_workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_workspace.ForeColor = System.Drawing.Color.Red;
            this.lv_workspace.Location = new System.Drawing.Point(0, 0);
            this.lv_workspace.Name = "lv_workspace";
            this.lv_workspace.Size = new System.Drawing.Size(440, 283);
            this.lv_workspace.TabIndex = 0;
            this.lv_workspace.UseCompatibleStateImageBehavior = false;
            this.lv_workspace.SelectedIndexChanged += new System.EventHandler(this.lv_workspace_SelectedIndexChanged);
            this.lv_workspace.DoubleClick += new System.EventHandler(this.lv_workspace_DoubleClick);
            // 
            // DeveloperInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(440, 283);
            this.Controls.Add(this.lv_workspace);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeveloperInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeveloperInfo";
            this.Load += new System.EventHandler(this.DeveloperInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_workspace;
    }
}