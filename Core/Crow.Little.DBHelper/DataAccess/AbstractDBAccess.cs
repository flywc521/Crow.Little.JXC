using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Crow.Little.DBHelper
{
    /// <summary>
    /// 通用数据库访问抽象类
    /// </summary>
    public abstract class AbstractDBAccess
    {
        #region Field
        private string serverName = String.Empty;
        private string dbName = String.Empty;
        private string uid = String.Empty;
        private string pwd = String.Empty;

        protected Dictionary<string, DBTypeMapping> dbTypeMappingDict = new Dictionary<string, DBTypeMapping>();
        #endregion

        #region Property
        /// <summary>
        /// 服务器名称(只读)
        /// </summary>
        protected string ServerName
        {
            get { return serverName; }
        }

        /// <summary>
        /// 数据库名称(只读)
        /// </summary>
        protected string DbName
        {
            get { return dbName; }
        }

        /// <summary>
        /// 数据库用户名(只读,没有的话为空字符串)
        /// </summary>
        protected string Uid
        {
            get { return uid; }
        }

        /// <summary>
        /// 数据库密码(只读,没有的话为空字符串)
        /// </summary>
        protected string Pwd
        {
            get { return pwd; }
        }

        /// <summary>
        /// 数据库连接串
        /// </summary>
        protected abstract string ConnectionString
        {
            get;
        }
        #endregion

        #region Constructor
        protected AbstractDBAccess(string _srv, string _db, string _uid, string _pwd)
        {
            serverName = _srv;
            dbName = _db;
            uid = _uid;
            pwd = _pwd;

            BuildDbTypeMappingDict();
        }
        #endregion

        #region Event
        #endregion

        #region Method
        #region 构建数据库类型与系统类型的映射关系
        /// <summary>
        /// 在静态构造函数中构建各种DB数据类型对应的系统类型及转换方法的字典
        /// </summary>
        private void BuildDbTypeMappingDict()
        {
            BuildBoolDbTypeMappingDict();
            BuildIntDbTypeMappingDict();
            BuildDateTimeDbTypeMappingDict();
            BuildDecimalDbTypeMappingDict();
            BuildStringDbTypeMappingDict();
            BuildByteArrayDbTypeMappingDict();
            BuildOtherDbTypeMappingDict();
        }
        protected abstract void BuildBoolDbTypeMappingDict();
        protected abstract void BuildIntDbTypeMappingDict();
        protected abstract void BuildDateTimeDbTypeMappingDict();
        protected abstract void BuildDecimalDbTypeMappingDict();
        protected abstract void BuildStringDbTypeMappingDict();
        protected abstract void BuildByteArrayDbTypeMappingDict();
        protected abstract void BuildOtherDbTypeMappingDict();

        public DBTypeMapping GetColumnDataTypeMapping(string dataTypeName)
        {
            dataTypeName = dataTypeName.ToLower().Trim();

            DBTypeMapping mapping = new DBTypeMapping();
            if (dbTypeMappingDict.ContainsKey(dataTypeName))
                mapping = dbTypeMappingDict[dataTypeName];
            else
                mapping = dbTypeMappingDict["object"];
            return mapping;
        }
        #endregion

        #region Common Method
        public abstract DbParameter BuildDbParameter(string paraName, object paraValue, DbType dbtype = DbType.String);

        protected void AttachParameters(DbCommand command, DbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (DbParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input)
                            && (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        protected void AssignParameterValues(DbParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                // Do nothing if we get no data
                return;
            }

            int i = 0;
            // Set the parameters values
            foreach (DbParameter commandParameter in commandParameters)
            {
                // Check the parameter name
                if (commandParameter.ParameterName == null || commandParameter.ParameterName.Length <= 1)
                    throw new Exception(string.Format(
                        "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
                        i, commandParameter.ParameterName));
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        protected void AssignParameterValues(DbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the OleDbParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        protected void PrepareCommand(DbCommand command, DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or OleDb statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }
        #endregion Common Method

        #region ExecuteNonQuery
        public abstract int ExecuteNonQuery(string commandText);
        public abstract int ExecuteNonQuery(string commandText, CommandType commandType);
        public abstract int ExecuteNonQuery(string commandText, CommandType commandType, params DbParameter[] commandParameters);
        public abstract int ExecuteNonQuery(List<MultSqlItem> commandParams, CommandType commandType);
        public abstract int ExecuteNonQuery(string commandText, DbTransaction commandTransaction);
        public abstract int ExecuteNonQuery(string commandText, CommandType commandType, DbTransaction commandTransaction);
        public abstract int ExecuteNonQuery(string commandText, CommandType commandType, DbTransaction commandTransaction, params DbParameter[] commandParameters);
        public abstract int ExecuteNonQuery(List<MultSqlItem> commandParams, CommandType commandType, DbTransaction commandTransaction);
        #endregion ExecuteNonQuery

        #region ExecuteDataSet
        public abstract DataSet ExecuteDataSet(string commandText);
        public abstract DataSet ExecuteDataSet(string commandText, CommandType commandType);
        public abstract DataSet ExecuteDataSet(string commandText, CommandType commandType, params DbParameter[] commandParameters);
        public abstract DataSet ExecuteDataSet(string commandText, CommandType commandType, DbTransaction commandTransaction);
        public abstract DataSet ExecuteDataSet(string commandText, DbTransaction commandTransaction);
        public abstract DataSet ExecuteDataSet(string commandText, CommandType commandType, DbTransaction commandTransaction, params DbParameter[] commandParameters);
        #endregion ExecuteDataSet

        #region ExecuteReader
        public abstract DbDataReader ExecuteReader(string commandText);
        public abstract DbDataReader ExecuteReader(string commandText, CommandType commandType);
        public abstract DbDataReader ExecuteReader(string commandText, CommandType commandType, params DbParameter[] commandParameters);
        public abstract DbDataReader ExecuteReader(string commandText, DbTransaction commandTransaction);
        public abstract DbDataReader ExecuteReader(string commandText, CommandType commandType, DbTransaction commandTransaction);
        public abstract DbDataReader ExecuteReader(string commandText, CommandType commandType, DbTransaction commandTransaction, params  DbParameter[] commandParameters);
        #endregion ExecuteReader

        #region ExecuteScalar
        public abstract object ExecuteScalar(string commandText);
        public abstract object ExecuteScalar(string commandText, CommandType commandType);
        public abstract object ExecuteScalar(string commandText, CommandType commandType, params  DbParameter[] commandParameters);
        public abstract object ExecuteScalar(string commandText, DbTransaction commandTransaction);
        public abstract object ExecuteScalar(string commandText, CommandType commandType, DbTransaction commandTransaction);
        public abstract object ExecuteScalar(string commandText, CommandType commandType, DbTransaction commandTransaction, params  DbParameter[] commandParameters);
        #endregion ExecuteScalar
        #endregion
    }
}
