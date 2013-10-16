namespace Crow.Little.CodeGeneratorLibrary
{
    using Crow.Little.Common;
    using Crow.Little.DBHelper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public static class DBOperator
    {
        #region Field
        private static string connectionString = String.Empty;
        private static DbProvider currentProvider = DbProvider.none;
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 针对Sqlite,Access等文件型数据库，db参数即数据库的路径 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="server"></param>
        /// <param name="db"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public static void InitConnection(int provider, string server, string db, string uid, string pwd)
        {
            currentProvider = (DbProvider)provider;

            if (currentProvider != DbProvider.none)
            {
                DBAccesser.InitDbInformation(currentProvider, server, db, uid, pwd);
            }
            else
            {
                throw new Exception(String.Format("当前程序不支持数据库类型[{0}]", provider));
            }
        }
        public static List<string> LoadDBNames()
        {
            string strSql = @"SELECT [name] FROM [sysdatabases] WHERE [name] NOT IN ('master','tempdb','model','msdb') ORDER BY [name]";
            List<string> dbNameList = new List<string>();

            using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
            {
                while (reader.Read())
                {
                    dbNameList.Add(reader.IsDBNull(0) ? String.Empty : reader.GetString(0));
                }
            }
            return dbNameList;
        }
        public static List<string> LoadTableNames()
        {
            string strSql = "";
            switch (currentProvider)
            {
                case DbProvider.sqlite: strSql = @"SELECT [name] FROM [sqlite_master] WHERE type = 'table' ORDER BY [name]"; break;
                case DbProvider.accdb: strSql = @"SELECT [name] FROM [msysobjects] WHERE type = 1 AND [flags] = 0 ORDER BY [name]"; break;
                case DbProvider.mssql:
                default: strSql = @"SELECT [name] FROM [sysobjects] WHERE [xtype] = 'U' ORDER BY [name]"; break;
            }


            List<string> tableNameList = new List<string>();

            using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
            {
                while (reader.Read())
                {
                    tableNameList.Add(reader.IsDBNull(0) ? String.Empty : reader.GetString(0));
                }
            }
            return tableNameList;
        }
        public static DBDescription LoadDBDescription()
        {
            string strSql = "";
            switch (currentProvider)
            {
                case DbProvider.sqlite: break;
                case DbProvider.accdb: break;
                case DbProvider.mssql:
                default: strSql = @"
SELECT 
    [TableName] = OBJECT_NAME(c.object_id), 
    [ColumnName] = c.name, 
    [Description] = ex.value 
FROM sys.columns c 
LEFT OUTER JOIN sys.extended_properties ex ON 
    ex.major_id = c.object_id AND ex.minor_id = c.column_id AND ex.name = 'MS_Description' 
WHERE OBJECTPROPERTY(c.object_id, 'IsMsShipped')=0 /* AND OBJECT_NAME(c.object_id) = 'your_table' */
ORDER BY OBJECT_NAME(c.object_id), c.column_id";
                    break;
            }

            DBDescription dbDesc = new DBDescription();
            if (!String.IsNullOrEmpty(strSql))
            {                
                using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
                {
                    while (reader.Read())
                    {
                        string tableName = reader.IsDBNull(0) ? String.Empty : reader.GetString(0);
                        string colName = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
                        string colDescription = reader.IsDBNull(2) ? String.Empty : reader.GetString(2);

                        if (!String.IsNullOrEmpty(tableName))
                        {
                            TableDescription tableDesc = dbDesc.GetOrCreateTableDescription(tableName);
                            if (!String.IsNullOrEmpty(colName))
                                tableDesc.AddColumnDescription(colName, colDescription);
                        }
                    }
                }
            }
            return dbDesc;
        }
        public static DataTable LoadSchemaForTable(string tableName)
        {
            string strSql = String.Format(@"SELECT * FROM [{0}] WHERE 1<>1", tableName);
            DataTable dtb = null;
            using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))
            {
                dtb = reader.GetSchemaTable();
            }
            return dtb;
        }
        #endregion
    }
}
