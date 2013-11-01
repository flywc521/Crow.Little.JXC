using Crow.Little.CommonControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.JXC
{
    public partial class FormMain : Form
    {
        #region Field
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
            InitResources();
            BindControls();
        }

        private void InitResources()
        {
        }

        private void BindControls()
        {
        }        

        private TabPage CreateTabPage(string title, Control ctrl)
        {
            TabPage tPage = new TabPage(title);
            tPage.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

            return tPage;
        }
        #endregion
    }
}