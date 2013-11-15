using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Crow.Little.Common;

namespace Crow.Little.CommonControl
{
    internal class ContainerForm : Form
    {
        #region Field
        private ContainedControl ctrl;
        private bool isInnerControlCancelClosing = false;
        #endregion
        #region Property
        #endregion
        #region Constructor
        internal ContainerForm(ContainedControl _ctrl)
        {
            this.ctrl = _ctrl;
            this.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

            this.FormClosing += new FormClosingEventHandler(JXCContainerForm_FormClosing);

            ctrl.ControlClosing += new EventHandler<CancelEventArgs>(ctrl_ControlClosing);
            ctrl.ControlClosed += new EventHandler(ctrl_ControlClosed);
            ctrl.ControlTextChanged += new EventHandler<CommonEventArgs<string>>(ctrl_ControlTextChanged);
            ctrl.ControlClosedAsDialogBox += new EventHandler<CommonEventArgs<DialogResult>>(ctrl_ControlClosedAsDialogBox);
        }
        #endregion
        #region Event
        #endregion
        #region Method
        private void JXCContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isInnerControlCancelClosing;
            isInnerControlCancelClosing = false;
        }

        private void ctrl_ControlClosing(object sender, CancelEventArgs e)
        {
            isInnerControlCancelClosing = e.Cancel;
            this.Close();
        }

        private void ctrl_ControlClosed(object sender, EventArgs e)
        {
            isInnerControlCancelClosing = false;
            this.Close();
        }

        private void ctrl_ControlTextChanged(object sender, CommonEventArgs<string> e)
        {
            this.Text = e.Args;
        }

        private void ctrl_ControlClosedAsDialogBox(object sender, CommonEventArgs<DialogResult> e)
        {
            this.DialogResult = e.Args;
            this.Close();
        }
        #endregion
    }
}
