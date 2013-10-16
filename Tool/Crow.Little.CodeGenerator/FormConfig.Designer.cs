namespace Crow.Little.CodeGenerator
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.tclSetting = new System.Windows.Forms.TabControl();
            this.tpgProjectSetting = new System.Windows.Forms.TabPage();
            this.gbxDALSetting = new System.Windows.Forms.GroupBox();
            this.lblDAL = new System.Windows.Forms.Label();
            this.cbxDALCollision = new System.Windows.Forms.ComboBox();
            this.lblDALCollision = new System.Windows.Forms.Label();
            this.lblDALPostfix = new System.Windows.Forms.Label();
            this.tbxDALPostfix = new System.Windows.Forms.TextBox();
            this.lblDALPrefix = new System.Windows.Forms.Label();
            this.tbxDALPrefix = new System.Windows.Forms.TextBox();
            this.tbxDALNameSpace = new System.Windows.Forms.TextBox();
            this.lblDALNameSpace = new System.Windows.Forms.Label();
            this.gbxModelSetting = new System.Windows.Forms.GroupBox();
            this.lblProperty = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.cbxPropertyCollision = new System.Windows.Forms.ComboBox();
            this.lblPropertyCollision = new System.Windows.Forms.Label();
            this.lblPropertyPostfix = new System.Windows.Forms.Label();
            this.tbxPropertyPostfix = new System.Windows.Forms.TextBox();
            this.lblPropertyPrefix = new System.Windows.Forms.Label();
            this.tbxPropertyPrefix = new System.Windows.Forms.TextBox();
            this.cbxModelCollision = new System.Windows.Forms.ComboBox();
            this.lblModelCollision = new System.Windows.Forms.Label();
            this.lblModelPostfix = new System.Windows.Forms.Label();
            this.tbxModelPostfix = new System.Windows.Forms.TextBox();
            this.tbxModelNameSpace = new System.Windows.Forms.TextBox();
            this.lblModelNameSpace = new System.Windows.Forms.Label();
            this.lblModelPrefix = new System.Windows.Forms.Label();
            this.tbxModelPrefix = new System.Windows.Forms.TextBox();
            this.gbxPathSetting = new System.Windows.Forms.GroupBox();
            this.tbxSlnPath = new System.Windows.Forms.TextBox();
            this.btnDALBrower = new System.Windows.Forms.Button();
            this.lblSlnPath = new System.Windows.Forms.Label();
            this.tbxDALPath = new System.Windows.Forms.TextBox();
            this.btnSlnBrower = new System.Windows.Forms.Button();
            this.lblDALPath = new System.Windows.Forms.Label();
            this.lblModelPath = new System.Windows.Forms.Label();
            this.btnModelBrower = new System.Windows.Forms.Button();
            this.tbxModelPath = new System.Windows.Forms.TextBox();
            this.tpgDBSetting = new System.Windows.Forms.TabPage();
            this.gbxDBConnection = new System.Windows.Forms.GroupBox();
            this.cbxProvider = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlDb = new System.Windows.Forms.Panel();
            this.tclSetting.SuspendLayout();
            this.tpgProjectSetting.SuspendLayout();
            this.gbxDALSetting.SuspendLayout();
            this.gbxModelSetting.SuspendLayout();
            this.gbxPathSetting.SuspendLayout();
            this.tpgDBSetting.SuspendLayout();
            this.gbxDBConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tclSetting
            // 
            this.tclSetting.Controls.Add(this.tpgProjectSetting);
            this.tclSetting.Controls.Add(this.tpgDBSetting);
            this.tclSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.tclSetting.Location = new System.Drawing.Point(0, 0);
            this.tclSetting.Name = "tclSetting";
            this.tclSetting.SelectedIndex = 0;
            this.tclSetting.Size = new System.Drawing.Size(471, 324);
            this.tclSetting.TabIndex = 0;
            // 
            // tpgProjectSetting
            // 
            this.tpgProjectSetting.Controls.Add(this.gbxDALSetting);
            this.tpgProjectSetting.Controls.Add(this.gbxModelSetting);
            this.tpgProjectSetting.Controls.Add(this.gbxPathSetting);
            this.tpgProjectSetting.Location = new System.Drawing.Point(4, 22);
            this.tpgProjectSetting.Name = "tpgProjectSetting";
            this.tpgProjectSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpgProjectSetting.Size = new System.Drawing.Size(463, 298);
            this.tpgProjectSetting.TabIndex = 1;
            this.tpgProjectSetting.Text = "项目设置";
            this.tpgProjectSetting.UseVisualStyleBackColor = true;
            // 
            // gbxDALSetting
            // 
            this.gbxDALSetting.Controls.Add(this.lblDAL);
            this.gbxDALSetting.Controls.Add(this.cbxDALCollision);
            this.gbxDALSetting.Controls.Add(this.lblDALCollision);
            this.gbxDALSetting.Controls.Add(this.lblDALPostfix);
            this.gbxDALSetting.Controls.Add(this.tbxDALPostfix);
            this.gbxDALSetting.Controls.Add(this.lblDALPrefix);
            this.gbxDALSetting.Controls.Add(this.tbxDALPrefix);
            this.gbxDALSetting.Controls.Add(this.tbxDALNameSpace);
            this.gbxDALSetting.Controls.Add(this.lblDALNameSpace);
            this.gbxDALSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDALSetting.Location = new System.Drawing.Point(3, 213);
            this.gbxDALSetting.Name = "gbxDALSetting";
            this.gbxDALSetting.Size = new System.Drawing.Size(457, 82);
            this.gbxDALSetting.TabIndex = 13;
            this.gbxDALSetting.TabStop = false;
            this.gbxDALSetting.Text = "数据访问层设置";
            // 
            // lblDAL
            // 
            this.lblDAL.AutoSize = true;
            this.lblDAL.Location = new System.Drawing.Point(12, 49);
            this.lblDAL.Name = "lblDAL";
            this.lblDAL.Size = new System.Drawing.Size(47, 12);
            this.lblDAL.TabIndex = 22;
            this.lblDAL.Text = "DAL名称";
            // 
            // cbxDALCollision
            // 
            this.cbxDALCollision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDALCollision.FormattingEnabled = true;
            this.cbxDALCollision.Items.AddRange(new object[] {
            "首字母大写",
            "添加\"_\"前缀"});
            this.cbxDALCollision.Location = new System.Drawing.Point(347, 47);
            this.cbxDALCollision.Name = "cbxDALCollision";
            this.cbxDALCollision.Size = new System.Drawing.Size(100, 20);
            this.cbxDALCollision.TabIndex = 20;
            // 
            // lblDALCollision
            // 
            this.lblDALCollision.AutoSize = true;
            this.lblDALCollision.Location = new System.Drawing.Point(306, 49);
            this.lblDALCollision.Name = "lblDALCollision";
            this.lblDALCollision.Size = new System.Drawing.Size(35, 12);
            this.lblDALCollision.TabIndex = 19;
            this.lblDALCollision.Text = "冲突:";
            // 
            // lblDALPostfix
            // 
            this.lblDALPostfix.AutoSize = true;
            this.lblDALPostfix.Location = new System.Drawing.Point(184, 49);
            this.lblDALPostfix.Name = "lblDALPostfix";
            this.lblDALPostfix.Size = new System.Drawing.Size(35, 12);
            this.lblDALPostfix.TabIndex = 17;
            this.lblDALPostfix.Text = "后缀:";
            // 
            // tbxDALPostfix
            // 
            this.tbxDALPostfix.Location = new System.Drawing.Point(226, 46);
            this.tbxDALPostfix.Name = "tbxDALPostfix";
            this.tbxDALPostfix.Size = new System.Drawing.Size(74, 21);
            this.tbxDALPostfix.TabIndex = 18;
            this.tbxDALPostfix.Text = "DataAccess";
            // 
            // lblDALPrefix
            // 
            this.lblDALPrefix.AutoSize = true;
            this.lblDALPrefix.Location = new System.Drawing.Point(63, 49);
            this.lblDALPrefix.Name = "lblDALPrefix";
            this.lblDALPrefix.Size = new System.Drawing.Size(35, 12);
            this.lblDALPrefix.TabIndex = 15;
            this.lblDALPrefix.Text = "前缀:";
            // 
            // tbxDALPrefix
            // 
            this.tbxDALPrefix.Location = new System.Drawing.Point(104, 46);
            this.tbxDALPrefix.Name = "tbxDALPrefix";
            this.tbxDALPrefix.Size = new System.Drawing.Size(74, 21);
            this.tbxDALPrefix.TabIndex = 16;
            // 
            // tbxDALNameSpace
            // 
            this.tbxDALNameSpace.Location = new System.Drawing.Point(104, 20);
            this.tbxDALNameSpace.Name = "tbxDALNameSpace";
            this.tbxDALNameSpace.Size = new System.Drawing.Size(343, 21);
            this.tbxDALNameSpace.TabIndex = 5;
            // 
            // lblDALNameSpace
            // 
            this.lblDALNameSpace.AutoSize = true;
            this.lblDALNameSpace.Location = new System.Drawing.Point(39, 23);
            this.lblDALNameSpace.Name = "lblDALNameSpace";
            this.lblDALNameSpace.Size = new System.Drawing.Size(59, 12);
            this.lblDALNameSpace.TabIndex = 4;
            this.lblDALNameSpace.Text = "命名空间:";
            // 
            // gbxModelSetting
            // 
            this.gbxModelSetting.Controls.Add(this.lblProperty);
            this.gbxModelSetting.Controls.Add(this.lblModel);
            this.gbxModelSetting.Controls.Add(this.cbxPropertyCollision);
            this.gbxModelSetting.Controls.Add(this.lblPropertyCollision);
            this.gbxModelSetting.Controls.Add(this.lblPropertyPostfix);
            this.gbxModelSetting.Controls.Add(this.tbxPropertyPostfix);
            this.gbxModelSetting.Controls.Add(this.lblPropertyPrefix);
            this.gbxModelSetting.Controls.Add(this.tbxPropertyPrefix);
            this.gbxModelSetting.Controls.Add(this.cbxModelCollision);
            this.gbxModelSetting.Controls.Add(this.lblModelCollision);
            this.gbxModelSetting.Controls.Add(this.lblModelPostfix);
            this.gbxModelSetting.Controls.Add(this.tbxModelPostfix);
            this.gbxModelSetting.Controls.Add(this.tbxModelNameSpace);
            this.gbxModelSetting.Controls.Add(this.lblModelNameSpace);
            this.gbxModelSetting.Controls.Add(this.lblModelPrefix);
            this.gbxModelSetting.Controls.Add(this.tbxModelPrefix);
            this.gbxModelSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxModelSetting.Location = new System.Drawing.Point(3, 108);
            this.gbxModelSetting.Name = "gbxModelSetting";
            this.gbxModelSetting.Size = new System.Drawing.Size(457, 105);
            this.gbxModelSetting.TabIndex = 12;
            this.gbxModelSetting.TabStop = false;
            this.gbxModelSetting.Text = "实体层设置";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(6, 78);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(53, 12);
            this.lblProperty.TabIndex = 22;
            this.lblProperty.Text = "属性名称";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(6, 51);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(53, 12);
            this.lblModel.TabIndex = 21;
            this.lblModel.Text = "实体名称";
            // 
            // cbxPropertyCollision
            // 
            this.cbxPropertyCollision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPropertyCollision.FormattingEnabled = true;
            this.cbxPropertyCollision.Items.AddRange(new object[] {
            "首字母大写",
            "添加\"_\"前缀"});
            this.cbxPropertyCollision.Location = new System.Drawing.Point(347, 75);
            this.cbxPropertyCollision.Name = "cbxPropertyCollision";
            this.cbxPropertyCollision.Size = new System.Drawing.Size(100, 20);
            this.cbxPropertyCollision.TabIndex = 20;
            // 
            // lblPropertyCollision
            // 
            this.lblPropertyCollision.AutoSize = true;
            this.lblPropertyCollision.Location = new System.Drawing.Point(306, 78);
            this.lblPropertyCollision.Name = "lblPropertyCollision";
            this.lblPropertyCollision.Size = new System.Drawing.Size(35, 12);
            this.lblPropertyCollision.TabIndex = 19;
            this.lblPropertyCollision.Text = "冲突:";
            // 
            // lblPropertyPostfix
            // 
            this.lblPropertyPostfix.AutoSize = true;
            this.lblPropertyPostfix.Location = new System.Drawing.Point(185, 78);
            this.lblPropertyPostfix.Name = "lblPropertyPostfix";
            this.lblPropertyPostfix.Size = new System.Drawing.Size(35, 12);
            this.lblPropertyPostfix.TabIndex = 17;
            this.lblPropertyPostfix.Text = "后缀:";
            // 
            // tbxPropertyPostfix
            // 
            this.tbxPropertyPostfix.Location = new System.Drawing.Point(226, 74);
            this.tbxPropertyPostfix.Name = "tbxPropertyPostfix";
            this.tbxPropertyPostfix.Size = new System.Drawing.Size(74, 21);
            this.tbxPropertyPostfix.TabIndex = 18;
            // 
            // lblPropertyPrefix
            // 
            this.lblPropertyPrefix.AutoSize = true;
            this.lblPropertyPrefix.Location = new System.Drawing.Point(63, 78);
            this.lblPropertyPrefix.Name = "lblPropertyPrefix";
            this.lblPropertyPrefix.Size = new System.Drawing.Size(35, 12);
            this.lblPropertyPrefix.TabIndex = 15;
            this.lblPropertyPrefix.Text = "前缀:";
            // 
            // tbxPropertyPrefix
            // 
            this.tbxPropertyPrefix.Location = new System.Drawing.Point(104, 74);
            this.tbxPropertyPrefix.Name = "tbxPropertyPrefix";
            this.tbxPropertyPrefix.Size = new System.Drawing.Size(74, 21);
            this.tbxPropertyPrefix.TabIndex = 16;
            // 
            // cbxModelCollision
            // 
            this.cbxModelCollision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModelCollision.FormattingEnabled = true;
            this.cbxModelCollision.Items.AddRange(new object[] {
            "首字母大写",
            "添加\"_\"前缀"});
            this.cbxModelCollision.Location = new System.Drawing.Point(347, 48);
            this.cbxModelCollision.Name = "cbxModelCollision";
            this.cbxModelCollision.Size = new System.Drawing.Size(100, 20);
            this.cbxModelCollision.TabIndex = 14;
            // 
            // lblModelCollision
            // 
            this.lblModelCollision.AutoSize = true;
            this.lblModelCollision.Location = new System.Drawing.Point(306, 51);
            this.lblModelCollision.Name = "lblModelCollision";
            this.lblModelCollision.Size = new System.Drawing.Size(35, 12);
            this.lblModelCollision.TabIndex = 13;
            this.lblModelCollision.Text = "冲突:";
            // 
            // lblModelPostfix
            // 
            this.lblModelPostfix.AutoSize = true;
            this.lblModelPostfix.Location = new System.Drawing.Point(185, 51);
            this.lblModelPostfix.Name = "lblModelPostfix";
            this.lblModelPostfix.Size = new System.Drawing.Size(35, 12);
            this.lblModelPostfix.TabIndex = 11;
            this.lblModelPostfix.Text = "后缀:";
            // 
            // tbxModelPostfix
            // 
            this.tbxModelPostfix.Location = new System.Drawing.Point(226, 47);
            this.tbxModelPostfix.Name = "tbxModelPostfix";
            this.tbxModelPostfix.Size = new System.Drawing.Size(74, 21);
            this.tbxModelPostfix.TabIndex = 12;
            // 
            // tbxModelNameSpace
            // 
            this.tbxModelNameSpace.Location = new System.Drawing.Point(104, 20);
            this.tbxModelNameSpace.Name = "tbxModelNameSpace";
            this.tbxModelNameSpace.Size = new System.Drawing.Size(343, 21);
            this.tbxModelNameSpace.TabIndex = 3;
            // 
            // lblModelNameSpace
            // 
            this.lblModelNameSpace.AutoSize = true;
            this.lblModelNameSpace.Location = new System.Drawing.Point(39, 23);
            this.lblModelNameSpace.Name = "lblModelNameSpace";
            this.lblModelNameSpace.Size = new System.Drawing.Size(59, 12);
            this.lblModelNameSpace.TabIndex = 2;
            this.lblModelNameSpace.Text = "命名空间:";
            // 
            // lblModelPrefix
            // 
            this.lblModelPrefix.AutoSize = true;
            this.lblModelPrefix.Location = new System.Drawing.Point(63, 51);
            this.lblModelPrefix.Name = "lblModelPrefix";
            this.lblModelPrefix.Size = new System.Drawing.Size(35, 12);
            this.lblModelPrefix.TabIndex = 5;
            this.lblModelPrefix.Text = "前缀:";
            // 
            // tbxModelPrefix
            // 
            this.tbxModelPrefix.Location = new System.Drawing.Point(104, 47);
            this.tbxModelPrefix.Name = "tbxModelPrefix";
            this.tbxModelPrefix.Size = new System.Drawing.Size(74, 21);
            this.tbxModelPrefix.TabIndex = 6;
            // 
            // gbxPathSetting
            // 
            this.gbxPathSetting.Controls.Add(this.tbxSlnPath);
            this.gbxPathSetting.Controls.Add(this.btnDALBrower);
            this.gbxPathSetting.Controls.Add(this.lblSlnPath);
            this.gbxPathSetting.Controls.Add(this.tbxDALPath);
            this.gbxPathSetting.Controls.Add(this.btnSlnBrower);
            this.gbxPathSetting.Controls.Add(this.lblDALPath);
            this.gbxPathSetting.Controls.Add(this.lblModelPath);
            this.gbxPathSetting.Controls.Add(this.btnModelBrower);
            this.gbxPathSetting.Controls.Add(this.tbxModelPath);
            this.gbxPathSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxPathSetting.Location = new System.Drawing.Point(3, 3);
            this.gbxPathSetting.Name = "gbxPathSetting";
            this.gbxPathSetting.Size = new System.Drawing.Size(457, 105);
            this.gbxPathSetting.TabIndex = 11;
            this.gbxPathSetting.TabStop = false;
            this.gbxPathSetting.Text = "路径设置";
            // 
            // tbxSlnPath
            // 
            this.tbxSlnPath.Location = new System.Drawing.Point(104, 20);
            this.tbxSlnPath.Name = "tbxSlnPath";
            this.tbxSlnPath.ReadOnly = true;
            this.tbxSlnPath.Size = new System.Drawing.Size(312, 21);
            this.tbxSlnPath.TabIndex = 3;
            // 
            // btnDALBrower
            // 
            this.btnDALBrower.Location = new System.Drawing.Point(415, 72);
            this.btnDALBrower.Name = "btnDALBrower";
            this.btnDALBrower.Size = new System.Drawing.Size(32, 23);
            this.btnDALBrower.TabIndex = 10;
            this.btnDALBrower.Text = "...";
            this.btnDALBrower.UseVisualStyleBackColor = true;
            this.btnDALBrower.Click += new System.EventHandler(this.btnDALBrower_Click);
            // 
            // lblSlnPath
            // 
            this.lblSlnPath.AutoSize = true;
            this.lblSlnPath.Location = new System.Drawing.Point(15, 23);
            this.lblSlnPath.Name = "lblSlnPath";
            this.lblSlnPath.Size = new System.Drawing.Size(83, 12);
            this.lblSlnPath.TabIndex = 2;
            this.lblSlnPath.Text = "解决方案路径:";
            // 
            // tbxDALPath
            // 
            this.tbxDALPath.Location = new System.Drawing.Point(104, 74);
            this.tbxDALPath.Name = "tbxDALPath";
            this.tbxDALPath.ReadOnly = true;
            this.tbxDALPath.Size = new System.Drawing.Size(312, 21);
            this.tbxDALPath.TabIndex = 9;
            // 
            // btnSlnBrower
            // 
            this.btnSlnBrower.Location = new System.Drawing.Point(415, 18);
            this.btnSlnBrower.Name = "btnSlnBrower";
            this.btnSlnBrower.Size = new System.Drawing.Size(32, 23);
            this.btnSlnBrower.TabIndex = 4;
            this.btnSlnBrower.Text = "...";
            this.btnSlnBrower.UseVisualStyleBackColor = true;
            this.btnSlnBrower.Click += new System.EventHandler(this.btnSlnBrower_Click);
            // 
            // lblDALPath
            // 
            this.lblDALPath.AutoSize = true;
            this.lblDALPath.Location = new System.Drawing.Point(3, 77);
            this.lblDALPath.Name = "lblDALPath";
            this.lblDALPath.Size = new System.Drawing.Size(95, 12);
            this.lblDALPath.TabIndex = 8;
            this.lblDALPath.Text = "数据访问层路径:";
            // 
            // lblModelPath
            // 
            this.lblModelPath.AutoSize = true;
            this.lblModelPath.Location = new System.Drawing.Point(27, 50);
            this.lblModelPath.Name = "lblModelPath";
            this.lblModelPath.Size = new System.Drawing.Size(71, 12);
            this.lblModelPath.TabIndex = 5;
            this.lblModelPath.Text = "实体层路径:";
            // 
            // btnModelBrower
            // 
            this.btnModelBrower.Location = new System.Drawing.Point(415, 45);
            this.btnModelBrower.Name = "btnModelBrower";
            this.btnModelBrower.Size = new System.Drawing.Size(32, 23);
            this.btnModelBrower.TabIndex = 7;
            this.btnModelBrower.Text = "...";
            this.btnModelBrower.UseVisualStyleBackColor = true;
            this.btnModelBrower.Click += new System.EventHandler(this.btnModelBrower_Click);
            // 
            // tbxModelPath
            // 
            this.tbxModelPath.Location = new System.Drawing.Point(104, 47);
            this.tbxModelPath.Name = "tbxModelPath";
            this.tbxModelPath.ReadOnly = true;
            this.tbxModelPath.Size = new System.Drawing.Size(312, 21);
            this.tbxModelPath.TabIndex = 6;
            // 
            // tpgDBSetting
            // 
            this.tpgDBSetting.Controls.Add(this.gbxDBConnection);
            this.tpgDBSetting.Location = new System.Drawing.Point(4, 22);
            this.tpgDBSetting.Name = "tpgDBSetting";
            this.tpgDBSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpgDBSetting.Size = new System.Drawing.Size(463, 298);
            this.tpgDBSetting.TabIndex = 0;
            this.tpgDBSetting.Text = "数据库设置";
            this.tpgDBSetting.UseVisualStyleBackColor = true;
            // 
            // gbxDBConnection
            // 
            this.gbxDBConnection.Controls.Add(this.pnlDb);
            this.gbxDBConnection.Controls.Add(this.cbxProvider);
            this.gbxDBConnection.Controls.Add(this.label1);
            this.gbxDBConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDBConnection.Location = new System.Drawing.Point(3, 3);
            this.gbxDBConnection.Name = "gbxDBConnection";
            this.gbxDBConnection.Size = new System.Drawing.Size(457, 132);
            this.gbxDBConnection.TabIndex = 0;
            this.gbxDBConnection.TabStop = false;
            this.gbxDBConnection.Text = "数据库连接";
            // 
            // cbxProvider
            // 
            this.cbxProvider.FormattingEnabled = true;
            this.cbxProvider.Location = new System.Drawing.Point(73, 19);
            this.cbxProvider.Name = "cbxProvider";
            this.cbxProvider.Size = new System.Drawing.Size(297, 20);
            this.cbxProvider.TabIndex = 11;
            this.cbxProvider.SelectedIndexChanged += new System.EventHandler(this.cbxProvider_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Provider:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(389, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlDb
            // 
            this.pnlDb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDb.Location = new System.Drawing.Point(3, 43);
            this.pnlDb.Name = "pnlDb";
            this.pnlDb.Size = new System.Drawing.Size(451, 86);
            this.pnlDb.TabIndex = 12;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 357);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tclSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.Text = "代码生成参数配置";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.tclSetting.ResumeLayout(false);
            this.tpgProjectSetting.ResumeLayout(false);
            this.gbxDALSetting.ResumeLayout(false);
            this.gbxDALSetting.PerformLayout();
            this.gbxModelSetting.ResumeLayout(false);
            this.gbxModelSetting.PerformLayout();
            this.gbxPathSetting.ResumeLayout(false);
            this.gbxPathSetting.PerformLayout();
            this.tpgDBSetting.ResumeLayout(false);
            this.gbxDBConnection.ResumeLayout(false);
            this.gbxDBConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tclSetting;
        private System.Windows.Forms.TabPage tpgDBSetting;
        private System.Windows.Forms.TabPage tpgProjectSetting;
        private System.Windows.Forms.GroupBox gbxDBConnection;
        private System.Windows.Forms.GroupBox gbxPathSetting;
        private System.Windows.Forms.TextBox tbxSlnPath;
        private System.Windows.Forms.Button btnDALBrower;
        private System.Windows.Forms.Label lblSlnPath;
        private System.Windows.Forms.TextBox tbxDALPath;
        private System.Windows.Forms.Button btnSlnBrower;
        private System.Windows.Forms.Label lblDALPath;
        private System.Windows.Forms.Label lblModelPath;
        private System.Windows.Forms.Button btnModelBrower;
        private System.Windows.Forms.TextBox tbxModelPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxModelSetting;
        private System.Windows.Forms.TextBox tbxModelNameSpace;
        private System.Windows.Forms.Label lblModelNameSpace;
        private System.Windows.Forms.Label lblModelPrefix;
        private System.Windows.Forms.TextBox tbxModelPrefix;
        private System.Windows.Forms.GroupBox gbxDALSetting;
        private System.Windows.Forms.Label lblModelPostfix;
        private System.Windows.Forms.TextBox tbxModelPostfix;
        private System.Windows.Forms.ComboBox cbxPropertyCollision;
        private System.Windows.Forms.Label lblPropertyCollision;
        private System.Windows.Forms.Label lblPropertyPostfix;
        private System.Windows.Forms.TextBox tbxPropertyPostfix;
        private System.Windows.Forms.Label lblPropertyPrefix;
        private System.Windows.Forms.TextBox tbxPropertyPrefix;
        private System.Windows.Forms.ComboBox cbxModelCollision;
        private System.Windows.Forms.Label lblModelCollision;
        private System.Windows.Forms.TextBox tbxDALNameSpace;
        private System.Windows.Forms.Label lblDALNameSpace;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxDALCollision;
        private System.Windows.Forms.Label lblDALCollision;
        private System.Windows.Forms.Label lblDALPostfix;
        private System.Windows.Forms.TextBox tbxDALPostfix;
        private System.Windows.Forms.Label lblDALPrefix;
        private System.Windows.Forms.TextBox tbxDALPrefix;
        private System.Windows.Forms.Label lblDAL;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxProvider;
        private System.Windows.Forms.Panel pnlDb;
    }
}