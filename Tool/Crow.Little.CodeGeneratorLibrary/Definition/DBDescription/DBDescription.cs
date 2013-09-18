using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.CodeGeneratorLibrary
{
    public class DBDescription
    {
        private Dictionary<string, TableDescription> tableDestDict;

        internal Dictionary<string, TableDescription> TableDestDict
        {
            get { return tableDestDict = tableDestDict ?? new Dictionary<string, TableDescription>(); }
        }
        internal TableDescription FindTableDescription(string tableName)
        {
            return TableDestDict.ContainsKey(tableName) ? TableDestDict[tableName] : new TableDescription();
        }
        internal TableDescription GetOrCreateTableDescription(string tableName)
        {
            if (!TableDestDict.ContainsKey(tableName))
                TableDestDict[tableName] = new TableDescription();
            return TableDestDict[tableName];
        }
    }
}
