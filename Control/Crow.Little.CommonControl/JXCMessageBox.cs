using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.CommonControl
{
    public static class JXCMessageBox
    {
        #region Field
        private static string title = "消息提示";
        #endregion

        #region Property
        #endregion

        #region Constructor
        #endregion

        #region Event
        #endregion

        #region Method
        public static void ShowMessageInformation(string content)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessageWarning(string content)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowMessageError(string content)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowMessageYesNo(string content)
        {
            return MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowMessageOKCancel(string content)
        {
            return MessageBox.Show(content, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowMessageAbortRetryIgnore(string content)
        {
            return MessageBox.Show(content, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
        }
        #endregion
    }
}
