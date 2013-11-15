using Crow.Little.Common;
using Crow.Little.DBHelper;
using Crow.Little.JXC.BasicControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.JXC.ClothingControl
{
    public class ClothingMajorAssistant : MajorAssistant
    {
        #region Field
        private string _key = "clothing";
        #endregion
        #region Property
        protected override string DBKey
        {
            get { return _key; }
        }
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        public override void Init()
        {
            base.Init();
        }
        #endregion
    }
}
