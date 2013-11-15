using Crow.Little.Common;
using Crow.Little.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.JXC.BasicControl
{
    public class MajorAssistant
    {
        #region Field
        private string _key = "basic";
        private AbstractDBAccess dbInstance = null;
        #endregion
        #region Property
        protected virtual string DBKey
        {
            get { return _key; }
        }
        public AbstractDBAccess DbInstance
        {
            get
            {
                if (dbInstance == null)
                    dbInstance = DBAccesser.GetDbInstance(DBKey);
                return dbInstance;
            }
        }
        #endregion
        #region Constructor
        protected MajorAssistant()
        { }
        #endregion
        #region Event
        #endregion
        #region Method
        public virtual void Init()
        {
            InitDb();
        }
        protected virtual void InitDb()
        {
            DbProvider _provider = DbProvider.sqlite;
            string _srv = @"E:\personal\privateProjects\Crow.Little.JXC\Data\jxcData.db";
            string _db = String.Empty;
            string _uid = String.Empty;
            string _pwd = String.Empty;
            DBAccesser.InitDbInformation(_key, _provider, _srv, _db, _uid, _pwd);
        }
        #endregion
    }
}
