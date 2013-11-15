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
        private static Dictionary<string, Tuple<DbProvider, string, string, string, string>> dbParamsDict = new Dictionary<string, Tuple<DbProvider, string, string, string, string>>();
        private static Dictionary<string, AbstractDBAccess> dbInstanceDict = new Dictionary<string, AbstractDBAccess>();
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 为数据库连接信息进行初始化操作
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_provider"></param>
        /// <param name="_srv">服务器</param>
        /// <param name="_db">数据库</param>
        /// <param name="_uid">用户名</param>
        /// <param name="_pwd">密码</param>
        public static void InitDbInformation(string _key, DbProvider _provider, string _srv, string _db, string _uid, string _pwd)
        {
            dbParamsDict[_key] = new Tuple<DbProvider, string, string, string, string>(_provider, _srv, _db, _uid, _pwd);
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static AbstractDBAccess GetDbInstance(string _key)
        {
            Type stringType = typeof(String);
            Type[] paramTypeArray = new Type[] { stringType, stringType, stringType, stringType };
            if (!dbParamsDict.ContainsKey(_key))
            {
                return null;
            }
            object[] paramObjArray = new object[] { dbParamsDict[_key].Item2, dbParamsDict[_key].Item3, dbParamsDict[_key].Item4, dbParamsDict[_key].Item5 };

            AbstractDBAccess dbAccess = null;
            switch (dbParamsDict[_key].Item1)
            {
                case DbProvider.accdb: dbAccess = CommonSingleton<AccdbAccess>.GetInstance(paramTypeArray, paramObjArray) as AbstractDBAccess; break;
                case DbProvider.sqlite: dbAccess = CommonSingleton<SqliteAcess>.GetInstance(paramTypeArray, paramObjArray) as SqliteAcess; break;
            }

            return dbAccess;
        }
        #endregion
    }
}
