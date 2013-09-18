namespace Crow.Little.Common
{
    using System;

    /// <summary>
    /// 枚举对象显示名称特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayAttribute : Attribute
    {
        private int itemSeq = -1;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq
        {
            get { return itemSeq; }
            set { itemSeq = value; }
        }

        public EnumDisplayAttribute(string displayName)
        {
            DisplayName = displayName;
        }
        public EnumDisplayAttribute(string displayName, int seq)
        {
            DisplayName = displayName;
            Seq = seq;
        }
    }
}
