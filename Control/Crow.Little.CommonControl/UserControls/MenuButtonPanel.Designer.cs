namespace Crow.Little.CommonControl
{
    partial class MenuButtonPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flpMenuButton = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpMenuButton
            // 
            this.flpMenuButton.AutoScroll = true;
            this.flpMenuButton.AutoSize = true;
            this.flpMenuButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenuButton.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenuButton.Location = new System.Drawing.Point(0, 0);
            this.flpMenuButton.Name = "flpMenuButton";
            this.flpMenuButton.Size = new System.Drawing.Size(100, 300);
            this.flpMenuButton.TabIndex = 0;
            this.flpMenuButton.WrapContents = false;
            // 
            // ctrlMenuButtonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpMenuButton);
            this.Name = "ctrlMenuButtonPanel";
            this.Size = new System.Drawing.Size(100, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMenuButton;
    }
}
