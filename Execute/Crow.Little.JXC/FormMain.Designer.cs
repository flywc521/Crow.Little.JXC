namespace Crow.Little.JXC
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tclMain = new CommonControl.CloseableTabControl();
            this.SuspendLayout();
            
            // 
            // tclMain
            // 
            this.tclMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tclMain.Location = new System.Drawing.Point(0, 56);
            this.tclMain.Margin = new System.Windows.Forms.Padding(2);
            this.tclMain.Name = "tclMain";
            this.tclMain.Padding = new System.Drawing.Point(16, 4);
            this.tclMain.SelectedIndex = 0;
            this.tclMain.Size = new System.Drawing.Size(1008, 652);
            this.tclMain.TabIndex = 1;
            this.tclMain.Text = "tabControl1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tclMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "布衣布行";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Crow.Little.CommonControl.CloseableTabControl tclMain;
    }
}

