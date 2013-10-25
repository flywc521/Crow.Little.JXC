using Crow.Little.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.JXC
{
    public static class UIController
    {
        #region Field
        private static FormLogin frmLogon;
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        internal static bool ApplicationLogon()
        {
            JXCBusinessSchedule.StartApplication();

            JXCBusinessSchedule.ApplicationInitStepChanged -= new EventHandler<CommonEventArgs<AppStep>>(JXCBusinessSchedule_ApplicationInitStepChanged);
            JXCBusinessSchedule.ApplicationInitStepChanged += new EventHandler<CommonEventArgs<AppStep>>(JXCBusinessSchedule_ApplicationInitStepChanged);

            frmLogon = new FormLogin();
            frmLogon.TryToLogon += new EventHandler(FrmLogon_TryToLogon);

            DialogResult result = frmLogon.ShowDialog();
            return result == DialogResult.OK;
        }

        private static void FrmLogon_TryToLogon(object sender, EventArgs e)
        {
            JXCBusinessSchedule.TryToLogonForApplication();
        }

        internal static void StartApplication()
        {
            Application.Run(new FormMain());
        }

        internal static void CloseApplication()
        {
            JXCBusinessSchedule.TryToCloseApplication();
        }

        private static void JXCBusinessSchedule_ApplicationInitStepChanged(object sender, CommonEventArgs<AppStep> e)
        {
            if (e.Args.MajorPercentage == 100)
            {
                if (frmLogon != null)
                {
                    frmLogon.CloseFormWhileInitCompleted();
                }
            }
        }
        #endregion
    }
}
