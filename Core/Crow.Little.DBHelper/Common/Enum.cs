using Crow.Little.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crow.Little.DBHelper
{
    /// <summary>
    /// This enum is used to indicate whether the connection was provided by the caller, or created by OleDbHelper, so that
    /// we can set the appropriate CommandBehavior when calling ExecuteReader()
    /// </summary>
    public enum DbConnectionOwnership
    {
        /// <summary>Connection is owned and managed by AccessHelper</summary>
        Internal,
        /// <summary>Connection is owned and managed by the caller</summary>
        External,
    }
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbProvider
    {
        /// <summary>
        /// 未声明
        /// </summary>
        [EnumDisplay("unknown", 100)]
        none,
        /// <summary>
        /// Access数据库
        /// </summary>
        [EnumDisplay("accdb", 1)]
        accdb,
        /// <summary>
        /// SqlLite数据库
        /// </summary>
        [EnumDisplay("sqlite", 0)]
        sqlite,
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        [EnumDisplay("mssql", 2)]
        mssql,
    }
}
