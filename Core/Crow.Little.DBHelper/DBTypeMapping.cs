using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Crow.Little.DBHelper
{
    public struct DBTypeMapping
    {
        public string DBType;
        public string SystemType;
        public string DefaultValue;
        public string ConvertFromDB;
        public string ConvertToDB;
        public DbType DbType;
    }
}
