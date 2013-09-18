namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 树节点接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreeNode<T>
    {
        #region Field
        #endregion

        #region Property
        /// <summary>
        /// 父节点
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        /// 是否叶子节点
        /// </summary>
        bool IsLeaf { get; }

        /// <summary>
        /// 是否根节点
        /// </summary>
        bool IsRoot { get; }
        #endregion

        #region Constructor
        #endregion

        #region Event
        #endregion

        #region Method
        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        T GetRootNode();
        #endregion
    }
}
