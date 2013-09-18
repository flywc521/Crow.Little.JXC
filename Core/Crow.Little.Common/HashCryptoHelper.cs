namespace Crow.Little.Common
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// 哈希加密辅助类
    /// </summary>
    public sealed class HashCryptoHelper
    {
        #region Field
        private HashAlgorithm hashCryptoService;

        private static HashCryptoHelper sha1CryptoHelperInstance;
        private static HashCryptoHelper md5CryptoHelperInstance;
        #endregion
        #region Property
        public static HashCryptoHelper SHA1CryptoHelperInstance
        {
            get
            {
                return sha1CryptoHelperInstance = sha1CryptoHelperInstance ?? new HashCryptoHelper(SHA1.Create());
            }
        }
        public static HashCryptoHelper MD5CryptoHelperInstance
        {
            get
            {
                return md5CryptoHelperInstance = md5CryptoHelperInstance ?? new HashCryptoHelper(MD5.Create());
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// 哈希加密类的构造函数
        /// </summary>
        private HashCryptoHelper(HashAlgorithm hashAlgorithm)
        {
            hashCryptoService = hashAlgorithm;
        }
        #endregion
        #region Event
        #endregion
        #region Method
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="source">待加密的串</param>
        /// <returns>经过加密的串(Base64编码)</returns>
        public string Encrypto(string source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(source);
            byte[] bytOut = hashCryptoService.ComputeHash(bytIn);
            return Convert.ToBase64String(bytOut);
        }
        #endregion
    }
}
