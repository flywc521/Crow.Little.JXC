namespace Crow.Little.CodeGenerator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tlpProject = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.colGenerate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProjectPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpProject
            // 
            this.tlpProject.ColumnCount = 3;
            this.tlpProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProject.Controls.Add(this.btnOpenProject, 0, 0);
            this.tlpProject.Controls.Add(this.btnNewProject, 1, 0);
            this.tlpProject.Controls.Add(this.dgvProject, 0, 1);
            this.tlpProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProject.Location = new System.Drawing.Point(0, 0);
            this.tlpProject.Name = "tlpProject";
            this.tlpProject.RowCount = 2;
            this.tlpProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProject.Size = new System.Drawing.Size(535, 334);
            this.tlpProject.TabIndex = 0;
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenProject.Enabled = false;
            this.btnOpenProject.Location = new System.Drawing.Point(3, 3);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(74, 24);
            this.btnOpenProject.TabIndex = 0;
            this.btnOpenProject.Text = "打 开";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewProject.Location = new System.Drawing.Point(83, 3);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(74, 24);
            this.btnNewProject.TabIndex = 1;
            this.btnNewProject.Text = "新 建";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // dgvProject
            // 
            this.dgvProject.AllowUserToAddRows = false;
            this.dgvProject.AllowUserToDeleteRows = false;
            this.dgvProject.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGenerate,
            this.colProjectName,
            this.colProjectPath});
            this.tlpProject.SetColumnSpan(this.dgvProject, 3);
            this.dgvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProject.Location = new System.Drawing.Point(3, 33);
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.RowHeadersVisible = false;
            this.dgvProject.RowTemplate.Height = 23;
            this.dgvProject.ShowCellErrors = false;
            this.dgvProject.ShowEditingIcon = false;
            this.dgvProject.ShowRowErrors = false;
            this.dgvProject.Size = new System.Drawing.Size(529, 298);
            this.dgvProject.TabIndex = 2;
            this.dgvProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProject_CellContentClick);
            this.dgvProject.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProject_CellContentDoubleClick);
            // 
            // colGenerate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "执  行";
            this.colGenerate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colGenerate.FillWeight = 80F;
            this.colGenerate.HeaderText = "";
            this.colGenerate.MinimumWidth = 80;
            this.colGenerate.Name = "colGenerate";
            this.colGenerate.Width = 80;
            // 
            // colProjectName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colProjectName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colProjectName.FillWeight = 120F;
            this.colProjectName.HeaderText = "项目";
            this.colProjectName.MinimumWidth = 120;
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.ReadOnly = true;
            this.colProjectName.Width = 120;
            // 
            // colProjectPath
            // 
            this.colProjectPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colProjectPath.DefaultCellStyle = dataGridViewCellStyle4;
            this.colProjectPath.HeaderText = "项目路径";
            this.colProjectPath.Name = "colProjectPath";
            this.colProjectPath.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 334);
            this.Controls.Add(this.tlpProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "云中旗@内部代码生成工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tlpProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpProject;
        private System.Windows.Forms.Button btnOpenProject;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.DataGridViewButtonColumn colGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProjectPath;




    }
}

