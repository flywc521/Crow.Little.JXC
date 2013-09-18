using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crow.Little.CommonControl
{
    public partial class CloseableTabPage : TabPage
    {
        #region Field
        private bool showCloseButton = true;
        #endregion
        #region Property
        public bool ShowCloseButton
        {
            get { return showCloseButton; }
            set { showCloseButton = value; }
        }
        #endregion
        #region Constructor
        public CloseableTabPage()
            : base()
        {
            InitializeComponent();
        }
        #endregion
        #region Event
        #endregion
        #region Method
        #endregion
    }
}
