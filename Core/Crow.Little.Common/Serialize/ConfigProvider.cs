namespace Crow.Little.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// 配置信息序列化
    /// </summary>
    public class ConfigProvider
    {
        #region Field

        private bool _dirty = false;
        public bool Dirty
        {
            get { return _dirty; }
        }

        //{ session {key -value} }
        private Dictionary<string, Dictionary<string, byte[]>> _configinfo = new Dictionary<string, Dictionary<string, byte[]>>();

        //
        protected string _confname;
        public string Confname
        {
            get { return _confname; }
        }

        protected bool _saveonvaluechanged;
        public bool SaveOnValueChanged
        {
            get
            {
                return _saveonvaluechanged;
            }
            set
            {
                _saveonvaluechanged = value;
            }


        }

        #endregion

        #region Value Get/Set

        public T GetValue<T>(string session, string key, T DefaultValue)
        {
            if (_configinfo.ContainsKey(session))
            {
                if (_configinfo[session].ContainsKey(key))
                {
                    var byteval = _configinfo[session][key];
                    try
                    {
                        return byteval.CastToType<T>();
                    }
                    catch
                    {
                        //注：好像常常float类型的数据无法正常serialize.
                        // LogManager.Errors(e.ToString());
                        //Debug.Write(e.ToString());
                        SetValue(session, key, DefaultValue);
                        return DefaultValue;

                    }

                }
            }
            SetValue(session, key, DefaultValue);
            return DefaultValue;
        }

        public T GetValue<T>(string Onlykey, T DefaultValue)
        {
            return GetValue<T>("__DefaultSession__", Onlykey, DefaultValue);
        }


        public bool SetValue<T>(string session, string key, T value)
        {
            var byteval = value.CastToBytes();

            if (!_configinfo.ContainsKey(session))
            {
                _configinfo[session] = new Dictionary<string, byte[]>();
            }
            if (!(_configinfo[session].ContainsKey(key) && ConfigProviderHelper.Compare(_configinfo[session][key], byteval)))
            {
                _dirty = true;
                _configinfo[session][key] = byteval;
            }
            if (_saveonvaluechanged && _dirty)
            {
                Save();
            }
            return true;

        }

        public bool SetValue<T>(string Onlykey, T value)
        {
            return SetValue<T>("__DefaultSession__", Onlykey, value);
        }

        #endregion

        #region Load/Save/SaveAs
        public bool LoadConfig(string fname)
        {
            try
            {
                _confname = fname;
                _configinfo = UnSerializeProfile(fname);
                return true;
            }
            catch (System.Exception)
            {
                _configinfo = new Dictionary<string, Dictionary<string, byte[]>>();
                return false;
            }

        }
        public void Save()
        {
            if (_dirty)
            {
                SerializeProfile(_confname, _configinfo);
                _dirty = false;
            }
        }

        public void SaveAsConfig(string fname)
        {
            SerializeProfile(fname, _configinfo);
        }
        #endregion

        #region File Serialization API

        static void SerializeProfile(string fname, Dictionary<string, Dictionary<String, byte[]>> infos)
        {
            if (infos != null)
            {
                using (Stream stream = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, infos);
                }
            }
        }
        static Dictionary<string, Dictionary<string, byte[]>> UnSerializeProfile(string fname)
        {
            using (FileStream stream = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                Dictionary<string, Dictionary<string, byte[]>> infos = formatter.Deserialize(stream) as Dictionary<string, Dictionary<string, byte[]>>;
                return infos;
            }
        }
        #endregion

        #region FindAllSession
        /// <summary>
        /// FindAllSession
        /// </summary>
        public List<string> FindAllSession()
        {
            return _configinfo.Keys.ToList();
        }
        #endregion

        #region Import/Export Session
        /// <summary>
        /// ExportSession
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public Dictionary<string, byte[]> ExportSession(string session)
        {
            if (_configinfo.ContainsKey(session))
            {
                return _configinfo[session];
            }
            return new Dictionary<string, byte[]>();
        }

        /// <summary>
        /// ImportSession
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sessionValue"></param>
        public void ImportSession(string session, Dictionary<string, byte[]> sessionValue)
        {
            _configinfo[session] = sessionValue;
        }
        #endregion

        #region Clear
        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Clear()
        {
            _configinfo.Clear();
        }
        #endregion
    }
}
