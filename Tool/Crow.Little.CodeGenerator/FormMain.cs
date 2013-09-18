namespace Crow.Little.CodeGenerator
{
    using Crow.Little.CodeGeneratorLibrary;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using System.Linq;
    using System.ComponentModel;
    using System.Drawing;
    using System.Diagnostics;
    using Crow.Little.Common;

    public partial class FormMain : Form
    {
        #region Field
        private const string settingFile = @"setting.xml";
        private string settingPath = String.Empty;
        private List<CodeGenerateSetting> settingList = new List<CodeGenerateSetting>();
        #endregion
        #region Property
        #endregion
        #region Constructor
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion
        #region Event
        #endregion
        #region Method
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.dgvProject.AutoGenerateColumns = false;
            this.colProjectName.DataPropertyName = "Name";
            this.colProjectPath.DataPropertyName = "Path";

            this.LoadCodeGenerateSetting();
            this.dgvProject.DataSource = new BindingList<CodeGenerateSetting>(this.settingList);
            this.dgvProject.Refresh();
        }
        private void dgvProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (String.Compare(this.dgvProject.Columns[e.ColumnIndex].Name, "colGenerate", true) == 0 && e.RowIndex >= 0)
            {
                string name = this.dgvProject.Rows[e.RowIndex].Cells["colProjectName"].Value.ToString();
                CodeGenerateSetting setting = this.settingList.Where(s => String.Compare(s.Name, name, true) == 0).FirstOrDefault();
                if (setting != null)
                {
                    //初始化数据库连接，并获取库中的所有表
                    //DBOperator.InitConnection(BuildConnectionString(setting.DB.Server, setting.DB.DB, setting.DB.User, setting.DB.Password));
                    DBOperator.InitConnection(Convert.ToInt32(setting.DB.Provider), setting.DB.Server, setting.DB.DB, setting.DB.User, setting.DB.Password);
                    List<string> tableNameList = DBOperator.LoadTableNames();
                    //初始化代码生成配置信息
                    CodeBuilder.InitSetting(setting);
                    //选择数据库中的哪些表参与到代码生成当中
                    FormTableFilter filter = new FormTableFilter() { AllTables = tableNameList };
                    if (filter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        List<string> selectedTableList = filter.SelectedTables;
                        List<Tuple<string, string, string>> existedTableList = CodeBuilder.GetExistedCodeFileList(selectedTableList, setting);
                        //对已存在的文件做出是否覆盖的处理
                        if (existedTableList.Count > 0)
                        {
                            FormExistFilesFilter existedFilter = new FormExistFilesFilter() { ConveredTableNameList = existedTableList.ToList() };
                            if (existedFilter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                //用户人为干预后，ConveredTableNameList内容可能会发生变更
                                List<string> unConveredTableNameList = existedTableList.Where(t => !existedFilter.ConveredTableNameList.Contains(t)).Select(t => t.Item1).ToList();
                                selectedTableList = selectedTableList.Where(t => !unConveredTableNameList.Contains(t)).ToList();
                            }
                        }
                        //处理过是否覆盖的判定后，对仍需要生成代码的数据表实现代码生成
                        if (selectedTableList.Count > 0)
                        {
                            DBDescription dbDescriptions = DBOperator.LoadDBDescription();
                            CodeBuilder.GenerateCodeFiles(selectedTableList, dbDescriptions, setting);
                            ShowGenerateMessage(setting);
                        }
                    }
                }
            }
        }
        private void dgvProject_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (String.Compare(this.dgvProject.Columns[e.ColumnIndex].Name, "colProjectName", true) == 0 && e.RowIndex >= 0)
            {
                string name = this.dgvProject.Rows[e.RowIndex].Cells["colProjectName"].Value.ToString();
                CodeGenerateSetting setting = this.settingList.Where(s => String.Compare(s.Name, name, true) == 0).FirstOrDefault();
                if (setting != null)
                {
                    FormConfig frmConfig = new FormConfig() { Setting = setting, ValidateNameFunc = CheckSettingName };
                    if (frmConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CodeGenerateSetting currentSetting = this.settingList.Where(s => String.Compare(s.Name, frmConfig.Setting.Name, true) == 0).FirstOrDefault();
                        if (currentSetting != null)
                        {
                            this.settingList.Remove(currentSetting);
                        }

                        this.settingList.Insert(0, frmConfig.Setting);
                        this.SaveCodeGenerateSetting();
                        this.dgvProject.DataSource = new BindingList<CodeGenerateSetting>(this.settingList);
                        this.dgvProject.Refresh();
                    }
                }
            }
        }
        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //CodeGenerateSetting setting = CodeGenerateSetting.FromXml(ofd.FileName);
            }
        }
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            FormConfig frmConfig = new FormConfig() { ValidateNameFunc = CheckSettingName };
            int x = this.Location.X + (this.Width - frmConfig.Width) / 2;
            int y = this.Location.Y + (this.Height - frmConfig.Height) / 2;
            frmConfig.Location = new Point(x, y);
            frmConfig.StartPosition = FormStartPosition.Manual;
            if (frmConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.settingList.Insert(0, frmConfig.Setting);
                this.SaveCodeGenerateSetting();
                this.dgvProject.DataSource = new BindingList<CodeGenerateSetting>(this.settingList);
                this.dgvProject.Refresh();
            }
        }
        private string BuildConnectionString(string server, string db, string uid, string pwd)
        {
            return String.Format("Data Source={0};initial catalog={1};user id={2};password={3};", server, db, uid, pwd);
        }
        private void LoadCodeGenerateSetting()
        {
            settingPath = Path.Combine(Application.StartupPath, settingFile);
            if (File.Exists(settingPath))
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(settingPath);
                    XmlNodeList settingNodes = doc.SelectNodes("/settingList/setting");
                    foreach (XmlNode settingNode in settingNodes)
                    {
                        CodeGenerateSetting setting = CodeGenerateSetting.FromXml(settingNode.OuterXml);
                        this.settingList.Add(setting);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("读取配置文件失败:{0}", ex.Message), "消息提示", MessageBoxButtons.OK);
                }
            }
        }
        private void SaveCodeGenerateSetting()
        {
            settingPath = Path.Combine(Application.StartupPath, settingFile);

            XmlDocument doc = new XmlDocument();
            try
            {
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(declaration);
                XmlNode rootNode = doc.CreateElement("settingList");
                doc.AppendChild(rootNode);

                foreach (CodeGenerateSetting setting in this.settingList)
                {
                    setting.ToXml(doc, rootNode);
                }

                doc.Save(settingPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("读取配置文件失败:{0}", ex.Message), "消息提示", MessageBoxButtons.OK);
            }
        }
        private bool CheckSettingName(string name)
        {
            return this.settingList.Where(s => String.Compare(s.Name, name, true) == 0).Count() == 0;
        }
        private void ShowGenerateMessage(CodeGenerateSetting setting)
        {
            if (MessageBox.Show("代码生成已完成,是否打开解决方案", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                Process.Start(setting.Solution.SlnPath);
            }
        }
        #endregion
    }
}
