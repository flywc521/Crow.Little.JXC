using Crow.Little.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crow.Little.JXC
{
    /// <summary>
    /// 核心操作业务
    /// </summary>
    public static class MajorOperator
    {
        #region Field
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        public static event EventHandler<CommonEventArgs<AppStep>> ApplicationInitStepChanged;
        #endregion
        #region Method
        public static void InitiateApplication()
        {
            //通知初始化完成
            if (ApplicationInitStepChanged != null)
            {
                ApplicationInitStepChanged(null, new CommonEventArgs<AppStep>(new AppStep(100, 100, String.Empty)));
            }
        }

        public static void CloseApplication()
        {
            //清空各种资源的调用
        }
        #endregion
    }
}
