using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Crow.Little.CodeGeneratorLibrary
{
    internal struct DBTypeMapping
    {
        internal string DBType;
        internal string SystemType;
        internal string DefaultValue;
        internal string ConvertFromDB;
        internal string ConvertToDB;
        internal SqlDbType SqlDbType;
    }
}
