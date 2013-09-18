namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 通用常量信息
    /// </summary>
    public static class CommonConst
    {
        #region Field
        private static DateTime minSmallDateTime = new DateTime(1900, 1, 1);
        private static DateTime maxSmallDateTime = new DateTime(2079, 6, 6);
        private static DateTime minDateTime = new DateTime(1753, 1, 1);
        private static DateTime maxDateTime = new DateTime(9999, 12, 31);
        #endregion
        #region Property
        /// <summary>
        /// 最小日期（DateTime.MinValue为公元年1月1日，匹配数据库对象时会出错）
        /// </summary>
        public static DateTime MinSmallDateTime
        {
            get { return CommonConst.minSmallDateTime; }
        }
        /// <summary>
        /// 最大日期（DateTime.MaxValue为9999年1月1日，匹配数据库对象时会出错）
        /// </summary>
        public static DateTime MaxSmallDateTime
        {
            get { return CommonConst.maxSmallDateTime; }
        }
        /// <summary>
        /// 最小日期（DateTime.MinValue为公元年1月1日，匹配数据库对象时会出错）
        /// </summary>
        public static DateTime MinDateTime
        {
            get { return CommonConst.minDateTime; }
        }
        /// <summary>
        /// 最大日期（DateTime.MaxValue为9999年1月1日，匹配数据库对象时会出错）
        /// </summary>
        public static DateTime MaxDateTime
        {
            get { return CommonConst.maxDateTime; }
        }
        #endregion
    }
}
