namespace Crow.Little.CodeGenerator
{
    partial class FormTableFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTableFilter));
            this.tplTableFilter = new System.Windows.Forms.TableLayoutPanel();
            this.lbxTableList = new System.Windows.Forms.ListBox();
            this.lbxTableList4Generate = new System.Windows.Forms.ListBox();
            this.tlpEditBar = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerateAll = new System.Windows.Forms.Button();
            this.btnGenerateSelected = new System.Windows.Forms.Button();
            this.btnUnGenerateSelected = new System.Windows.Forms.Button();
            this.btnUnGenerateAll = new System.Windows.Forms.Button();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.tplTableFilter.SuspendLayout();
            this.tlpEditBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplTableFilter
            // 
            this.tplTableFilter.ColumnCount = 3;
            this.tplTableFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplTableFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tplTableFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplTableFilter.Controls.Add(this.lbxTableList, 0, 1);
            this.tplTableFilter.Controls.Add(this.lbxTableList4Generate, 2, 1);
            this.tplTableFilter.Controls.Add(this.tlpEditBar, 0, 7);
            this.tplTableFilter.Controls.Add(this.btnGenerateAll, 1, 2);
            this.tplTableFilter.Controls.Add(this.btnGenerateSelected, 1, 3);
            this.tplTableFilter.Controls.Add(this.btnUnGenerateSelected, 1, 4);
            this.tplTableFilter.Controls.Add(this.btnUnGenerateAll, 1, 5);
            this.tplTableFilter.Controls.Add(this.lblLeft, 0, 0);
            this.tplTableFilter.Controls.Add(this.lblRight, 2, 0);
            this.tplTableFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplTableFilter.Location = new System.Drawing.Point(0, 0);
            this.tplTableFilter.Name = "tplTableFilter";
            this.tplTableFilter.RowCount = 8;
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplTableFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tplTableFilter.Size = new System.Drawing.Size(556, 465);
            this.tplTableFilter.TabIndex = 0;
            // 
            // lbxTableList
            // 
            this.lbxTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxTableList.FormattingEnabled = true;
            this.lbxTableList.ItemHeight = 12;
            this.lbxTableList.Location = new System.Drawing.Point(3, 33);
            this.lbxTableList.Name = "lbxTableList";
            this.tplTableFilter.SetRowSpan(this.lbxTableList, 6);
            this.lbxTableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxTableList.Size = new System.Drawing.Size(256, 394);
            this.lbxTableList.TabIndex = 0;
            this.lbxTableList.DoubleClick += new System.EventHandler(this.lbxTableList_DoubleClick);
            // 
            // lbxTableList4Generate
            // 
            this.lbxTableList4Generate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxTableList4Generate.FormattingEnabled = true;
            this.lbxTableList4Generate.ItemHeight = 12;
            this.lbxTableList4Generate.Location = new System.Drawing.Point(297, 33);
            this.lbxTableList4Generate.Name = "lbxTableList4Generate";
            this.tplTableFilter.SetRowSpan(this.lbxTableList4Generate, 6);
            this.lbxTableList4Generate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxTableList4Generate.Size = new System.Drawing.Size(256, 394);
            this.lbxTableList4Generate.TabIndex = 1;
            this.lbxTableList4Generate.DoubleClick += new System.EventHandler(this.lbxTableList4Generate_DoubleClick);
            // 
            // tlpEditBar
            // 
            this.tlpEditBar.ColumnCount = 3;
            this.tplTableFilter.SetColumnSpan(this.tlpEditBar, 3);
            this.tlpEditBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEditBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEditBar.Controls.Add(this.btnOK, 1, 0);
            this.tlpEditBar.Controls.Add(this.btnCancel, 2, 0);
            this.tlpEditBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEditBar.Location = new System.Drawing.Point(3, 433);
            this.tlpEditBar.Name = "tlpEditBar";
            this.tlpEditBar.RowCount = 1;
            this.tlpEditBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEditBar.Size = new System.Drawing.Size(550, 29);
            this.tlpEditBar.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(393, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "生  成";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(473, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateAll.Location = new System.Drawing.Point(265, 169);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.Size = new System.Drawing.Size(26, 26);
            this.btnGenerateAll.TabIndex = 3;
            this.btnGenerateAll.Text = ">>";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.btnGenerateAll_Click);
            // 
            // btnGenerateSelected
            // 
            this.btnGenerateSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateSelected.Location = new System.Drawing.Point(265, 201);
            this.btnGenerateSelected.Name = "btnGenerateSelected";
            this.btnGenerateSelected.Size = new System.Drawing.Size(26, 26);
            this.btnGenerateSelected.TabIndex = 4;
            this.btnGenerateSelected.Text = ">";
            this.btnGenerateSelected.UseVisualStyleBackColor = true;
            this.btnGenerateSelected.Click += new System.EventHandler(this.btnGenerateSelected_Click);
            // 
            // btnUnGenerateSelected
            // 
            this.btnUnGenerateSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnGenerateSelected.Location = new System.Drawing.Point(265, 233);
            this.btnUnGenerateSelected.Name = "btnUnGenerateSelected";
            this.btnUnGenerateSelected.Size = new System.Drawing.Size(26, 26);
            this.btnUnGenerateSelected.TabIndex = 5;
            this.btnUnGenerateSelected.Text = "<";
            this.btnUnGenerateSelected.UseVisualStyleBackColor = true;
            this.btnUnGenerateSelected.Click += new System.EventHandler(this.btnUnGenerateSelected_Click);
            // 
            // btnUnGenerateAll
            // 
            this.btnUnGenerateAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnGenerateAll.Location = new System.Drawing.Point(265, 265);
            this.btnUnGenerateAll.Name = "btnUnGenerateAll";
            this.btnUnGenerateAll.Size = new System.Drawing.Size(26, 26);
            this.btnUnGenerateAll.TabIndex = 6;
            this.btnUnGenerateAll.Text = "<<";
            this.btnUnGenerateAll.UseVisualStyleBackColor = true;
            this.btnUnGenerateAll.Click += new System.EventHandler(this.btnUnGenerateAll_Click);
            // 
            // lblLeft
            // 
            this.lblLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeft.Location = new System.Drawing.Point(3, 0);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(256, 30);
            this.lblLeft.TabIndex = 7;
            this.lblLeft.Text = "原数据表:";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRight
            // 
            this.lblRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRight.Location = new System.Drawing.Point(297, 0);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(256, 30);
            this.lblRight.TabIndex = 8;
            this.lblRight.Text = "待生成表:";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormTableFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 465);
            this.Controls.Add(this.tplTableFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTableFilter";
            this.Text = "数据表筛选";
            this.Load += new System.EventHandler(this.FormTableFilter_Load);
            this.tplTableFilter.ResumeLayout(false);
            this.tlpEditBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplTableFilter;
        private System.Windows.Forms.ListBox lbxTableList;
        private System.Windows.Forms.ListBox lbxTableList4Generate;
        private System.Windows.Forms.TableLayoutPanel tlpEditBar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerateAll;
        private System.Windows.Forms.Button btnGenerateSelected;
        private System.Windows.Forms.Button btnUnGenerateSelected;
        private System.Windows.Forms.Button btnUnGenerateAll;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
    }
}