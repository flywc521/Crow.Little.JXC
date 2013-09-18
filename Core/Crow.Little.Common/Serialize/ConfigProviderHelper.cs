namespace Crow.Little.Common
{
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    internal static class ConfigProviderHelper
    {
        /// <summary>
        /// 把对象序列化并返回相应的字节
        /// </summary>
        /// <param name="pObj">需要序列化的对象</param>
        /// <returns>byte[]</returns>
        internal static byte[] CastToBytes<T>(this T pObj)
        {
            if (pObj == null)
                return null;

            using (MemoryStream _memory = new System.IO.MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(_memory, pObj);
                _memory.Position = 0;
                byte[] read = new byte[_memory.Length];
                _memory.Read(read, 0, read.Length);
                return read;
            }
        }
        /// <summary>
        /// 把字节反序列化成相应的对象
        /// </summary>
        /// <param name="pBytes">字节流</param>
        /// <returns>object</returns>
        internal static T CastToType<T>(this byte[] pBytes)
        {
            object ret = null;
            if (pBytes == null)
                ret = null;

            using (MemoryStream _memory = new System.IO.MemoryStream(pBytes))
            {
                _memory.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    ret = formatter.Deserialize(_memory);
                }
                catch
                {
                    Debug.Write("");
                }
            }
            return (T)ret;
        }

        /// <summary>
        /// 数据类型的比较
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        internal static bool Compare(this byte[] data1, byte[] data2)
        {
            if (data1 == null && data2 == null)
                return true;
            else if (data1 == null || data2 == null)
                return false;
            else if (data1.Length != data2.Length)
                return false;
            else
            {
                for (int i = 0; i < data1.Length; ++i)
                {
                    if (data1[i] != data2[i])
                        return false;
                }
            }
            return true;

        }
    }
}
