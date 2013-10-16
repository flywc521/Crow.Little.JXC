using Crow.Little.CodeGenerator.dbConfig;
using Crow.Little.CodeGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Crow.Little.CodeGenerator
{
    public partial class FormConfig : Form
    {
        #region Field
        private CodeGenerateSetting setting = null;
        #endregion
        #region Property
        public CodeGenerateSetting Setting
        {
            get { return setting; }
            set { setting = value; }
        }
        public Func<string, bool> ValidateNameFunc
        {
            get;
            set;
        }
        #endregion
        #region Constructor
        public FormConfig()
        {
            InitializeComponent();
        }
        #endregion
        #region Event
        #endregion
        #region Method
        #region Control Event Handler
        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.InitCollisionComboBoxes();
            this.InitControlsForSetting();
        }
        private void btnSlnBrower_Click(object sender, EventArgs e)
        {
            this.BrowsePath(this.tbxSlnPath, "sln");
        }
        private void btnModelBrower_Click(object sender, EventArgs e)
        {
            this.BrowsePath(this.tbxModelPath, "csproj", this.tbxSlnPath.Text);
            string defaultNameSpace = TryToGetDefaultNameSpaceForProject(this.tbxModelPath.Text);
            if (!String.IsNullOrEmpty(defaultNameSpace))
                this.tbxModelNameSpace.Text = defaultNameSpace;
        }
        private void btnDALBrower_Click(object sender, EventArgs e)
        {
            this.BrowsePath(this.tbxDALPath, "csproj", this.tbxSlnPath.Text);
            string defaultNameSpace = TryToGetDefaultNameSpaceForProject(this.tbxDALPath.Text);
            if (!String.IsNullOrEmpty(defaultNameSpace))
                this.tbxDALNameSpace.Text = defaultNameSpace;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool successed = true;
            try
            {
                setting = BuildSetting();
                if (String.IsNullOrEmpty(setting.Name))
                {
                    FormSettingName frmName = new FormSettingName() { ValidateNameFunc = this.ValidateNameFunc };
                    int x = this.Location.X + (this.Width - frmName.Width) / 2;
                    int y = this.Location.Y + (this.Height - frmName.Height) / 2;
                    frmName.Location = new Point(x, y);
                    frmName.StartPosition = FormStartPosition.Manual;

                    string slnName = setting.Solution.SlnPath.Split('\\').LastOrDefault();
                    if (!String.IsNullOrEmpty(slnName))
                    {
                        frmName.SettingName = slnName.Split('.').FirstOrDefault();
                    }
                    if (frmName.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        setting.Name = frmName.SettingName;
                    }
                    else
                    {
                        successed = false;
                    }
                }
            }
            catch (Exception ex)
            {
                successed = false;
                MessageBox.Show(String.Format("配置保存失败:{0}", ex.Message), "消息提示", MessageBoxButtons.OK);
            }

            if (successed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbxProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnlDb.Controls.Clear();
            if (this.cbxProvider.Text == "sqlite")
            {
                this.pnlDb.Controls.Add(new CtrlSqliteConfig(2));
            }
            else if (this.cbxProvider.Text == "accdb")
            {
                this.pnlDb.Controls.Add(new CtrlAccessConfig(1));
            }
            else if (this.cbxProvider.Text == "mssql")
            {
                this.pnlDb.Controls.Add(new CtrlSqlServerConfig(3));
            }
        }
        #endregion
        #region Custom Method
        private void InitControlsForSetting()
        {
            this.cbxProvider.Items.Clear();
            this.cbxProvider.ValueMember = "Item1";
            this.cbxProvider.DisplayMember = "Item2";
            this.cbxProvider.DataSource = CodeBuilder.GetProviders();

            if (this.Setting != null)
            {
                if (this.Setting.Solution != null)
                {
                    this.tbxSlnPath.Text = this.setting.Solution.SlnPath;
                    if (this.Setting.Solution.Model != null)
                    {
                        this.tbxModelPath.Text = this.Setting.Solution.Model.Path;
                        this.tbxModelNameSpace.Text = this.Setting.Solution.Model.NameSpace;
                        this.tbxModelPrefix.Text = this.Setting.Solution.Model.ModelPrefix;
                        this.tbxModelPostfix.Text = this.Setting.Solution.Model.ModelPostfix;
                        this.cbxModelCollision.SelectedIndex = (int)this.Setting.Solution.Model.ModelCollision;
                        this.tbxPropertyPrefix.Text = this.Setting.Solution.Model.PropertyPrefix;
                        this.tbxPropertyPostfix.Text = this.Setting.Solution.Model.PropertyPostfix;
                        this.cbxPropertyCollision.SelectedIndex = (int)this.Setting.Solution.Model.PropertyCollision;
                    }
                    if (this.Setting.Solution.DAL != null)
                    {
                        this.tbxDALPath.Text = this.Setting.Solution.DAL.Path;
                        this.tbxDALNameSpace.Text = this.Setting.Solution.DAL.NameSpace;
                        this.tbxDALPrefix.Text = this.Setting.Solution.DAL.DALPrefix;
                        this.tbxDALPostfix.Text = this.Setting.Solution.DAL.DALPostfix;
                        this.cbxDALCollision.SelectedIndex = (int)this.Setting.Solution.DAL.DALCollision;
                    }
                }
                if (this.Setting.DB != null)
                {
                    DbSettingItem dbSetting = new DbSettingItem()
                    {
                        Provider = this.Setting.DB.Provider,
                        Server = this.Setting.DB.Server,
                        Database = this.Setting.DB.DB,
                        UID = this.Setting.DB.User,
                        PWD = this.Setting.DB.Password,
                    };

                    foreach (Control ctrl in this.pnlDb.Controls)
                    {
                        if (ctrl is CtrlDbConfig)
                        {
                            CtrlDbConfig dbConfig = (CtrlDbConfig)ctrl;
                            dbConfig.InitDbSetting(dbSetting);
                            break;
                        }
                    }
                }
            }
        }
        private void InitCollisionComboBoxes()
        {
            this.cbxModelCollision.SelectedIndex = 0;
            this.cbxPropertyCollision.SelectedIndex = 0;
            this.cbxDALCollision.SelectedIndex = 0;
        }
        private void BrowsePath(TextBox tbxPath, string extension, string initDirectoryPath = "")
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = String.Format("(*.{0})|*.{0}", extension);
            if (!String.IsNullOrEmpty(initDirectoryPath))
                ofd.InitialDirectory = initDirectoryPath;
            else
            {
                if (!String.IsNullOrEmpty(tbxPath.Text) && Directory.Exists(tbxPath.Text))
                    ofd.InitialDirectory = tbxPath.Text;
                else
                    ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxPath.Text = ofd.FileName;
            }
        }
        private string TryToGetDefaultNameSpaceForProject(string csprojPath)
        {
            string nameSpace = String.Empty;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(csprojPath);
                XmlNamespaceManager xmlNS = new XmlNamespaceManager(doc.NameTable);
                xmlNS.AddNamespace("ns1", "http://schemas.microsoft.com/developer/msbuild/2003");
                XmlNode node = doc.SelectSingleNode("/ns1:Project/ns1:PropertyGroup/ns1:RootNamespace", xmlNS);
                nameSpace = node != null ? node.InnerText : String.Empty;
            }
            finally
            {
                doc = null;
            }
            return nameSpace;
        }
        private CodeGenerateSetting BuildSetting()
        {
            CodeGenerateSetting setting = new CodeGenerateSetting();
            setting.DB = BuildDBSetting();
            setting.Solution = BuildSolutionSetting();
            return setting;
        }
        private DBSetting BuildDBSetting()
        {
            DBSetting setting = new DBSetting();
            foreach (Control ctrl in this.pnlDb.Controls)
            {
                if (ctrl is CtrlDbConfig)
                {
                    CtrlDbConfig dbConfig = (CtrlDbConfig)ctrl;
                    setting = new DBSetting()
                    {
                        Provider = dbConfig.DBSetting.Provider,
                        Server = dbConfig.DBSetting.Server,
                        DB = dbConfig.DBSetting.Database,
                        User = dbConfig.DBSetting.UID,
                        Password = dbConfig.DBSetting.PWD,
                    };
                    break;
                }
            }
            return setting;
        }
        private SolutionSetting BuildSolutionSetting()
        {
            SolutionSetting setting = new SolutionSetting();
            setting.SlnPath = this.tbxSlnPath.Text.Trim();
            setting.Model = BuildModelSetting();
            setting.DAL = BuildDALSetting();
            return setting;
        }
        private ModelSetting BuildModelSetting()
        {
            ModelSetting setting = new ModelSetting();
            setting.Path = this.tbxModelPath.Text.Trim();
            setting.NameSpace = this.tbxModelNameSpace.Text.Trim();
            setting.ModelPrefix = this.tbxModelPrefix.Text.Trim();
            setting.ModelPostfix = this.tbxModelPostfix.Text.Trim();
            setting.ModelCollision = (MemberNameCollisionSolution)((int)this.cbxModelCollision.SelectedIndex);
            setting.PropertyPrefix = this.tbxPropertyPrefix.Text.Trim();
            setting.PropertyPostfix = this.tbxPropertyPostfix.Text.Trim();
            setting.PropertyCollision = (MemberNameCollisionSolution)((int)this.cbxPropertyCollision.SelectedIndex);

            return setting;
        }
        private DALSetting BuildDALSetting()
        {
            DALSetting setting = new DALSetting();
            setting.Path = this.tbxDALPath.Text.Trim();
            setting.NameSpace = this.tbxDALNameSpace.Text.Trim();
            setting.DALPrefix = this.tbxDALPrefix.Text.Trim();
            setting.DALPostfix = this.tbxDALPostfix.Text.Trim();
            setting.DALCollision = (MemberNameCollisionSolution)((int)this.cbxDALCollision.SelectedIndex);

            return setting;
        }
        #endregion
        #endregion
    }
}
