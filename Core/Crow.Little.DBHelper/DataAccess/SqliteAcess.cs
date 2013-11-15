using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Collections;
using System.Data.SQLite;
using System.Data.Common;
using System.Collections.Generic;

namespace Crow.Little.DBHelper
{
    /// <summary>
    /// SQLiteHelper is a utility class similar to "SQLHelper" in MS
    /// Data Access Application Block and follows similar pattern.
    /// </summary>
    public class SqliteAcess : AbstractDBAccess
    {
        #region Field
        private SQLiteConnection accdbConn;
        #endregion
        #region Property
        protected override string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(Pwd))
                {
                    return String.Format("Data Source={0};Version=3", ServerName);
                }
                else
                {
                    return String.Format("Data Source={0};Version=3;Password={1};", ServerName, Pwd);
                }
            }
        }

        private SQLiteConnection Connection
        {
            get { return accdbConn = accdbConn == null ? new SQLiteConnection(ConnectionString) : accdbConn; }
        }
        #endregion
        #region Constructor
        private SqliteAcess(string _srv, string _db, string _uid, string _pwd)
            : base(_srv, _db, _uid, _pwd)
        { }
        #endregion
        #region Event
        #endregion
        #region Method
        #region 构建数据库类型与系统类型的映射关系
        #region 布尔
        protected override void BuildBoolDbTypeMappingDict()
        {
            dbTypeMappingDict["bool"] = new DBTypeMapping()
            {
                DBType = "bit",
                SystemType = "bool",
                DefaultValue = "false",
                ConvertFromDB = "reader.GetBoolean({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Boolean,
            };
            dbTypeMappingDict["boolean"] = new DBTypeMapping()
            {
                DBType = "bit",
                SystemType = "bool",
                DefaultValue = "false",
                ConvertFromDB = "reader.GetBoolean({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Boolean,
            };
        }
        #endregion
        #region 整数
        protected override void BuildIntDbTypeMappingDict()
        {
            //整数
            dbTypeMappingDict["tinyint"] = new DBTypeMapping()
            {
                DBType = "tinyint",
                SystemType = "byte",
                DefaultValue = "(byte)0",
                ConvertFromDB = "reader.GetByte({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Byte,
            };
            dbTypeMappingDict["smallint"] = new DBTypeMapping()
            {
                DBType = "smallint",
                SystemType = "short",
                DefaultValue = "(short)0",
                ConvertFromDB = "reader.GetInt16({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Int16,
            };
            dbTypeMappingDict["int"] = new DBTypeMapping()
            {
                DBType = "int",
                SystemType = "int",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetInt32({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Int32,
            };
            dbTypeMappingDict["bigint"] = new DBTypeMapping()
            {
                DBType = "bigint",
                SystemType = "long",
                DefaultValue = "(long)0",
                ConvertFromDB = "reader.GetInt64({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Int64,
            };
            dbTypeMappingDict["integer"] = new DBTypeMapping()
            {
                DBType = "integer",
                SystemType = "long",
                DefaultValue = "(long)0",
                ConvertFromDB = "reader.GetInt64({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Int64,
            };
        }
        #endregion
        #region 日期
        protected override void BuildDateTimeDbTypeMappingDict()
        {
            //日期时间
            dbTypeMappingDict["date"] = new DBTypeMapping()
            {
                DBType = "date",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Date,
            };
            dbTypeMappingDict["datetime"] = new DBTypeMapping()
            {
                DBType = "datetime",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.DateTime,
            };
            dbTypeMappingDict["time"] = new DBTypeMapping()
            {
                DBType = "time",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Time,
            };
            dbTypeMappingDict["timestamp"] = new DBTypeMapping()
            {
                DBType = "timestamp",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.DateTime,
            };            
        }
        #endregion
        #region 小数
        protected override void BuildDecimalDbTypeMappingDict()
        {
            //小数
            dbTypeMappingDict["real"] = new DBTypeMapping()
            {
                DBType = "real",
                SystemType = "float",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetFloat({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Double,
            };
            dbTypeMappingDict["float"] = new DBTypeMapping()
            {
                DBType = "float",
                SystemType = "double",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDouble({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Double,
            };
            dbTypeMappingDict["double"] = new DBTypeMapping()
            {
                DBType = "double",
                SystemType = "double",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDouble({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Double,
            };
            dbTypeMappingDict["decimal"] = new DBTypeMapping()
            {
                DBType = "decimal",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Decimal,
            };
            dbTypeMappingDict["money"] = new DBTypeMapping()
            {
                DBType = "money",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Decimal,
            };
            dbTypeMappingDict["currency"] = new DBTypeMapping()
            {
                DBType = "currency",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Decimal,
            };
            dbTypeMappingDict["numeric"] = new DBTypeMapping()
            {
                DBType = "numeric",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Decimal,
            };
        }
        #endregion
        #region 字符串
        protected override void BuildStringDbTypeMappingDict()
        {
            //字符串
            dbTypeMappingDict["char"] = new DBTypeMapping()
            {
                DBType = "char",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["nchar"] = new DBTypeMapping()
            {
                DBType = "nchar",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["ntext"] = new DBTypeMapping()
            {
                DBType = "ntext",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["nvarchar"] = new DBTypeMapping()
            {
                DBType = "nvarchar",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["text"] = new DBTypeMapping()
            {
                DBType = "text",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["varchar"] = new DBTypeMapping()
            {
                DBType = "varchar",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["varchar2"] = new DBTypeMapping()
            {
                DBType = "varchar2",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
            dbTypeMappingDict["memo"] = new DBTypeMapping()
            {
                DBType = "memo",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.String,
            };
        }
        #endregion
        #region Byte数组
        protected override void BuildByteArrayDbTypeMappingDict()
        {
            //二进制数组
            dbTypeMappingDict["binary"] = new DBTypeMapping()
            {
                DBType = "binary",
                SystemType = "byte[]",
                DefaultValue = "null",
                ConvertFromDB = "(byte[])reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Binary,
            };
            dbTypeMappingDict["blob"] = new DBTypeMapping()
            {
                DBType = "blob",
                SystemType = "byte[]",
                DefaultValue = "null",
                ConvertFromDB = "(byte[])reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Binary,
            };
            dbTypeMappingDict["image"] = new DBTypeMapping()
            {
                DBType = "image",
                SystemType = "string",
                DefaultValue = "null",
                ConvertFromDB = "Convert.ToBase64String((byte[])reader.GetValue({0}))",
                ConvertToDB = "(model.{0} == null ? null : Convert.FromBase64String(model.{0}))",
                DbType = System.Data.DbType.Binary,
            };
            dbTypeMappingDict["varbinary"] = new DBTypeMapping()
            {
                DBType = "varbinary",
                SystemType = "string",
                DefaultValue = "null",
                ConvertFromDB = "Convert.ToBase64String((byte[])reader.GetValue({0}))",
                ConvertToDB = "(model.{0} == null ? null : Convert.FromBase64String(model.{0}))",
                DbType = System.Data.DbType.Binary,
            };
        }
        #endregion
        #region 其它
        protected override void BuildOtherDbTypeMappingDict()
        {
            //Guid
            dbTypeMappingDict["uniqueidentifier"] = new DBTypeMapping()
            {
                DBType = "uniqueidentifier",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetGuid({0}).ToString()",
                ConvertToDB = "CommonConvertor.TryToConverToGuid(model.{0})",
                DbType = System.Data.DbType.Guid,
            };
            dbTypeMappingDict["guid"] = new DBTypeMapping()
            {
                DBType = "guid",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetGuid({0}).ToString()",
                ConvertToDB = "CommonConvertor.TryToConverToGuid(model.{0})",
                DbType = System.Data.DbType.Guid,
            };
            //object(包括sql_variant等在内的未涉及类型)
            dbTypeMappingDict["object"] = new DBTypeMapping()
            {
                DBType = "object",
                SystemType = "object",
                DefaultValue = "null",
                ConvertFromDB = "reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Object,
            };
        }
        #endregion
        #endregion

        #region Common Method
        public override DbParameter BuildDbParameter(string paraName, object paraValue, DbType dbtype = DbType.String)
        {
            return new SQLiteParameter(paraName, paraValue);
        }
        #endregion Common Method

        #region ExecuteNonQuery
        public override int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, CommandType.Text);
        }

        public override int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteNonQuery(commandText, commandType, commandParameters);
        }

        public override int ExecuteNonQuery(string commandText, CommandType commandType, params  DbParameter[] commandParameters)
        {
            if (Connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, Connection, (SQLiteTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the OleDbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                Connection.Close();
            return retval;
        }

        public override int ExecuteNonQuery(List<MultSqlItem> commandParams, CommandType commandType)
        {
            if (Connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;

            int retval = 0;
            foreach (MultSqlItem param in commandParams)
            {
                PrepareCommand(cmd, Connection, (SQLiteTransaction)null, commandType, param.CommandText, param.CommandParameters, out mustCloseConnection);

                // Finally, execute the command
                retval += cmd.ExecuteNonQuery();

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
            }
            if (mustCloseConnection)
                Connection.Close();
            return retval;
        }

        public override int ExecuteNonQuery(string commandText, DbTransaction commandTransaction)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, commandTransaction);
        }

        public override int ExecuteNonQuery(string commandText, CommandType commandType, DbTransaction commandTransaction)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteNonQuery(commandText, commandType, commandTransaction, commandParameters);
        }

        public override int ExecuteNonQuery(string commandText, CommandType commandType, DbTransaction commandTransaction, params  DbParameter[] commandParameters)
        {
            if (commandTransaction == null) throw new ArgumentNullException("transaction");
            if (commandTransaction != null && commandTransaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, commandTransaction.Connection, commandTransaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the OleDbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }

        public override int ExecuteNonQuery(List<MultSqlItem> commandParams, CommandType commandType, DbTransaction commandTransaction)
        {
            if (commandTransaction == null) throw new ArgumentNullException("transaction");
            if (commandTransaction != null && commandTransaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            int retval = 0;
            foreach (MultSqlItem param in commandParams)
            {
                PrepareCommand(cmd, Connection, (SQLiteTransaction)null, commandType, param.CommandText, param.CommandParameters, out mustCloseConnection);

                // Finally, execute the command
                retval += cmd.ExecuteNonQuery();

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
            }

            return retval;
        }
        #endregion ExecuteNonQuery

        #region ExecuteDataSet
        public override DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(commandText, CommandType.Text);
        }

        public override DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteDataSet(commandText, commandType, commandParameters);
        }

        public override DataSet ExecuteDataSet(string commandText, CommandType commandType, params   DbParameter[] commandParameters)
        {
            if (Connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, Connection, (SQLiteTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    Connection.Close();

                // Return the dataset
                return ds;
            }
        }

        public override DataSet ExecuteDataSet(string commandText, DbTransaction commandTransaction)
        {
            return ExecuteDataSet(commandText, CommandType.Text, commandTransaction);
        }

        public override DataSet ExecuteDataSet(string commandText, CommandType commandType, DbTransaction commandTransaction)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteDataSet(commandText, commandType, commandTransaction, commandParameters);
        }

        public override DataSet ExecuteDataSet(string commandText, CommandType commandType, DbTransaction commandTransaction, params DbParameter[] commandParameters)
        {
            if (commandTransaction == null) throw new ArgumentNullException("transaction");
            if (commandTransaction != null && commandTransaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, commandTransaction.Connection, commandTransaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                // Return the dataset
                return ds;
            }
        }
        #endregion ExecuteDataSet

        #region DbDataReader
        private SQLiteDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, DbConnectionOwnership connectionOwnership)
        {
            if (Connection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // Create a reader
                SQLiteDataReader dataReader;

                // Call ExecuteReader with the appropriate CommandBehavior
                if (connectionOwnership == DbConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                    Connection.Close();
                throw;
            }
        }

        public override DbDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText, CommandType.Text);
        }

        public override DbDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteReader(commandText, commandType, commandParameters);
        }

        public override DbDataReader ExecuteReader(string commandText, CommandType commandType, params DbParameter[] commandParameters)
        {
            return ExecuteReader((SQLiteTransaction)null, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        public override DbDataReader ExecuteReader(string commandText, DbTransaction commandTransaction)
        {
            return ExecuteReader(commandText, CommandType.Text, commandTransaction);
        }

        public override DbDataReader ExecuteReader(string commandText, CommandType commandType, DbTransaction commandTransaction)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteReader(commandText, CommandType.Text, commandTransaction, commandParameters);
        }

        public override DbDataReader ExecuteReader(string commandText, CommandType commandType, DbTransaction commandTransaction, params DbParameter[] commandParameters)
        {
            if (commandTransaction == null) throw new ArgumentNullException("transaction");
            if (commandTransaction != null && commandTransaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Pass through to private overload, indicating that the connection is owned by the caller
            return ExecuteReader(commandTransaction, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }
        #endregion DbDataReader

        #region ExecuteScalar
        public override object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, CommandType.Text);
        }

        public override object ExecuteScalar(string commandText, CommandType commandType)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteScalar(commandText, commandType, commandParameters);
        }

        public override object ExecuteScalar(string commandText, CommandType commandType, DbParameter[] commandParameters)
        {
            if (Connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, Connection, (SQLiteTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the OleDbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                Connection.Close();

            return retval;
        }

        public override object ExecuteScalar(string commandText, DbTransaction commandTransaction)
        {
            return ExecuteScalar(commandText, CommandType.Text, commandTransaction);
        }

        public override object ExecuteScalar(string commandText, CommandType commandType, DbTransaction commandTransaction)
        {
            DbParameter[] commandParameters = new DbParameter[0];
            return ExecuteScalar(commandText, commandType, commandTransaction, commandParameters);
        }

        public override object ExecuteScalar(string commandText, CommandType commandType, DbTransaction commandTransaction, DbParameter[] commandParameters)
        {
            if (commandTransaction == null) throw new ArgumentNullException("transaction");
            if (commandTransaction != null && commandTransaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, commandTransaction.Connection, commandTransaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the OleDbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }
        #endregion ExecuteScalar
        #endregion
    }
}

