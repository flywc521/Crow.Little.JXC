using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Crow.Little.JXC
{
    public static class Program
    {
        #region Field
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (UIController.ApplicationLogon())
            {
                UIController.StartApplication();
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            UIController.CloseApplication();
        }
        #endregion
    }
}
