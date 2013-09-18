using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.CodeGeneratorLibrary
{
    public class TableDescription
    {
        private Dictionary<string, ColumnDescription> columnDescDict;

        internal Dictionary<string, ColumnDescription> ColumnDescDict
        {
            get { return columnDescDict = columnDescDict ?? new Dictionary<string, ColumnDescription>(); }
        }

        internal string FindColumnDescription(string columnName)
        {
            return ColumnDescDict.ContainsKey(columnName) ? ColumnDescDict[columnName].columnDesc : String.Empty;
        }
        internal void AddColumnDescription(string columnName, string columnDesc)
        {
            if (!ColumnDescDict.ContainsKey(columnName))
                ColumnDescDict[columnName] = new ColumnDescription() { columnName = columnName };
            ColumnDescDict[columnName].columnDesc = columnDesc;
        }
    }
}
