using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Crow.Little.Common;

namespace Crow.Little.CommonControl
{
    /// <summary>
    /// 本进销存系统中的被包含控件
    /// </summary>
    public class ContainedControl : UserControl
    {
        #region Field
        #endregion
        #region Property
        public Button AcceptButton
        {
            get;
            set;
        }

        public Button CancelButton
        {
            get;
            set;
        }
        #endregion
        #region Constructor
        #endregion
        #region Event
        /// <summary>
        /// 控件标签变更时触发
        /// </summary>
        public event EventHandler<CommonEventArgs<string>> ControlTextChanged;

        /// <summary>
        /// 控件正在执行退出动作时触发
        /// </summary>
        public event EventHandler<CancelEventArgs> ControlClosing;

        /// <summary>
        /// 控件完成退出动作时触发
        /// </summary>
        public event EventHandler ControlClosed;

        /// <summary>
        /// 控件返回对话框结果时触发
        /// </summary>
        public event EventHandler<CommonEventArgs<DialogResult>> ControlClosedAsDialogBox;
        #endregion
        #region Method
        /// <summary>
        /// 初始化自定义控件，基类中未实现任何操作
        /// </summary>
        public virtual void InitControl()
        {

        }

        public void ChangeControlText(string text)
        {
            if (ControlTextChanged != null)
            {
                CommonEventArgs<string> e = new CommonEventArgs<string>(text);
                ControlTextChanged(this, e);
            }
        }

        protected virtual void Closing(bool cancel)
        {
            if (ControlClosing != null)
            {
                ControlClosing(this, new CancelEventArgs(cancel));
            }
        }

        protected virtual void Close()
        {
            if (ControlClosed != null)
            {
                ControlClosed(this, EventArgs.Empty);
            }
        }

        protected virtual void CloseDialogBox(DialogResult result)
        {
            if (ControlClosedAsDialogBox != null)
            {
                CommonEventArgs<DialogResult> e = new CommonEventArgs<DialogResult>(result);
                ControlClosedAsDialogBox(this, e);
            }
        }
        #endregion
    }
}
