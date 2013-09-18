namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 通用泛型事件参数实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonEventArgs<T> : EventArgs
    {
        #region Field
        private T args;
        #endregion

        #region Property
        public T Args
        {
            get
            {
                return args;
            }
        }
        #endregion

        #region Constructor
        public CommonEventArgs(T _args)
        {
            if (_args == null)
            {
                throw new ArgumentNullException("args is null");
            }
            this.args = _args;
        }
        #endregion

        #region Event
        #endregion

        #region Method
        public override string ToString()
        {
            return args.ToString();
        }
        #endregion
    }
}
