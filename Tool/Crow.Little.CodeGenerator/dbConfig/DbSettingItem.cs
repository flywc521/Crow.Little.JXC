using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.CodeGenerator.dbConfig
{
    public class DbSettingItem
    {
        public string Provider { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string UID { get; set; }
        public string PWD { get; set; }
    }
}
