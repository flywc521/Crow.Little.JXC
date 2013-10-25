using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.JXC
{
    public partial class FormLogin : Form
    {
#region Field
        #endregion

        #region Property
        #endregion

        #region Constructor
        public FormLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        internal event EventHandler TryToLogon;
        #endregion

        #region Method
        private void FormLogon_Load(object sender, EventArgs e)
        {
            this.pbxLogon.Image = new Bitmap(@"pics\logon.png");
            
            //TODO:暂先忽略登录过程
            this.btnOK_Click(this.btnOK, EventArgs.Empty);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DisableControls();

            if (TryToLogon != null)
            {
                TryToLogon(this, EventArgs.Empty);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void CloseFormWhileInitCompleted()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DisableControls()
        {
            this.tbxUserName.Enabled = false;
            this.tbxPassword.Enabled = false;
            this.btnOK.Enabled = false;
            this.btnCancel.Enabled = true;
        }

        private void EnableControls()
        {
            this.tbxUserName.Enabled = true;
            this.tbxPassword.Enabled = true;
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;
        }
        #endregion
    }
}
