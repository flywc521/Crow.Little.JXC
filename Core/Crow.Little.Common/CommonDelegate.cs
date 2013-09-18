using System;
using System.Collections.Generic;
using System.Text;

namespace Crow.Little.Common
{
    public delegate object Act();
    public delegate object Func(object obj);
    public delegate object ActInParams(params object[] obj);

    public delegate void ActWithNoReturn();
    public delegate void FuncWithNoReturn(object obj);
    public delegate void ActInParamsButNoReturn(params object[] obj);
}
