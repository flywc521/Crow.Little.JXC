namespace Crow.Little.CodeGeneratorLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class DALCodeBuilder : CodeBuilder
    {
        protected override string GenerateUsingCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            StringBuilder sbl = new StringBuilder(256);

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using Crow.Little.Common;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using Crow.Little.DBHelper;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Collections.Generic;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Data;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Data.Common;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Drawing;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Xml;"));

            string modelNameSpace = CodeBuilderAssistant.GetModelNameSpace();
            if (!String.IsNullOrEmpty(modelNameSpace))
                sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using {0};", modelNameSpace));

            return sbl.ToString();
        }
        protected override string GenerateFieldCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            //StringBuilder sbl = new StringBuilder(256);
            //sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "private string TestConnectionString = ConnectionString.GetTestConnectionString();"));
            //return sbl.ToString();
            return base.GenerateFieldCodes(tableName, schema, tableDesc);
        }
        protected override string GenerateMethodCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            string modelName = CodeBuilderAssistant.GetModelName(tableName);

            bool hasPK = schema.AsEnumerable().Where(r => (bool)r["IsKey"]).Count() > 0;

            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(BuildLoadAllMethod(schema, modelName, tableName));
            if (hasPK)
            {
                sbl.AppendLine(BuildLoadByPrimaryKeyMethod(schema, modelName, tableName));
                //sbl.AppendLine(BuildDeleteAllMethod(schema, modelName, tableName));
                sbl.AppendLine(BuildLoadPagingMethod(schema, modelName, tableName));
                sbl.AppendLine(BuildDeleteByPrimaryKeyMethod(schema, modelName, tableName));
                sbl.AppendLine(BuildUpdateMethod(schema, modelName, tableName));
            }
            sbl.AppendLine(BuildInsertMethod(schema, modelName, tableName));
            return sbl.ToString();
        }

        private string BuildLoadAllMethod(DataTable schema, string modelName, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public static List<{0}> LoadAll()", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "List<{0}> itemList = new List<{0}>();", modelName));
            sbl.AppendLine();

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"string strSql = @""{0}"";", BuildSelectAllSqlCode(schema, tableName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql))"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "while (reader.Read())"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, @"{0} model = new {0}();", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildDBToModelCode(schema, modelName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, "itemList.Add(model);"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "}"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "}"));
            sbl.AppendLine();

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "return itemList;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "}"));
            return sbl.ToString();
        }
        private string BuildSelectAllSqlCode(DataTable schema, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine();
            sbl.Append("SELECT ");
            foreach (DataRow colRow in schema.Rows)
            {
                sbl.AppendFormat("[{0}],", colRow["ColumnName"]);
            }
            if (schema.Rows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 1, 1);
            else
                sbl.Append("* ");
            sbl.AppendLine();

            sbl.AppendFormat("FROM [{0}]", tableName);
            return sbl.ToString();
        }
        private string BuildDBToModelCode(DataTable schema, string modelName)
        {
            StringBuilder sbl = new StringBuilder(256);
            int idx = 0;
            foreach (DataRow row in schema.Rows)
            {
                string propertyName = CodeBuilderAssistant.GetPropertyName(row["ColumnName"].ToString());
                string dbTypeName = row["DataTypeName"].ToString();
                string defaultValueCode = CodeBuilderAssistant.GetColumnDefaultValue(dbTypeName);
                string convertActionCode = CodeBuilderAssistant.GetColumnConvertFromDBCode(dbTypeName, idx);
                sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, "model.{0} = reader.IsDBNull({1}) ? {2} : {3};", propertyName, idx, defaultValueCode, convertActionCode));
                idx++;
            }

            return sbl.ToString();
        }

        private string BuildLoadPagingMethod(DataTable schema, string modelName, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public static List<{0}> LoadPaging(int pagesize, int pagenum)", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "List<{0}> itemList = new List<{0}>();", modelName));
            sbl.AppendLine();
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"string strSql = @""{0}"";", BuildLoadPagingSqlCode(schema, tableName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"List<DbParameter> paramList = new List<DbParameter>();"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"paramList.Add(new DbParameter(""@pagenum"", pagenum) { SqlDbType = SqlDbType.Int });"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"paramList.Add(new DbParameter(""@pagesize"", pagesize) { SqlDbType = SqlDbType.Int });"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql, paramList.ToArray()))"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "while (reader.Read())"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, @"{0} model = new {0}();", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildDBToModelCode(schema, modelName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, "itemList.Add(model);"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "}"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "}"));
            sbl.AppendLine();

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "return itemList;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "}"));
            return sbl.ToString();
        }
        private string BuildLoadPagingSqlCode(DataTable schema, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine();
            sbl.AppendLine("WITH [Tmp] AS ");
            sbl.AppendLine("(");
            sbl.AppendFormat("    SELECT ROW_NUMBER() OVER (ORDER BY {0} ASC) AS [colnum],", BuildPrimaryKeyOrderCode(schema));
            foreach (DataRow colRow in schema.Rows)
            {
                sbl.AppendFormat("[{0}],", colRow["ColumnName"]);
            }
            sbl = sbl.Remove(sbl.Length - 1, 1);
            sbl.AppendLine();
            sbl.AppendFormat("    FROM [{0}]", tableName);
            sbl.AppendLine(")");
            sbl.Append("SELECT ");
            foreach (DataRow colRow in schema.Rows)
            {
                sbl.AppendFormat("[{0}],", colRow["ColumnName"]);
            }
            if (schema.Rows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 1, 1);
            else
                sbl.Append("* ");
            sbl.AppendLine();

            sbl.AppendLine("FROM [Tmp]");
            sbl.AppendLine("WHERE [colnum] > ( @pagenum - 1 ) * @pagesize AND [colnum] <= @pagenum * @pagesize");
            return sbl.ToString();
        }
        private string BuildPrimaryKeyOrderCode(DataTable schema)
        {
            StringBuilder sbl = new StringBuilder(256);
            List<DataRow> pkRows = schema.AsEnumerable().Where(r => (bool)r["IsKey"]).ToList();
            foreach (DataRow row in pkRows)
            {
                sbl.AppendFormat(@"[{0}], ", row["ColumnName"]);
            }
            if (pkRows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 2, 2);
            return sbl.ToString();
        }

        private string BuildLoadByPrimaryKeyMethod(DataTable schema, string modelName, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public static {0} Load({1})", modelName, BuildPrimaryKeyParamsCode(schema)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "{0} model = null;", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"string strSql = @""{0}"";", BuildSelectByPrimaryKeySqlCode(schema, tableName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"List<DbParameter> paramList = new List<DbParameter>();"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildPrimaryKeyModelToDBCode(schema)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "using (DbDataReader reader = DBAccesser.DbInstance.ExecuteReader(strSql, paramList.ToArray()))"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "while (reader.Read())"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, "model = new {0}();", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildDBToModelCode(schema, modelName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(5, "break;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(4, "}"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "}"));
            sbl.AppendLine();
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "return model;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "}"));
            return sbl.ToString();
        }
        private string BuildPrimaryKeyParamsCode(DataTable schema)
        {
            StringBuilder sbl = new StringBuilder(256);
            List<DataRow> pkRows = schema.AsEnumerable().Where(r => (bool)r["IsKey"]).ToList();
            foreach (DataRow row in pkRows)
            {
                string paramName = CodeBuilderAssistant.GetPropertyName(row["ColumnName"].ToString());
                string dbTypeName = row["DataTypeName"].ToString();
                string sysTypeName = CodeBuilderAssistant.GetColumnType(dbTypeName);
                sbl.AppendFormat(@"{0} {1}, ", sysTypeName, paramName);
            }
            if (pkRows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 2, 2);
            return sbl.ToString();
        }
        private string BuildSelectByPrimaryKeySqlCode(DataTable schema, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine();
            sbl.Append("SELECT ");
            foreach (DataRow colRow in schema.Rows)
            {
                sbl.AppendFormat("[{0}],", colRow["ColumnName"]);
            }
            if (schema.Rows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 1, 1);
            else
                sbl.Append("* ");
            sbl.AppendLine();

            sbl.AppendFormat("FROM [{0}]", tableName);
            sbl.AppendLine();
            sbl.Append("WHERE ");
            List<DataRow> pkRows = schema.AsEnumerable().Where(r => (bool)r["IsKey"]).ToList();
            foreach (DataRow row in pkRows)
            {
                string columnName = row["ColumnName"].ToString();
                sbl.AppendFormat(@"[{0}] = @{0} AND ", columnName);
            }
            if (pkRows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 4, 4);
            else
                sbl.Append("1<>1");

            return sbl.ToString();
        }
        private string BuildPrimaryKeyModelToDBCode(DataTable schema)
        {
            StringBuilder sbl = new StringBuilder(256);
            foreach (DataRow row in schema.Rows)
            {
                if ((bool)row["IsKey"])
                {
                    string propertyName = CodeBuilderAssistant.GetPropertyName(row["ColumnName"].ToString());
                    string dbTypeName = row["DataTypeName"].ToString();
                    string convertActionCode = CodeBuilderAssistant.GetColumnConvertToDBCode(dbTypeName, propertyName).Replace("model.", String.Empty);
                    string sqlDbType = CodeBuilderAssistant.GetColumnSqlDbType(dbTypeName);
                    sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"paramList.Add(new DbParameter(""@{0}"", {1}) {{ SqlDbType = SqlDbType.{2} }});", row["ColumnName"], convertActionCode, sqlDbType));
                }
            }
            return sbl.ToString();
        }

        private string BuildUpdateMethod(DataTable schema, string modelName, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public static bool Update({0} model)", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"string strSql = @""{0}"";", BuildUpdateSqlCode(schema, tableName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"List<DbParameter> paramList = new List<DbParameter>();"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildUpdateModelToDBCode(schema)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, paramList.ToArray());"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "return res > 0 ; "));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "}"));
            return sbl.ToString();
        }
        private string BuildUpdateSqlCode(DataTable schema, string tableName)
        {
            List<DataRow> commonRows = schema.AsEnumerable().Where(r => !(bool)r["IsKey"]).ToList();
            List<DataRow> pkRows = schema.AsEnumerable().Where(r => (bool)r["IsKey"]).ToList();
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine();
            sbl.AppendFormat("UPDATE [{0}]", tableName);
            sbl.AppendLine();
            sbl.AppendLine("SET ");
            foreach (DataRow colRow in commonRows)
            {
                if (String.Compare(colRow["ColumnName"].ToString(), "timestamp", true) != 0)
                    sbl.AppendFormat("[{0}] = @{0}, ", colRow["ColumnName"]);
            }
            if (schema.Rows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 2, 2);

            sbl.AppendLine();
            sbl.Append("WHERE ");
            foreach (DataRow row in pkRows)
            {
                if (String.Compare(row["ColumnName"].ToString(), "timestamp", true) != 0)
                    sbl.AppendFormat(@"[{0}] = @{0} AND ", row["ColumnName"]);
            }
            if (pkRows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 4, 4);
            else
                sbl.Append("1<>1");

            return sbl.ToString();
        }
        private string BuildUpdateModelToDBCode(DataTable schema)
        {
            StringBuilder sbl = new StringBuilder(256);

            foreach (DataRow row in schema.Rows)
            {
                if (String.Compare(row["ColumnName"].ToString(), "timestamp", true) != 0)
                {
                    string propertyName = CodeBuilderAssistant.GetPropertyName(row["ColumnName"].ToString());
                    string dbTypeName = row["DataTypeName"].ToString();
                    string convertActionCode = CodeBuilderAssistant.GetColumnConvertToDBCode(dbTypeName, propertyName);
                    string sqlDbType = CodeBuilderAssistant.GetColumnSqlDbType(dbTypeName);
                    sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"paramList.Add(new DbParameter(""@{0}"", {1}) {{ SqlDbType = SqlDbType.{2} }});", row["ColumnName"], convertActionCode, sqlDbType));
                }
            }
            return sbl.ToString();
        }

        private string BuildInsertMethod(DataTable schema, string modelName, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public static bool Insert{0}({0} model)", modelName));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"string strSql = @""{0}"";", BuildInsertSqlCode(schema, tableName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"List<DbParameter> paramList = new List<DbParameter>();"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildModelToDBCode(schema)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, paramList.ToArray());"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "return res > 0 ; "));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "}"));
            return sbl.ToString();
        }
        private string BuildInsertSqlCode(DataTable schema, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine();

            sbl.AppendFormat("INSERT INTO [{0}] (", tableName);
            foreach (DataRow row in schema.Rows)
            {
                if (!(bool)row["IsIdentity"] && String.Compare(row["ColumnName"].ToString(), "timestamp", true) != 0)
                    sbl.AppendFormat("[{0}], ", row["ColumnName"]);
            }
            if (schema.Rows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 2, 2);
            sbl.AppendLine(")");

            sbl.Append("VALUES (");
            foreach (DataRow row in schema.Rows)
            {
                if (!(bool)row["IsIdentity"] && String.Compare(row["ColumnName"].ToString(), "timestamp", true) != 0)
                    sbl.AppendFormat("@{0}, ", row["ColumnName"]);
            }
            if (schema.Rows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 2, 2);
            sbl.Append(")");
            return sbl.ToString();
        }
        private string BuildModelToDBCode(DataTable schema)
        {
            StringBuilder sbl = new StringBuilder(256);

            foreach (DataRow row in schema.Rows)
            {
                if (!(bool)row["IsIdentity"] && String.Compare(row["ColumnName"].ToString(), "timestamp", true) != 0)
                {
                    string propertyName = CodeBuilderAssistant.GetPropertyName(row["ColumnName"].ToString());
                    string dbTypeName = row["DataTypeName"].ToString();
                    string convertActionCode = CodeBuilderAssistant.GetColumnConvertToDBCode(dbTypeName, propertyName);
                    string sqlDbType = CodeBuilderAssistant.GetColumnSqlDbType(dbTypeName);
                    sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"paramList.Add(new DbParameter(""@{0}"", {1}) {{ SqlDbType = SqlDbType.{2} }});", row["ColumnName"], convertActionCode, sqlDbType));
                }
            }
            return sbl.ToString();
        }

        private string BuildDeleteByPrimaryKeyMethod(DataTable schema, string modelName, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public static bool Delete({0})", BuildPrimaryKeyParamsCode(schema)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "{"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"string strSql = @""{0}"";", BuildDeleteByPrimaryKeySqlCode(schema, tableName)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, @"List<DbParameter> paramList = new List<DbParameter>();"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, BuildPrimaryKeyModelToDBCode(schema)));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "int res = DBAccesser.DbInstance.ExecuteNonQuery(strSql, paramList.ToArray());"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(3, "return res > 0 ; "));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "}"));
            return sbl.ToString();
        }
        private string BuildDeleteByPrimaryKeySqlCode(DataTable schema, string tableName)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendFormat("DELETE FROM [{0}] WHERE ", tableName);
            List<DataRow> pkRows = schema.AsEnumerable().Where(r => (bool)r["IsKey"]).ToList();
            foreach (DataRow row in pkRows)
            {
                string columnName = row["ColumnName"].ToString();
                sbl.AppendFormat(@"[{0}] = @{0} AND ", columnName);
            }
            if (pkRows.Count > 0)
                sbl = sbl.Remove(sbl.Length - 4, 4);
            else
                sbl.Append("1<>1");

            return sbl.ToString();
        }
        protected override string GetFilePath(string tableName)
        {
            string directory = CodeBuilderAssistant.GetDALPath(tableName);
            string dalName = CodeBuilderAssistant.GetDALName(tableName);
            return Path.Combine(directory, String.Concat(dalName, ".cs"));
        }
    }
}
