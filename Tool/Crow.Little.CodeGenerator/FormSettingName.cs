using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.CodeGenerator
{
    public partial class FormSettingName : Form
    {
        private string name = String.Empty;

        public string SettingName
        {
            get { return name; }
            set { name = value; }
        }

        public Func<string, bool> ValidateNameFunc
        {
            get;
            set;
        }

        public FormSettingName()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbxName.Text))
            {
                if (ValidateNameFunc != null)
                {
                    if (ValidateNameFunc(this.tbxName.Text))
                    {
                        name = this.tbxName.Text;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        DialogResult converRes = MessageBox.Show("配置名称已存在,是否覆盖原配置？", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (converRes == System.Windows.Forms.DialogResult.OK)
                        {
                            name = this.tbxName.Text;
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("程序出现故障,名称重复检查失败!", "消息提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("配置名称允许为空,请重新定义!", "消息提示", MessageBoxButtons.OK);
            }
        }

        private void FormSettingName_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(name))
                this.tbxName.Text = name;
        }
    }
}
