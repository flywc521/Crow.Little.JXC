namespace Crow.Little.CodeGeneratorLibrary
{
    using System;
    using System.Data;
    using System.IO;
    using System.Text;

    internal class ModelCodeBuilder : CodeBuilder
    {
        protected override string GenerateUsingCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            StringBuilder sbl = new StringBuilder(256);
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Collections.Generic;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Drawing;"));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "using System.Xml;"));
            return sbl.ToString();
        }
        protected override string GeneratePropertyCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            StringBuilder sbl = new StringBuilder(256);
            foreach (DataRow row in schema.Rows)
            {
                string dbTypeName = row["DataTypeName"].ToString();
                string propertyName = CodeBuilderAssistant.GetPropertyName(row["ColumnName"].ToString());
                string columnDesc = tableDesc.FindColumnDescription(propertyName);
                columnDesc = columnDesc.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
                columnDesc = columnDesc.Replace("   ", " ").Replace("  ", " ");
                if (!String.IsNullOrEmpty(columnDesc))
                {
                    sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "/// <summary>"));
                    sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "/// {0}", columnDesc));
                    sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "/// </summary>"));
                }
                sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "public {0} {1} {{get;set;}}", CodeBuilderAssistant.GetColumnType(dbTypeName), propertyName));
            }
            return sbl.ToString();
        }
        protected override string GetFilePath(string tableName)
        {
            string directory = CodeBuilderAssistant.GetModelPath(tableName);
            string modelName = CodeBuilderAssistant.GetModelName(tableName);
            return Path.Combine(directory, String.Concat(modelName, ".cs"));
        }
    }
}
