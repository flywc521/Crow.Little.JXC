namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// 通用业务反射类
    /// </summary>
    public static class CommonReflect
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
        /// 获取正在被调用的程序集下的所有类别数组
        /// </summary>
        /// <returns>类别数组</returns>
        public static Type[] GetAllTypesForCallingAssembly()
        {
            Assembly assem = Assembly.GetCallingAssembly();
            return assem.GetTypes();
        }
        /// <summary>
        /// 通过类型获取类型所属的程序集
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Assembly GetAssemblyFromType(Type type)
        {
            return Assembly.GetAssembly(type);
        }
        /// <summary>
        /// 获取WEB程序集下的所有Controller类别数组
        /// </summary>
        /// <param name="type">需要提供WEB应用程序集下的某一类型，做的查找WEB应用程序集的入口参数</param>
        /// <returns>类别数组</returns>
        public static Type[] GetControllerTypesForAssembly(Assembly assem)
        {
            if (assem != null)
                return assem.GetTypes().Where(t => InheritsFrom(t, "System.Web.Mvc.Controller")).ToArray();

            return new Type[0];
        }
        /// <summary>
        /// 判断一个类是否继承自System.Web.Mvc.Controller"
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsInheritsFromController(Type t)
        {
            return InheritsFrom(t, "System.Web.Mvc.Controller");
        }
        /// <summary>
        /// 判断方法的返回值是否为ActionResult
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static bool IsMethodInfoIsActionResult(MethodInfo m)
        {
            return m.ReturnType.FullName == "System.Web.Mvc.ActionResult" || m.ReturnType.FullName == "System.Web.Mvc.ViewResult";
        }
        /// <summary>
        /// 根据类别创建对应的无参实例
        /// </summary>
        /// <param name="t">类别</param>
        /// <returns>类别的实例</returns>
        public static object CreateInstance(Type t)
        {
            Type[] paraTypeArray = new Type[0];
            object[] paraObjArray = new object[0];
            return CreateInstance(t, paraTypeArray, paraObjArray);
        }
        /// <summary>
        /// 根据类别创建对应的有参实例
        /// </summary>
        /// <param name="t">类别</param>
        /// <param name="paramTypes">构造函数中的参数类型列表</param>
        /// <param name="paramObjs">创建实例所需的参数列表</param>
        /// <returns>类别的实例</returns>
        public static object CreateInstance(Type t, Type[] paramTypes, object[] paramObjs)
        {
            ConstructorInfo cInfo = t.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, paramTypes, null);
            return cInfo.Invoke(paramObjs);
        }
        /// <summary>
        /// 判断类别是否为某一指定类别的继承类
        /// </summary>
        /// <param name="type">待判断类别</param>
        /// <param name="typeName">指定类别</param>
        /// <returns>是否为继承类</returns>
        public static bool InheritsFrom(Type type, string typeName)
        {
            for (Type current = type; current != typeof(object) && current.BaseType != null; current = current.BaseType)
                if (current.FullName == typeName)
                    return true;

            return false;
        }
        /// <summary>
        /// 尝试获取对象的属性值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="model"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static KeyValuePair<Type, object> TryToGetPropertyValue(Type t, object model, string propertyName)
        {
            KeyValuePair<Type, object> result = new KeyValuePair<Type, object>();
            try
            {
                PropertyInfo property = t.GetProperties().Where(p => p.Name == propertyName).FirstOrDefault();
                if (property != null)
                {
                    object obj = property.GetValue(model, null);
                    result = new KeyValuePair<Type, object>(property.PropertyType, obj);
                }
            }
            finally
            { }
            return result;
        }
        #endregion
    }
}
