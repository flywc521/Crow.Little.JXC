using System;
using System.Collections.Generic;
using System.Text;
using Crow.Little.Common;

namespace Crow.Little.DBHelper
{
    /// <summary>
    /// 单例的数据库访问器
    /// </summary>
    public class DBAccesser
    {
        #region Field
        private static DbProvider provider;
        private static string srv;
        private static string db;
        private static string uid;
        private static string pwd;

        private static AbstractDBAccess dbInstance;
        #endregion
        #region Property
        /// <summary>
        /// 数据库访问类实例
        /// </summary>
        public static AbstractDBAccess DbInstance
        {
            get
            {
                return dbInstance = dbInstance == null ? GetDbInstance() : dbInstance;
            }
        }
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 为数据库连接信息进行初始化操作
        /// </summary>
        /// <param name="_srv">服务器</param>
        /// <param name="_db">数据库</param>
        /// <param name="_uid">用户名</param>
        /// <param name="_pwd">密码</param>
        public static void InitDbInformation(DbProvider _provider, string _srv, string _db, string _uid, string _pwd)
        {
            provider = _provider;
            srv = _srv;
            db = _db;
            uid = _uid;
            pwd = _pwd;
        }
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        private static AbstractDBAccess GetDbInstance()
        {
            Type stringType = typeof(String);
            Type[] paramTypeArray = new Type[] { stringType, stringType, stringType, stringType };
            object[] paramObjArray = new object[] { srv, db, uid, pwd };

            AbstractDBAccess dbAccess = null;
            switch (provider)
            {
                case DbProvider.accdb: dbAccess = CommonSingleton<AccdbAccess>.GetInstance(paramTypeArray, paramObjArray) as AbstractDBAccess; break;
                case DbProvider.sqlite: dbAccess = CommonSingleton<SqliteAcess>.GetInstance(paramTypeArray, paramObjArray) as AbstractDBAccess; break;
            }

            return dbAccess;
        }
        #endregion
    }
}
