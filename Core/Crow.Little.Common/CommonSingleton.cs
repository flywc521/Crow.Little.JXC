namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 通用泛型单例实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class CommonSingleton<T> where T : class
    {
        #region Field
        private static T instance;
        #endregion

        #region Property
        #endregion

        #region Constructor
        #endregion

        #region Event
        #endregion

        #region Method
        /// <summary>
        /// 反射无参构造函数,并构造该实例
        /// </summary>
        /// <returns></returns>
        public static T GetInstance()
        {
            if (instance == null)
            {
                Type type = typeof(T);
                instance = CommonReflect.CreateInstance(type) as T;
            }
            return instance;
        }

        /// <summary>
        /// 反射带参构造函数,并根据传入的参数构造该实例
        /// </summary>
        /// <param name="paramTypes"></param>
        /// <param name="paramObjs"></param>
        /// <returns></returns>
        public static T GetInstance(Type[] paramTypes, object[] paramObjs)
        {
            if (instance == null)
            {
                Type type = typeof(T);
                instance = CommonReflect.CreateInstance(type, paramTypes, paramObjs) as T;
            }
            return instance ;
        }
        #endregion
    }
}
