namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// 通用HtmlContent辅助类
    /// </summary>
    public static class CommonEnumHelper
    {
        #region Field
        private static Dictionary<Type, Dictionary<int, string>> enumDisplayItemDict = new Dictionary<Type, Dictionary<int, string>>();
        private static Dictionary<Type, Dictionary<string, int>> enumValueItemDict = new Dictionary<Type, Dictionary<string, int>>();
        #endregion
        #region Property
        #endregion
        #region Constructor
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 获取枚举对象Key与显示名称的字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumDisplayItems(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("给定的类型不是枚举类型");

            Dictionary<int, string> displayItems = enumDisplayItemDict.ContainsKey(enumType) ? enumDisplayItemDict[enumType] : new Dictionary<int, string>();

            if (displayItems.Count == 0)
            {
                displayItems = TryToGetEnumDisplayItems(enumType);
                enumDisplayItemDict[enumType] = displayItems;
            }
            return displayItems;
        }
        private static Dictionary<int, string> TryToGetEnumDisplayItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<int, string> displayItems = new Dictionary<int, string>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);

                object[] cAttr = enumItem.GetCustomAttributes(typeof(EnumDisplayAttribute), true);
                if (cAttr.Length > 0)
                {
                    EnumDisplayAttribute desc = cAttr[0] as EnumDisplayAttribute;
                    if (desc != null)
                        displayItems[intValue] = desc.DisplayName;
                    else
                        displayItems[intValue] = enumItem.Name;
                }
            }
            return displayItems;
        }

        public static List<Tuple<int, string>> GetSeqEnumDisplayItems(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("给定的类型不是枚举类型");

            return TryToGetSeqEnumDisplayItems(enumType);
        }
        private static List<Tuple<int, string>> TryToGetSeqEnumDisplayItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            List<Tuple<int, string, int>> displayItems = new List<Tuple<int, string, int>>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);

                object[] cAttr = enumItem.GetCustomAttributes(typeof(EnumDisplayAttribute), true);
                if (cAttr.Length > 0)
                {
                    EnumDisplayAttribute desc = cAttr[0] as EnumDisplayAttribute;
                    if (desc != null)
                        displayItems.Add(new Tuple<int, string, int>(intValue, desc.DisplayName, desc.Seq));
                    else
                        displayItems.Add(new Tuple<int, string, int>(intValue, enumItem.Name, intValue));
                }
            }
            return displayItems.OrderBy(o => o.Item3).Select(o => new Tuple<int, string>(o.Item1, o.Item2)).ToList();
        }

        public static string TryToGetEnumDisplay(Type enumType, int enumValue)
        {
            Dictionary<int, string> enumDict = GetEnumDisplayItems(enumType);
            return enumDict.ContainsKey(enumValue) ? enumDict[enumValue] : enumValue.ToString();
        }
        public static string TryToGetEnumDisplay(Type enumType, int enumValue, string defValue)
        {
            Dictionary<int, string> enumDict = GetEnumDisplayItems(enumType);
            return enumDict.ContainsKey(enumValue) ? enumDict[enumValue] : enumDict.Select(d => d.Value).FirstOrDefault();
        }
        /// <summary>
        /// 获取枚举对象显示名称与Key的字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private static Dictionary<string, int> GetEnumValueItems(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("给定的类型不是枚举类型");

            Dictionary<string, int> valueItems = enumValueItemDict.ContainsKey(enumType) ? enumValueItemDict[enumType] : new Dictionary<string, int>();

            if (valueItems.Count == 0)
            {
                valueItems = TryToGetEnumValueItems(enumType);
                enumValueItemDict[enumType] = valueItems;
            }
            return valueItems;
        }
        private static Dictionary<string, int> TryToGetEnumValueItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<string, int> displayItems = new Dictionary<string, int>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);

                object[] cAttr = enumItem.GetCustomAttributes(typeof(EnumDisplayAttribute), true);
                if (cAttr.Length > 0)
                {
                    EnumDisplayAttribute desc = cAttr[0] as EnumDisplayAttribute;
                    if (desc != null)
                        displayItems[desc.DisplayName] = intValue;
                    else
                        displayItems[enumItem.Name] = intValue;
                }
            }
            return displayItems;
        }
        public static int TryToGetEnumValue(Type enumType, string displayText)
        {
            Dictionary<string, int> enumDict = GetEnumValueItems(enumType);
            return enumDict.ContainsKey(displayText) ? enumDict[displayText] : enumDict.Select(d => d.Value).FirstOrDefault();
        }
        public static int TryToGetEnumValue(Type enumType, string displayText, int defValue)
        {
            Dictionary<string, int> enumDict = GetEnumValueItems(enumType);
            return enumDict.ContainsKey(displayText) ? enumDict[displayText] : defValue;
        }
        #endregion
    }
}
