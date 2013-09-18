using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Crow.Little.CommonControl
{
    /// <summary>
    /// 本进销存系统中对控件的自定义动作(如TAB页显示,新窗体中显示,新对话框窗体中显示...)
    /// </summary>
    public static class JXCCustomeAction
    {
        #region Field
        private static readonly Size dftSize = new Size(640, 480);
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        #region As Child Control
        public static void ShowControlInParentControlAsDock(string title, JXCContainedControl ctrl, Control pCtrl)
        {
            pCtrl.Controls.Clear();
            pCtrl.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

            ctrl.InitControl();
        }
        #endregion  As TabPage
        #region As TabPage
        public static void ShowControlInTabControl(string title, JXCContainedControl ctrl, CloseableTabControl tCtrl, bool showCloseButton = true)
        {
            if (IsChildControlExistedInTabControl(title, tCtrl))
            {
                ActiveExistedTabPageInTabControl(title, tCtrl);
            }
            else
            {
                TabPage tpg = new CloseableTabPage() { Text = title, ShowCloseButton = showCloseButton };
                tpg.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Fill;

                tCtrl.TabPages.Add(tpg);
                tCtrl.SelectedTab = tpg;

                ctrl.InitControl();
            }
        }
        #endregion  As TabPage
        #region As New Form
        public static void ShowControlInNewForm(string title, JXCContainedControl ctrl)
        {
            Size size = new Size(ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right, ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom + 25);
            ShowControlInNewForm(title, ctrl, size);
        }

        public static void ShowControlInNewForm(string title, JXCContainedControl ctrl, Size size)
        {
            ShowControlInNewForm(title, ctrl, size, FormBorderStyle.Sizable, null);
        }

        public static void ShowControlInNewForm(string title, JXCContainedControl ctrl, FormBorderStyle style)
        {
            Size size = new Size(ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right, ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom + 25);
            ShowControlInNewForm(title, ctrl, size, FormBorderStyle.Sizable, null);
        }

        public static void ShowControlInNewForm(string title, JXCContainedControl ctrl, Size size, FormBorderStyle style, Icon ico)
        {
            Form frm = BuildFormForControl(title, ctrl, size, style, ico);
            frm.Show();
        }
        #endregion As New Form
        #region As New Singleton Form
        public static void ShowControlInNewSingletonForm(string unique, string title, JXCContainedControl ctrl)
        {
            Size size = new Size(ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right, ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom + 25);
            ShowControlInNewSingletonForm(unique, title, ctrl, size);
        }

        public static void ShowControlInNewSingletonForm(string unique, string title, JXCContainedControl ctrl, Size size)
        {
            ShowControlInNewSingletonForm(unique, title, ctrl, size, FormBorderStyle.Sizable, null);
        }

        public static void ShowControlInNewSingletonForm(string unique, string title, JXCContainedControl ctrl, FormBorderStyle style)
        {
            Size size = new Size(ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right, ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom + 25);
            ShowControlInNewSingletonForm(unique, title, ctrl, size, FormBorderStyle.Sizable, null);
        }

        public static void ShowControlInNewSingletonForm(string unique, string title, JXCContainedControl ctrl, Size size, FormBorderStyle style, Icon ico)
        {
            JXCContainerForm frm = FindExistedFormForControl(unique, title);
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frm = BuildFormForControl(unique, title, ctrl, size, style, ico);
                frm.Show();
            }
        }
        #endregion As New Singleton Form
        #region As New Dialog Form
        public static void ShowControlInNewDialogForm(string title, JXCContainedControl ctrl)
        {
            Size size = new Size(ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right, ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom + 25);
            ShowControlInNewDialogForm(title, ctrl, size);
        }

        public static void ShowControlInNewDialogForm(string title, JXCContainedControl ctrl, Size size)
        {
            ShowControlInNewDialogForm(title, ctrl, size, FormBorderStyle.FixedDialog, null);
        }

        public static void ShowControlInNewDialogForm(string title, JXCContainedControl ctrl, FormBorderStyle style)
        {
            Size size = new Size(ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right, ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom + 25);
            ShowControlInNewDialogForm(title, ctrl, size, style, null);
        }

        public static void ShowControlInNewDialogForm(string title, JXCContainedControl ctrl, Size size, FormBorderStyle style, Icon ico)
        {
            Form frm = BuildFormForControl(title, ctrl, size, style, ico);
            frm.ShowDialog();
        }
        #endregion As New Dialog Form
        #region Common Action
        /// <summary>
        /// 调用外部应用程序
        /// </summary>
        /// <param name="exeFilePath"></param>
        public static void CallExternalProcess(string exeFilePath)
        {
            CallExternalProcess(exeFilePath, String.Empty);
        }

        /// <summary>
        /// 调用外部应用程序(可带参数)
        /// </summary>
        /// <param name="exeFilePath"></param>
        public static void CallExternalProcess(string exeFilePath, string args)
        {
            ProcessStartInfo procInfo = String.IsNullOrEmpty(args) ? new ProcessStartInfo(exeFilePath) : new ProcessStartInfo(exeFilePath, args);
            Process.Start(procInfo);
        }

        /// <summary>
        /// 关闭整个系统
        /// </summary>
        public static void CloseApplication()
        {
            Application.Exit();
        }
        #endregion Common Action
        #region Private Method
        private static bool IsChildControlExistedInTabControl(string title, CloseableTabControl tCtrl)
        {
            foreach (TabPage tpg in tCtrl.TabPages)
            {
                if (String.Compare(tpg.Text, title, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static void ActiveExistedTabPageInTabControl(string title, CloseableTabControl tCtrl)
        {
            foreach (TabPage tpg in tCtrl.TabPages)
            {
                if (String.Compare(tpg.Text, title, true) == 0)
                {
                    tCtrl.SelectedTab = tpg;
                    break;
                }
            }
        }

        private static JXCContainerForm BuildFormForControl(string title, JXCContainedControl ctrl, Size size, FormBorderStyle style, Icon ico)
        {
            return BuildFormForControl(String.Empty, title, ctrl, size, style, ico);
        }

        private static JXCContainerForm BuildFormForControl(string unique, string title, JXCContainedControl ctrl, Size size, FormBorderStyle style, Icon ico)
        {
            JXCContainerForm frm = new JXCContainerForm(ctrl);
            frm.Text = title;
            frm.Size = size;
            frm.FormBorderStyle = style;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Icon = ico;
            frm.Tag = unique;

            if (ctrl.AcceptButton != null)
            {
                frm.AcceptButton = ctrl.AcceptButton;
            }

            if (ctrl.CancelButton != null)
            {
                frm.CancelButton = ctrl.CancelButton;
            }

            ctrl.InitControl();
            return frm;
        }

        private static JXCContainerForm FindExistedFormForControl(string unique, string title)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Tag != null && frm.Tag is string && String.Compare(frm.Tag.ToString(), unique, true) == 0 && frm is JXCContainerForm)
                {
                    return frm as JXCContainerForm;
                }
            }
            return null;
        }
        #endregion Private Method
        #endregion
    }
}
