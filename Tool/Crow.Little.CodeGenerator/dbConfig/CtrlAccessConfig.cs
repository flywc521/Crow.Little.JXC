using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crow.Little.CodeGeneratorLibrary;

namespace Crow.Little.CodeGenerator.dbConfig
{
    public partial class CtrlAccessConfig : CtrlDbConfig
    {
        public override DbSettingItem DBSetting
        {
            get
            {
                base.dbItem.Server = this.tbxServer.Text.Trim();
                base.dbItem.Database = String.Empty;
                base.dbItem.UID = this.tbxUser.Text.Trim();
                base.dbItem.PWD = this.tbxPassword.Text.Trim();

                return base.dbItem;
            }
        }

        public CtrlAccessConfig(int provider)
            : base(provider)
        {
            InitializeComponent();
        }

        public override void InitDbSetting(DbSettingItem dbSetting)
        {
            //base.InitDbSetting(dbSetting);
            this.tbxServer.Text = dbSetting.Server;
            this.tbxUser.Text = dbSetting.UID;
            this.tbxPassword.Text = dbSetting.PWD;
        }

        private void btnBrower_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Multiselect = false;
            ofDialog.Filter = "Access File (.mdb,.accdb)|*.mdb;*.accdb|All Files (*.*)|*.*";
            ofDialog.FilterIndex = 0;

            DialogResult result = ofDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tbxServer.Text = ofDialog.FileName;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string server = this.tbxServer.Text;
            string uid = this.tbxUser.Text;
            string pwd = this.tbxPassword.Text;

            if (!String.IsNullOrEmpty(server))
            {
                int provider = int.Parse(base.dbItem.Provider);
                DBOperator.InitConnection(provider, server, String.Empty, uid, pwd);
                try
                {
                    List<string> tableNameList = DBOperator.LoadTableNames();
                    MessageBox.Show("数据库连接成功!", "消息提示", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("数据库连接失败:{0}", ex.Message), "消息提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("请选择Sqlite数据库文件!", "消息提示", MessageBoxButtons.OK);
            }
        }
    }
}
