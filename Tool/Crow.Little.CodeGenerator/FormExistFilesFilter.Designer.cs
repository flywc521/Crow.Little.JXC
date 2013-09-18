namespace Crow.Little.CodeGenerator
{
    partial class FormExistFilesFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExistFilesFilter));
            this.lblMessage = new System.Windows.Forms.Label();
            this.dgvExistFilesFilter = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDALName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.llbSelectAll = new System.Windows.Forms.LinkLabel();
            this.lblSplit = new System.Windows.Forms.Label();
            this.llbSelectNone = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistFilesFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(185, 12);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "以下文件以存在，是否覆盖生成？";
            // 
            // dgvExistFilesFilter
            // 
            this.dgvExistFilesFilter.AllowUserToAddRows = false;
            this.dgvExistFilesFilter.AllowUserToDeleteRows = false;
            this.dgvExistFilesFilter.AllowUserToResizeRows = false;
            this.dgvExistFilesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExistFilesFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistFilesFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colTableName,
            this.colModel,
            this.colDALName});
            this.dgvExistFilesFilter.Location = new System.Drawing.Point(14, 37);
            this.dgvExistFilesFilter.Name = "dgvExistFilesFilter";
            this.dgvExistFilesFilter.RowHeadersVisible = false;
            this.dgvExistFilesFilter.RowTemplate.Height = 23;
            this.dgvExistFilesFilter.ShowCellErrors = false;
            this.dgvExistFilesFilter.ShowEditingIcon = false;
            this.dgvExistFilesFilter.ShowRowErrors = false;
            this.dgvExistFilesFilter.Size = new System.Drawing.Size(485, 408);
            this.dgvExistFilesFilter.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(343, 456);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确  定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(424, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colCheck
            // 
            this.colCheck.FillWeight = 20F;
            this.colCheck.HeaderText = "";
            this.colCheck.MinimumWidth = 20;
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 20;
            // 
            // colTableName
            // 
            this.colTableName.HeaderText = "数据表名";
            this.colTableName.MinimumWidth = 100;
            this.colTableName.Name = "colTableName";
            this.colTableName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model文件路径";
            this.colModel.Name = "colModel";
            this.colModel.Width = 180;
            // 
            // colDALName
            // 
            this.colDALName.HeaderText = "DAL文件路径";
            this.colDALName.Name = "colDALName";
            this.colDALName.Width = 180;
            // 
            // llbSelectAll
            // 
            this.llbSelectAll.AutoSize = true;
            this.llbSelectAll.Location = new System.Drawing.Point(14, 452);
            this.llbSelectAll.Name = "llbSelectAll";
            this.llbSelectAll.Size = new System.Drawing.Size(29, 12);
            this.llbSelectAll.TabIndex = 4;
            this.llbSelectAll.TabStop = true;
            this.llbSelectAll.Text = "全选";
            this.llbSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSelectAll_LinkClicked);
            // 
            // lblSplit
            // 
            this.lblSplit.AutoSize = true;
            this.lblSplit.Location = new System.Drawing.Point(45, 452);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(11, 12);
            this.lblSplit.TabIndex = 5;
            this.lblSplit.Text = "/";
            // 
            // llbSelectNone
            // 
            this.llbSelectNone.AutoSize = true;
            this.llbSelectNone.Location = new System.Drawing.Point(58, 452);
            this.llbSelectNone.Name = "llbSelectNone";
            this.llbSelectNone.Size = new System.Drawing.Size(41, 12);
            this.llbSelectNone.TabIndex = 6;
            this.llbSelectNone.TabStop = true;
            this.llbSelectNone.Text = "全不选";
            this.llbSelectNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSelectNone_LinkClicked);
            // 
            // FormExistFilesFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 483);
            this.Controls.Add(this.llbSelectNone);
            this.Controls.Add(this.lblSplit);
            this.Controls.Add(this.llbSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvExistFilesFilter);
            this.Controls.Add(this.lblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExistFilesFilter";
            this.Text = "提示";
            this.Load += new System.EventHandler(this.FormExistFilesFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistFilesFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridView dgvExistFilesFilter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDALName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llbSelectAll;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.LinkLabel llbSelectNone;
    }
}