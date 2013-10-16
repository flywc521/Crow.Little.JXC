using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Data.Common;

namespace Crow.Little.DBHelper
{
    /// <summary>
    /// The OleDbHelper class is intended to encapsulate high performance, scalable best practices for 
    /// common uses of OleDbClient
    /// </summary>
    public class AccdbAccess : AbstractDBAccess
    {
        #region Field
        private OleDbConnection accdbConn;
        #endregion

        #region Property
        protected override string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(Pwd))
                {
                    return String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", ServerName);
                }
                else
                {
                    return String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password={1};", ServerName, Pwd);
                }
            }
        }

        private OleDbConnection AccdbConnection
        {
            get { return accdbConn = accdbConn == null ? new OleDbConnection(ConnectionString) : accdbConn; }
        }
        #endregion

        #region Constructor
        private AccdbAccess(string _srv, string _db, string _uid, string _pwd)
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
            //布尔
            dbTypeMappingDict["bit"] = new DBTypeMapping()
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
            dbTypeMappingDict["datetime2"] = new DBTypeMapping()
            {
                DBType = "datetime2",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.DateTime2,
            };
            dbTypeMappingDict["smalldatetime"] = new DBTypeMapping()
            {
                DBType = "smalldatetime",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.DateTime,
            };
            dbTypeMappingDict["datetimeoffset"] = new DBTypeMapping()
            {
                DBType = "datetimeoffset",
                SystemType = "DateTimeOffset",
                DefaultValue = "DateTimeOffset.MinValue",
                ConvertFromDB = "reader.GetDateTimeOffset({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.DateTimeOffset,
            };
            dbTypeMappingDict["time"] = new DBTypeMapping()
            {
                DBType = "time",
                SystemType = "TimeSpan",
                DefaultValue = "TimeSpan.MinValue",
                ConvertFromDB = "reader.GetTimeSpan({0})",
                ConvertToDB = "model.{0}",
                DbType = System.Data.DbType.Time,
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
            dbTypeMappingDict["smallmoney"] = new DBTypeMapping()
            {
                DBType = "smallmoney",
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
            dbTypeMappingDict["varbinary"] = new DBTypeMapping()
            {
                DBType = "varbinary",
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
        }
        #endregion
        #region 其它
        protected override void BuildOtherDbTypeMappingDict()
        {
            //Xml
            dbTypeMappingDict["xml"] = new DBTypeMapping()
            {
                DBType = "xml",
                SystemType = "XmlDocument",
                DefaultValue = "new XmlDocument()",
                ConvertFromDB = "DataAccesser.ConvertToXmlDocument(reader.GetString({0}))",
                ConvertToDB = "DataAccesser.ConvertFromXmlDocument(model.{0})",
                DbType = System.Data.DbType.Xml,
            };
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
            return new OleDbParameter(paraName, paraValue);
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
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, AccdbConnection, (OleDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the OleDbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                AccdbConnection.Close();
            return retval;
        }

        public override int ExecuteNonQuery(List<MultSqlItem> commandParams, CommandType commandType)
        {
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;

            int retval = 0;
            foreach (MultSqlItem param in commandParams)
            {
                PrepareCommand(cmd, AccdbConnection, (OleDbTransaction)null, commandType, param.CommandText, param.CommandParameters, out mustCloseConnection);

                // Finally, execute the command
                retval += cmd.ExecuteNonQuery();

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
            }
            if (mustCloseConnection)
                AccdbConnection.Close();
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
            OleDbCommand cmd = new OleDbCommand();
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
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            int retval = 0;
            foreach (MultSqlItem param in commandParams)
            {
                PrepareCommand(cmd, AccdbConnection, (OleDbTransaction)null, commandType, param.CommandText, param.CommandParameters, out mustCloseConnection);

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
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, AccdbConnection, (OleDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the OleDbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    AccdbConnection.Close();

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
            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, commandTransaction.Connection, commandTransaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
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
        private OleDbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, DbConnectionOwnership connectionOwnership)
        {
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, AccdbConnection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // Create a reader
                OleDbDataReader dataReader;

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
                    AccdbConnection.Close();
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
            return ExecuteReader((OleDbTransaction)null, commandType, commandText, commandParameters, DbConnectionOwnership.External);
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
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, AccdbConnection, (OleDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the OleDbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                AccdbConnection.Close();

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
            OleDbCommand cmd = new OleDbCommand();
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

