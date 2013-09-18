namespace Crow.Little.CodeGeneratorLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Linq;
    using Crow.Little.DBHelper;
    using Crow.Little.Common;

    /// <summary>
    /// 代码生成器
    /// </summary>
    public abstract class CodeBuilder
    {
        #region Field
        #endregion
        #region Property
        #endregion
        #region Delegate
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        public static void InitSetting(CodeGenerateSetting setting)
        {
            CodeBuilderAssistant.InitGeneratorByConfig(setting);
        }
        /// <summary>
        /// 按配置生成代码
        /// </summary>
        /// <param name="tableNameList">待生成的表名</param>
        /// <param name="dbDesc">数据库中各表的列描述</param>
        /// <param name="setting">各层的代码生成配置字典</param>
        public static void GenerateCodeFiles(List<string> tableNameList, DBDescription dbDesc, CodeGenerateSetting setting)
        {
            List<string> generatedModels = new List<string>();
            List<string> generatedDals = new List<string>();

            foreach (string tableName in tableNameList)
            {
                TableDescription tableDesc = dbDesc.FindTableDescription(tableName);
                DataTable schema = DBOperator.LoadSchemaForTable(tableName);

                string nameSpace = CodeBuilderAssistant.GetModelNameSpace();
                string className = CodeBuilderAssistant.GetModelName(tableName);
                List<string> classAttrs = CodeBuilderAssistant.GetModelAttribute();
                CodeBuilder codeBuilder = new ModelCodeBuilder();
                codeBuilder.GenerateCodeFile(tableName, schema, tableDesc, nameSpace, classAttrs, className, generatedModels);

                nameSpace = CodeBuilderAssistant.GetDALNameSpace();
                className = CodeBuilderAssistant.GetDALName(tableName);
                classAttrs = CodeBuilderAssistant.GetDALAttribute();
                codeBuilder = new DALCodeBuilder();
                codeBuilder.GenerateCodeFile(tableName, schema, tableDesc, nameSpace, classAttrs, className, generatedDals);

                schema.Clear();
            }
        }
        public static List<Tuple<string, string, string>> GetExistedCodeFileList(List<string> tableNameList, CodeGenerateSetting setting)
        {
            List<Tuple<string, string, string>> existedTableNameList = new List<Tuple<string, string, string>>();

            string modelPath = String.Empty, dalPath = String.Empty;
            foreach (string tableName in tableNameList)
            {
                CodeBuilder modelBuilder = new ModelCodeBuilder();
                modelPath = modelBuilder.GetFilePath(tableName);

                CodeBuilder dalBuilder = new ModelCodeBuilder();
                dalPath = dalBuilder.GetFilePath(tableName);

                if (File.Exists(modelPath) || File.Exists(dalPath))
                    existedTableNameList.Add(new Tuple<string, string, string>(tableName, modelPath, dalPath));
            }
            return existedTableNameList;
        }

        public static List<Tuple<int, string>> GetProviders()
        {
            return Common.CommonEnumHelper.GetSeqEnumDisplayItems(typeof(DbProvider));
        }

        private void GenerateCodeFile(string tableName, DataTable schema, TableDescription tableDesc, string nameSpace, List<string> classAttrs, string className, List<string> geneatedFiles)
        {
            StringBuilder sbl = new StringBuilder(256);

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(0, "namespace {0}", nameSpace));
            sbl.AppendLine("{");
            sbl.AppendLine(GenerateUsingCodes(tableName, schema, tableDesc));

            foreach (string classAttr in classAttrs)
            {
                sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, classAttr));
            }

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "public partial class {0}", className));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "{"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#region Field"));
            sbl.Append(GenerateFieldCodes(tableName, schema, tableDesc));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#endregion"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#region Property"));
            sbl.Append(GeneratePropertyCodes(tableName, schema, tableDesc));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#endregion"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#region Constructor"));
            sbl.Append(GenerateConstructorCodes(tableName, schema, tableDesc));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#endregion"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#region Event"));
            sbl.Append(GenerateEventCodes(tableName, schema, tableDesc));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#endregion"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#region Method"));
            sbl.Append(GenerateMethodCodes(tableName, schema, tableDesc));
            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(2, "#endregion"));

            sbl.AppendLine(CodeBuilderAssistant.BuildCodeLine(1, "}"));
            sbl.AppendLine("}");

            string filePath = GetFilePath(tableName);
            geneatedFiles.Add(filePath);
            CodeBuilderAssistant.GenerateContentToFile(sbl.ToString(), filePath);
        }
        protected virtual string GenerateUsingCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            return String.Empty;
        }
        protected virtual string GenerateFieldCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            return String.Empty;
        }
        protected virtual string GeneratePropertyCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            return String.Empty;
        }
        protected virtual string GenerateConstructorCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            return String.Empty;
        }
        protected virtual string GenerateEventCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            return String.Empty;
        }
        protected virtual string GenerateMethodCodes(string tableName, DataTable schema, TableDescription tableDesc)
        {
            return String.Empty;
        }
        protected abstract string GetFilePath(string tableName);
        #endregion
    }
}
