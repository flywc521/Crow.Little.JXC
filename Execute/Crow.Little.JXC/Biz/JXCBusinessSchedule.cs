using Crow.Little.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.JXC
{
    public static class JXCBusinessSchedule
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
        public static void StartApplication()
        {
            MajorOperator.ApplicationInitStepChanged -= new EventHandler<CommonEventArgs<AppStep>>(MajorOperator_AppStepChanged);
            MajorOperator.ApplicationInitStepChanged += new EventHandler<CommonEventArgs<AppStep>>(MajorOperator_AppStepChanged);
        }

        private static void MajorOperator_AppStepChanged(object sender, CommonEventArgs<AppStep> e)
        {
            if (ApplicationInitStepChanged != null)
            {
                ApplicationInitStepChanged(null, new CommonEventArgs<AppStep>(e.Args));
            }
        }

        public static void TryToLogonForApplication()
        {
            MajorOperator.InitiateApplication();
        }

        public static void TryToCloseApplication()
        {
            MajorOperator.CloseApplication();
        }
        #endregion
    }
}
