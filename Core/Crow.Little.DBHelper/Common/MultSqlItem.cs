using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Crow.Little.DBHelper
{
    /// <summary>
    /// 批量数据库执行参数
    /// </summary>
    public class MultSqlItem
    {
        #region Field
        private string commandText;
        private DbParameter[] commandParameters;
        #endregion

        #region Property
        public string CommandText
        {
            get { return commandText; }
            set { commandText = value; }
        }

        public DbParameter[] CommandParameters
        {
            get { return commandParameters; }
            set { commandParameters = value; }
        }
        #endregion

        #region Constructor
        #endregion

        #region Event
        #endregion

        #region Method
        #endregion
    }
}
