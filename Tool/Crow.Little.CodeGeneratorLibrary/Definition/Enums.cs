using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.CodeGeneratorLibrary
{

    /// <summary>
    /// 生成的代码类型
    /// </summary>
    public enum CodeType
    {
        /// <summary>
        /// 实体层
        /// </summary>
        Model = 0,
        /// <summary>
        /// 数据访问层
        /// </summary>
        DAL = 1,
        /// <summary>
        /// 业务逻辑层
        /// </summary>
        BLL = 2
    }
}
