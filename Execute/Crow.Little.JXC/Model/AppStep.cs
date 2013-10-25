using System;
using System.Collections.Generic;
using System.Text;

namespace Crow.Little.JXC
{
    public class AppStep
    {
        #region Field
        private uint majorPercentage;
        private uint secondPercentage;
        private string description = String.Empty;
        #endregion
        #region Property
        public uint MajorPercentage
        {
            get { return majorPercentage; }
        }

        public uint SecondPercentage
        {
            get { return secondPercentage; }
        }

        public string Description
        {
            get { return description; }
        }
        #endregion
        #region Constructor
        public AppStep(uint _major, uint _second, string _desc)
        {
            majorPercentage = _major;
            secondPercentage = _second;
            description = _desc;
        }
        #endregion
        #region Event
        #endregion
        #region Method
        #endregion
    }
}
