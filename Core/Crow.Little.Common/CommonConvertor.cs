namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 通用类型转换器
    /// </summary>
    public static class CommonConvertor
    {
        #region Field
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 转换为TSQL中的连续字符串，以供IN关键字使用
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static string ConvertToTsqlStringCondtion(List<string> itemList)
        {
            StringBuilder sbl = new StringBuilder();
            foreach (string item in itemList)
            {
                sbl.AppendFormat(",'{0}'", item);
            }
            sbl = sbl.Length > 0 ? sbl.Remove(0, 1) : sbl;
            sbl = sbl.Length > 0 ? sbl : sbl.Append("''");

            return sbl.ToString();
        }
        /// <summary>
        /// 转换为TSQL中的连续字符串，以供IN关键字使用
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static string ConvertToTsqlGuidCondtion(List<string> itemList)
        {
            StringBuilder sbl = new StringBuilder();
            foreach (string item in itemList)
            {
                sbl.AppendFormat(",'{0}'", item);
            }
            sbl = sbl.Length > 0 ? sbl.Remove(0, 1) : sbl;
            sbl = sbl.Length > 0 ? sbl : sbl.AppendFormat("'{0}'", Guid.Empty);

            return sbl.ToString();
        }
        /// <summary>
        /// 转换为TSQL中的连续字符串，以供IN关键字使用
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public static string ConvertToTsqlNumberCondtion(List<string> itemList)
        {
            StringBuilder sbl = new StringBuilder();
            foreach (string item in itemList)
            {
                sbl.AppendFormat(",{0}", item);
            }
            sbl = sbl.Length > 0 ? sbl.Remove(0, 1) : sbl;

            return sbl.ToString();
        }
        public static bool TryToConverToBoolean(string strValue, bool defaultValue = false)
        {
            bool returnValue = defaultValue;
            bool.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static byte TryToConverToByte(string strValue, byte defaultValue = 0)
        {
            byte returnValue = defaultValue;
            byte.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static short TryToConverToInt16(string strValue, short defaultValue = 0)
        {
            short returnValue = defaultValue;
            short.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static int TryToConverToInt32(string strValue, int defaultValue = 0)
        {
            int returnValue = defaultValue;
            int.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static long TryToConverToInt64(string strValue, long defaultValue = 0)
        {
            long returnValue = defaultValue;
            long.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static double TryToConverToDouble(string strValue, double defaultValue = 0)
        {
            double returnValue = defaultValue;
            double.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static decimal TryToConverToDecimal(string strValue, decimal defaultValue = 0)
        {
            decimal returnValue = defaultValue;
            decimal.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static DateTime TryToConverToDateTime(string strValue, long defaultDateBinary = 0)
        {
            DateTime returnValue = DateTime.FromBinary(defaultDateBinary);
            DateTime.TryParse(strValue, out returnValue);
            return returnValue;
        }
        public static Guid TryToConverToGuid(string strValue)
        {
            Guid returnValue = Guid.Empty;
            try
            {
                returnValue = new Guid(strValue);
            }
            finally
            {
            }
            return returnValue;
        }
        #endregion
    }
}
