using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Crow.Little.CodeGeneratorLibrary
{
    internal static class CodeBuilderAssistant
    {
        #region Field
        private static Dictionary<string, string> keyWordDict = new Dictionary<string, string>();
        private static Dictionary<string, DBTypeMapping> dbTypeMappingDict = new Dictionary<string, DBTypeMapping>();
        private static CodeGenerateSetting setting = new CodeGenerateSetting();
        #endregion
        #region Property
        #endregion
        #region Constructor
        static CodeBuilderAssistant()
        {
            BuildDbTypeMappingDict();
            BuildKeyWordDict();
        }
        #endregion
        #region Event
        #endregion
        #region Method
        #region 构建SqlServer数据库类型与系统类型的映射关系
        /// <summary>
        /// 在静态构造函数中构建各种DB数据类型对应的系统类型及转换方法的字典
        /// </summary>
        private static void BuildDbTypeMappingDict()
        {
            BuildBoolDbTypeMappingDict();
            BuildIntDbTypeMappingDict();
            BuildDateTimeDbTypeMappingDict();
            BuildDecimalDbTypeMappingDict();
            BuildStringDbTypeMappingDict();
            BuildByteArrayDbTypeMappingDict();
            BuildOtherDbTypeMappingDict();
        }
        #region 布尔
        private static void BuildBoolDbTypeMappingDict()
        {
            //布尔
            dbTypeMappingDict["bit"] = new DBTypeMapping()
            {
                DBType = "bit",
                SystemType = "bool",
                DefaultValue = "false",
                ConvertFromDB = "reader.GetBoolean({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Bit,
            };
        }
        #endregion
        #region 整数
        private static void BuildIntDbTypeMappingDict()
        {
            //整数
            dbTypeMappingDict["tinyint"] = new DBTypeMapping()
            {
                DBType = "tinyint",
                SystemType = "byte",
                DefaultValue = "(byte)0",
                ConvertFromDB = "reader.GetByte({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.TinyInt,
            };
            dbTypeMappingDict["smallint"] = new DBTypeMapping()
            {
                DBType = "smallint",
                SystemType = "short",
                DefaultValue = "(short)0",
                ConvertFromDB = "reader.GetInt16({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.SmallInt,
            };
            dbTypeMappingDict["int"] = new DBTypeMapping()
            {
                DBType = "int",
                SystemType = "int",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetInt32({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Int,
            };
            dbTypeMappingDict["bigint"] = new DBTypeMapping()
            {
                DBType = "bigint",
                SystemType = "long",
                DefaultValue = "(long)0",
                ConvertFromDB = "reader.GetInt64({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.BigInt,
            };
        }
        #endregion
        #region 日期
        private static void BuildDateTimeDbTypeMappingDict()
        {
            //日期时间
            dbTypeMappingDict["date"] = new DBTypeMapping()
            {
                DBType = "date",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Date,
            };
            dbTypeMappingDict["datetime"] = new DBTypeMapping()
            {
                DBType = "datetime",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.DateTime,
            };
            dbTypeMappingDict["datetime2"] = new DBTypeMapping()
            {
                DBType = "datetime2",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.DateTime2,
            };
            dbTypeMappingDict["smalldatetime"] = new DBTypeMapping()
            {
                DBType = "smalldatetime",
                SystemType = "DateTime",
                DefaultValue = "DateTime.MinValue",
                ConvertFromDB = "reader.GetDateTime({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.SmallDateTime,
            };
            dbTypeMappingDict["datetimeoffset"] = new DBTypeMapping()
            {
                DBType = "datetimeoffset",
                SystemType = "DateTimeOffset",
                DefaultValue = "DateTimeOffset.MinValue",
                ConvertFromDB = "reader.GetDateTimeOffset({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.DateTimeOffset,
            };
            dbTypeMappingDict["time"] = new DBTypeMapping()
            {
                DBType = "time",
                SystemType = "TimeSpan",
                DefaultValue = "TimeSpan.MinValue",
                ConvertFromDB = "reader.GetTimeSpan({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Time,
            };
        }
        #endregion
        #region 小数
        private static void BuildDecimalDbTypeMappingDict()
        {
            //小数
            dbTypeMappingDict["real"] = new DBTypeMapping()
            {
                DBType = "real",
                SystemType = "float",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetFloat({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Real,
            };
            dbTypeMappingDict["float"] = new DBTypeMapping()
            {
                DBType = "float",
                SystemType = "double",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDouble({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Float,
            };
            dbTypeMappingDict["decimal"] = new DBTypeMapping()
            {
                DBType = "decimal",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Decimal,
            };
            dbTypeMappingDict["money"] = new DBTypeMapping()
            {
                DBType = "money",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Money,
            };
            dbTypeMappingDict["smallmoney"] = new DBTypeMapping()
            {
                DBType = "smallmoney",
                SystemType = "decimal",
                DefaultValue = "0",
                ConvertFromDB = "reader.GetDecimal({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.SmallMoney,
            };
        }
        #endregion
        #region 字符串
        private static void BuildStringDbTypeMappingDict()
        {
            //字符串
            dbTypeMappingDict["char"] = new DBTypeMapping()
            {
                DBType = "char",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Char,
            };
            dbTypeMappingDict["nchar"] = new DBTypeMapping()
            {
                DBType = "nchar",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.NChar,
            };
            dbTypeMappingDict["ntext"] = new DBTypeMapping()
            {
                DBType = "ntext",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.NText,
            };
            dbTypeMappingDict["nvarchar"] = new DBTypeMapping()
            {
                DBType = "nvarchar",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };
            dbTypeMappingDict["text"] = new DBTypeMapping()
            {
                DBType = "text",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Text,
            };
            dbTypeMappingDict["varchar"] = new DBTypeMapping()
            {
                DBType = "varchar",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetString({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
        }
        #endregion
        #region Byte数组
        private static void BuildByteArrayDbTypeMappingDict()
        {
            //二进制数组
            dbTypeMappingDict["binary"] = new DBTypeMapping()
            {
                DBType = "binary",
                SystemType = "byte[]",
                DefaultValue = "null",
                ConvertFromDB = "(byte[])reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Binary,
            };
            dbTypeMappingDict["timestamp"] = new DBTypeMapping()
            {
                DBType = "timestamp",
                SystemType = "byte[]",
                DefaultValue = "null",
                ConvertFromDB = "(byte[])reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Timestamp,
            };
            dbTypeMappingDict["varbinary"] = new DBTypeMapping()
            {
                DBType = "varbinary",
                SystemType = "byte[]",
                DefaultValue = "null",
                ConvertFromDB = "(byte[])reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.VarBinary,
            };
            dbTypeMappingDict["image"] = new DBTypeMapping()
            {
                DBType = "image",
                SystemType = "string",
                DefaultValue = "null",
                ConvertFromDB = "Convert.ToBase64String((byte[])reader.GetValue({0}))",
                ConvertToDB = "(model.{0} == null ? null : Convert.FromBase64String(model.{0}))",
                SqlDbType = System.Data.SqlDbType.Image,
            };
        }
        #endregion
        #region 其它
        private static void BuildOtherDbTypeMappingDict()
        {
            //Xml
            dbTypeMappingDict["xml"] = new DBTypeMapping()
            {
                DBType = "xml",
                SystemType = "XmlDocument",
                DefaultValue = "new XmlDocument()",
                ConvertFromDB = "DataAccesser.ConvertToXmlDocument(reader.GetString({0}))",
                ConvertToDB = "DataAccesser.ConvertFromXmlDocument(model.{0})",
                SqlDbType = System.Data.SqlDbType.Xml,
            };
            //Guid
            dbTypeMappingDict["uniqueidentifier"] = new DBTypeMapping()
            {
                DBType = "uniqueidentifier",
                SystemType = "string",
                DefaultValue = "String.Empty",
                ConvertFromDB = "reader.GetGuid({0}).ToString()",
                ConvertToDB = "CommonConvertor.TryToConverToGuid(model.{0})",
                SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
            };
            //object(包括sql_variant等在内的未涉及类型)
            dbTypeMappingDict["object"] = new DBTypeMapping()
            {
                DBType = "object",
                SystemType = "object",
                DefaultValue = "null",
                ConvertFromDB = "reader.GetValue({0})",
                ConvertToDB = "model.{0}",
                SqlDbType = System.Data.SqlDbType.Variant,
            };
        }
        #endregion
        #endregion
        #region 构建C#系统关键字映射
        private static void BuildKeyWordDict()
        {
            keyWordDict["abstract"] = "";
            keyWordDict["event"] = "";
            keyWordDict["new"] = "";
            keyWordDict["struct"] = "";
            keyWordDict["as"] = "";
            keyWordDict["explicit"] = "";
            keyWordDict["null"] = "";
            keyWordDict["switch"] = "";
            keyWordDict["base"] = "";
            keyWordDict["extern"] = "";
            keyWordDict["object"] = "";
            keyWordDict["this"] = "";
            keyWordDict["bool"] = "";
            keyWordDict["false"] = "";
            keyWordDict["operator"] = "";
            keyWordDict["throw"] = "";
            keyWordDict["break"] = "";
            keyWordDict["finally"] = "";
            keyWordDict["out"] = "";
            keyWordDict["true"] = "";
            keyWordDict["byte"] = "";
            keyWordDict["fixed"] = "";
            keyWordDict["override"] = "";
            keyWordDict["try"] = "";
            keyWordDict["case"] = "";
            keyWordDict["float"] = "";
            keyWordDict["params"] = "";
            keyWordDict["typeof"] = "";
            keyWordDict["catch"] = "";
            keyWordDict["for"] = "";
            keyWordDict["private"] = "";
            keyWordDict["uint"] = "";
            keyWordDict["char"] = "";
            keyWordDict["foreach"] = "";
            keyWordDict["protected"] = "";
            keyWordDict["ulong"] = "";
            keyWordDict["checked"] = "";
            keyWordDict["goto"] = "";
            keyWordDict["public"] = "";
            keyWordDict["unchecked"] = "";
            keyWordDict["class"] = "";
            keyWordDict["if"] = "";
            keyWordDict["readonly"] = "";
            keyWordDict["unsafe"] = "";
            keyWordDict["const"] = "";
            keyWordDict["implicit"] = "";
            keyWordDict["ref"] = "";
            keyWordDict["ushort"] = "";
            keyWordDict["continue"] = "";
            keyWordDict["in"] = "";
            keyWordDict["return"] = "";
            keyWordDict["using"] = "";
            keyWordDict["decimal"] = "";
            keyWordDict["int"] = "";
            keyWordDict["sbyte"] = "";
            keyWordDict["virtual"] = "";
            keyWordDict["default"] = "";
            keyWordDict["interface"] = "";
            keyWordDict["sealed"] = "";
            keyWordDict["volatile"] = "";
            keyWordDict["delegate"] = "";
            keyWordDict["internal"] = "";
            keyWordDict["short"] = "";
            keyWordDict["void"] = "";
            keyWordDict["do"] = "";
            keyWordDict["is"] = "";
            keyWordDict["sizeof"] = "";
            keyWordDict["while"] = "";
            keyWordDict["double"] = "";
            keyWordDict["lock"] = "";
            keyWordDict["stackalloc"] = "";
            keyWordDict["else"] = "";
            keyWordDict["long"] = "";
            keyWordDict["static"] = "";
            keyWordDict["enum"] = "";
            keyWordDict["namespace"] = "";
            keyWordDict["string"] = "";
            keyWordDict["get"] = "";
            keyWordDict["partial"] = "";
            keyWordDict["set"] = "";
            keyWordDict["value"] = "";
            keyWordDict["where"] = "";
            keyWordDict["yield"] = "";
        }
        #endregion
        /// <summary>
        /// 依剧配置信息初始化生成器
        /// </summary>
        /// <param name="generateConfigDict"></param>
        internal static void InitGeneratorByConfig(CodeGenerateSetting generateSetting)
        {
            setting = generateSetting;
            //判断路径各级是否存在,不存在的话,递归创建
            if (setting != null && setting.Solution != null)
            {
                if (setting.Solution.Model != null && !String.IsNullOrEmpty(setting.Solution.Model.Path))
                    RecursionCreateFolders(setting.Solution.Model.Path.Split('\\'), 1);
                if (setting.Solution.DAL != null && !String.IsNullOrEmpty(setting.Solution.DAL.Path))
                    RecursionCreateFolders(setting.Solution.DAL.Path.Split('\\'), 1);
            }
        }
        private static void RecursionCreateFolders(string[] path, int level)
        {
            string directoryPath = String.Empty;
            if (level <= path.Length)
            {
                for (int i = 0; i < level; i++)
                {
                    if (!path[i].Contains("."))
                        directoryPath = String.IsNullOrEmpty(directoryPath) ? path[i] : String.Concat(directoryPath, "\\", path[i]);
                }
            }

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            level++;
            if (level <= path.Length)
                RecursionCreateFolders(path, level);
        }
        /// <summary>
        /// 根据DB类型,生成对应的系统数据类型
        /// </summary>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        internal static string GetColumnType(string dataTypeName)
        {
            DBTypeMapping mapping = GetColumnDataTypeMapping(dataTypeName);
            return mapping.SystemType;
        }
        internal static string GetColumnDefaultValue(string dataTypeName)
        {
            DBTypeMapping mapping = GetColumnDataTypeMapping(dataTypeName);
            return mapping.DefaultValue;
        }
        internal static string GetColumnSqlDbType(string dataTypeName)
        {
            DBTypeMapping mapping = GetColumnDataTypeMapping(dataTypeName);
            return mapping.SqlDbType.ToString();
        }
        internal static string GetColumnConvertFromDBCode(string dataTypeName, int idx)
        {
            DBTypeMapping mapping = GetColumnDataTypeMapping(dataTypeName);
            return String.Format(mapping.ConvertFromDB, idx);
        }
        internal static string GetColumnConvertToDBCode(string dataTypeName, string propertyName)
        {
            DBTypeMapping mapping = GetColumnDataTypeMapping(dataTypeName);
            return String.Format(mapping.ConvertToDB, propertyName);
        }
        internal static DBTypeMapping GetColumnDataTypeMapping(string dataTypeName)
        {
            DBTypeMapping mapping = new DBTypeMapping();
            if (dbTypeMappingDict.ContainsKey(dataTypeName))
                mapping = dbTypeMappingDict[dataTypeName];
            else
                mapping = dbTypeMappingDict["object"];
            return mapping;
        }
        /// <summary>
        /// 按数量生成Tab字串
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        internal static string BuildTabSpace(int count)
        {
            string tabSpace = String.Empty;
            for (int i = 0; i < count; i++)
                tabSpace = String.Concat(tabSpace, "\t");
            return tabSpace;
        }
        /// <summary>
        /// 生成代码行文本
        /// </summary>
        /// <param name="tabCount"></param>
        /// <param name="content"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static string BuildCodeLine(int tabCount, string content, params object[] args)
        {
            return BuildCodeLine(tabCount, content, false, args);
        }
        /// <summary>
        /// 生成代码行文本
        /// </summary>
        /// <param name="tabCount"></param>
        /// <param name="content"></param>
        /// <param name="lineEndSymbol"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static string BuildCodeLine(int tabCount, string content, bool lineEndSymbol, params object[] args)
        {
            string codeLine = String.Concat(BuildTabSpace(tabCount), content, lineEndSymbol ? "\r\n" : String.Empty);
            if (codeLine.Contains(@"{") && codeLine.Contains(@"}") && args != null && args.Length > 0)
                codeLine = String.Format(codeLine, args);
            return codeLine;
        }
        internal static void GenerateContentToFile(string content, string filePath)
        {
            // dyt 2013-05-13
            // 添加目录验证，如果当前目录不存在，则系统生成当前目录
            FileInfo fi = new FileInfo(filePath);
            if (!Directory.Exists(fi.Directory.FullName))
            {
                Directory.CreateDirectory(fi.Directory.FullName);
            }
            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        internal static string GetModelName(string tableName)
        {
            string modelName = tableName;
            if (setting != null && setting.Solution != null && setting.Solution.Model != null)
            {
                modelName = String.Concat(setting.Solution.Model.ModelPrefix, tableName, setting.Solution.Model.ModelPostfix);
                if (keyWordDict.ContainsKey(modelName))
                {
                    switch (setting.Solution.Model.ModelCollision)
                    {
                        case MemberNameCollisionSolution.AddUnderLinePrefix: modelName = String.Concat("_", modelName); break;
                        case MemberNameCollisionSolution.ConvertFirstWordToUpper:
                        default: modelName = String.Concat(modelName.Substring(0, 1).ToUpper(), modelName.Substring(1)); break;
                    }
                }
            }
            return modelName;
        }
        internal static List<string> GetModelAttribute()
        {
            List<string> attrList = new List<string>();
            attrList.Add("[Serializable]");
            return attrList;
        }
        internal static string GetDALName(string tableName)
        {
            string dalName = String.Empty;
            if (setting != null && setting.Solution != null && setting.Solution.DAL != null)
            {
                dalName = String.Concat(setting.Solution.DAL.DALPrefix, tableName, setting.Solution.DAL.DALPostfix);
                if (keyWordDict.ContainsKey(dalName))
                {
                    switch (setting.Solution.DAL.DALCollision)
                    {
                        case MemberNameCollisionSolution.AddUnderLinePrefix: dalName = String.Concat("_", dalName); break;
                        case MemberNameCollisionSolution.ConvertFirstWordToUpper:
                        default: dalName = String.Concat(dalName.Substring(0, 1).ToUpper(), dalName.Substring(1)); break;
                    }
                }
            }
            return dalName;
        }
        internal static List<string> GetDALAttribute()
        {
            List<string> attrList = new List<string>();
            return attrList;
        }
        internal static string GetPropertyName(string columnName)
        {
            string propertyName = String.Empty;
            if (setting != null && setting.Solution != null && setting.Solution.Model != null)
            {
                propertyName = String.Concat(setting.Solution.Model.PropertyPrefix, columnName, setting.Solution.Model.PropertyPostfix);
                if (keyWordDict.ContainsKey(propertyName))
                {
                    switch (setting.Solution.Model.PropertyCollision)
                    {
                        case MemberNameCollisionSolution.AddUnderLinePrefix: propertyName = String.Concat("_", propertyName); break;
                        case MemberNameCollisionSolution.ConvertFirstWordToUpper:
                        default: propertyName = String.Concat(propertyName.Substring(0, 1).ToUpper(), propertyName.Substring(1)); break;
                    }
                }
            }
            return propertyName;
        }
        internal static string GetModelNameSpace()
        {
            string nameSpace = "Model";
            if (setting != null && setting.Solution != null && setting.Solution.Model != null)
                nameSpace = setting.Solution.Model.NameSpace;
            return String.IsNullOrEmpty(nameSpace) ? "Model" : nameSpace;
        }
        internal static string GetDALNameSpace()
        {
            string nameSpace = "DAL";
            if (setting != null && setting.Solution != null && setting.Solution.DAL != null)
                nameSpace = setting.Solution.DAL.NameSpace;
            return String.IsNullOrEmpty(nameSpace) ? "DAL" : nameSpace;
        }
        internal static string GetModelPath(string tableName)
        {
            string path = String.Empty;
            if (setting != null && setting.Solution != null && setting.Solution.Model != null)
            {
                // dyt 2013-05-13
                // 判断表明是否包含有下划线，如果表明包含有下划线，系统根据下划线之前的字符生成不同的目录
                string modelPath = setting.Solution.Model.Path;
                FileInfo fileInfo = new FileInfo(modelPath);
                string directoryName = fileInfo.Directory.FullName;
                if (tableName.IndexOf("_") > 0)
                {
                    directoryName = fileInfo.Directory + @"\" + tableName.Substring(0, tableName.IndexOf("_"));
                }
                //FileInfo fileInfo = new FileInfo(modelPath);
                path = directoryName;// fileInfo.Directory.FullName;
            }
            return path;
        }
        internal static string GetDALPath(string tableName)
        {
            string path = String.Empty;
            if (setting != null && setting.Solution != null && setting.Solution.DAL != null)
            {
                // dyt 2013-05-13
                // 判断表明是否包含有下划线，如果表明包含有下划线，系统根据下划线之前的字符生成不同的目录
                string dallPath = setting.Solution.DAL.Path;
                FileInfo fileInfo = new FileInfo(dallPath);
                string directoryName = fileInfo.Directory.FullName;
                if (tableName.IndexOf("_") > 0)
                {
                    directoryName = fileInfo.Directory + @"\" + tableName.Substring(0, tableName.IndexOf("_"));
                }
                path = directoryName;// fileInfo.Directory.FullName;
            }
            return path;
        }
        #endregion
    }
}
