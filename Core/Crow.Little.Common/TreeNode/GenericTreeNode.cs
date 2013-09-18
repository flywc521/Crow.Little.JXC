namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// 泛型树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class GenericTreeNode<T> : ITreeNode<T> where T : class, ITreeNode<T>
    {
        #region Field
        private List<T> childNodes;
        #endregion

        #region Property


        /// <summary>
        /// 父节点
        /// </summary>
        [XmlIgnore]
        public T Parent
        {
            get;
            set;
        }

        /// <summary>
        /// 当前节点
        /// </summary>
        protected abstract T CurrentNode
        {
            get;
        }


        /// <summary>
        /// 子节点列表
        /// </summary>
        public List<T> ChildNodes
        {
            get { return childNodes; }
            set { childNodes = value; }
        }

        /// <summary>
        /// 当前节点为叶子
        /// </summary>
        public bool IsLeaf
        {
            get { return childNodes.Count == 0; }
        }

        /// <summary>
        /// 当前节点为根
        /// </summary>
        public bool IsRoot
        {
            get { return Parent == null; }
        }
        #endregion

        #region Constructor
        protected GenericTreeNode()
        {
            childNodes = new List<T>();
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取所有叶子节点
        /// </summary>
        /// <returns></returns>
        public List<T> GetLeafNodes()
        {
            return childNodes.Where(x => x.IsLeaf).ToList();
        }

        /// <summary>
        /// 获取所有非叶子节点
        /// </summary>
        /// <returns></returns>
        public List<T> GetNonLeafNodes()
        {
            return childNodes.Where(x => !x.IsLeaf).ToList();
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        public T GetRootNode()
        {
            if (Parent == null)
                return CurrentNode;

            return Parent.GetRootNode();
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(T child)
        {
            child.Parent = CurrentNode;
            childNodes.Add(child);
        }

        /// <summary>
        /// 批量添加子节点
        /// </summary>
        /// <param name="children"></param>
        public void AddChildren(IEnumerable<T> children)
        {
            foreach (T child in children)
                AddChild(child);
        }
        #endregion
    }
}
