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
                    return String.Format("Data Source={0};Version=3", DbName);
                }
                else
                {
                    return String.Format("Data Source={0};Version=3;Password={1};", DbName, Pwd);
                }
            }
        }

        private SQLiteConnection AccdbConnection
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
        #region Common Method
        public override DbParameter BuildDbParameter(string paraName, object paraValue)
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
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, AccdbConnection, (SQLiteTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

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
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;

            int retval = 0;
            foreach (MultSqlItem param in commandParams)
            {
                PrepareCommand(cmd, AccdbConnection, (SQLiteTransaction)null, commandType, param.CommandText, param.CommandParameters, out mustCloseConnection);

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
                PrepareCommand(cmd, AccdbConnection, (SQLiteTransaction)null, commandType, param.CommandText, param.CommandParameters, out mustCloseConnection);

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
            SQLiteCommand cmd = new SQLiteCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, AccdbConnection, (SQLiteTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
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
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, AccdbConnection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

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
            if (AccdbConnection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SQLiteCommand cmd = new SQLiteCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, AccdbConnection, (SQLiteTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

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

