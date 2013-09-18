using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Crow.Little.Common
{
    /// <summary>
    /// 缓存字典类，继承自Dictionary泛型类，扩展了Synchronized方法，使之可以类似Queue，以支持同步访问
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class CommonDictionary<TKey, TValue>
    {
        #region Field
        private Dictionary<TKey, TValue> innerDict = new Dictionary<TKey, TValue>();
        protected bool isSynchronized;
        #endregion

        #region Property
        public virtual bool IsSynchronized
        {
            get { return this.isSynchronized; }
        }

        public virtual IEqualityComparer<TKey> Comparer
        {
            get
            {
                return this.innerDict.Comparer;
            }
        }

        public virtual int Count
        {
            get
            {
                return this.innerDict.Count;
            }
        }

        protected virtual Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get
            {
                return this.innerDict.Keys;
            }
        }

        protected virtual Dictionary<TKey, TValue>.ValueCollection Values
        {
            get
            {
                return this.innerDict.Values;
            }
        }
        #endregion

        #region Index
        public virtual TValue this[TKey key]
        {
            get
            {
                return this.innerDict[key];
            }
            set
            {
                this.innerDict[key] = value;
            }
        }
        #endregion

        #region Delegate
        public delegate bool KeyLoopCondtion(TKey k, params object[] condtionItems);
        public delegate bool ValueLoopCondtion(TValue v, params object[] condtionItems);
        #endregion

        #region Constructor
        public CommonDictionary()
            : base()
        { }
        #endregion

        #region Event
        #endregion

        #region Method
        /// <summary>
        /// 获取对应的同步访问字典
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static CommonDictionary<TKey, TValue> Synchronized(CommonDictionary<TKey, TValue> dic)
        {
            if (dic == null)
            {
                dic.isSynchronized = false;
                throw new ArgumentNullException("RmmHybridDictionary");
            }
            dic.isSynchronized = true;
            return new SynchronizedRmmDictionary<TKey, TValue>(dic);
        }

        public virtual void Add(TKey k, TValue v)
        {
            this.innerDict.Add(k, v);
        }

        public virtual void Clear()
        {
            this.innerDict.Clear();
        }

        public virtual bool ContainsKey(TKey key)
        {
            return this.innerDict.ContainsKey(key);
        }

        public virtual bool ContainsValue(TValue value)
        {
            return this.innerDict.ContainsValue(value);
        }

        public virtual Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {
            return this.innerDict.GetEnumerator();
        }

        public virtual bool Remove(TKey key)
        {
            return this.innerDict.Remove(key);
        }

        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            return this.innerDict.TryGetValue(key, out value);
        }

        public virtual IEnumerable LoopForKeys()
        {
            foreach (TKey k in this.innerDict.Keys)
            {
                yield return k;
            }
        }

        public virtual IEnumerable LoopForValues()
        {
            foreach (TValue v in this.innerDict.Values)
            {
                yield return v;
            }
        }

        public virtual IEnumerable LoopForKeys(KeyLoopCondtion kCondtion, params object[] condtionItems)
        {
            foreach (TKey k in this.innerDict.Keys)
            {
                if (kCondtion(k, condtionItems))
                {
                    yield return k;
                }
            }
        }

        public virtual IEnumerable LoopForValues(ValueLoopCondtion vCondtion, params object[] condtionItems)
        {
            foreach (TValue v in this.innerDict.Values)
            {
                if (vCondtion(v, condtionItems))
                {
                    yield return v;
                }
            }
        }
        #endregion

        #region Class
        private class SynchronizedRmmDictionary<SKey, SValue> : CommonDictionary<SKey, SValue>
        {
            #region Field
            private CommonDictionary<SKey, SValue> _dic;
            private object locker;
            #endregion

            #region Property
            public override IEqualityComparer<SKey> Comparer
            {
                get
                {
                    lock (this.locker)
                    {
                        return this._dic.Comparer;
                    }
                }
            }

            public override int Count
            {
                get
                {
                    lock (this.locker)
                    {
                        return this._dic.Count;
                    }
                }
            }

            public override bool IsSynchronized
            {
                get
                {
                    return true;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return this.locker;
                }
            }
            #endregion

            #region Index
            public override SValue this[SKey key]
            {
                get
                {
                    lock (this.locker)
                    {
                        return this._dic[key];
                    }
                }
                set
                {
                    lock (this.locker)
                    {
                        this._dic[key] = value;
                    }
                }
            }
            #endregion

            #region Constructor
            internal SynchronizedRmmDictionary(CommonDictionary<SKey, SValue> dic)
            {
                this._dic = dic;
                this.locker = new object();
            }
            #endregion

            #region Event
            #endregion

            #region Method
            public override void Add(SKey k, SValue v)
            {
                lock (this.locker)
                {
                    this._dic.Add(k, v);
                }
            }

            public override void Clear()
            {
                lock (this.locker)
                {
                    this._dic.Clear();
                }
            }

            public override bool ContainsKey(SKey key)
            {
                lock (this.locker)
                {
                    return this._dic.ContainsKey(key);
                }
            }

            public override bool ContainsValue(SValue value)
            {
                lock (this.locker)
                {
                    return this._dic.ContainsValue(value);
                }
            }

            public override Dictionary<SKey, SValue>.Enumerator GetEnumerator()
            {
                lock (this.locker)
                {
                    return this._dic.GetEnumerator();
                }
            }

            public override bool Remove(SKey key)
            {
                lock (this.locker)
                {
                    return this._dic.Remove(key);
                }
            }

            public override bool TryGetValue(SKey key, out SValue value)
            {
                lock (this.locker)
                {
                    return this._dic.TryGetValue(key, out value);
                }
            }

            public override IEnumerable LoopForKeys()
            {
                lock (locker)
                {
                    foreach (SKey k in this.Keys)
                    {
                        yield return k;
                    }
                }
            }

            public override IEnumerable LoopForValues()
            {
                lock (locker)
                {
                    foreach (SValue v in this.Values)
                    {
                        yield return v;
                    }
                }
            }

            public override IEnumerable LoopForKeys(KeyLoopCondtion kCondtion, params object[] condtionItems)
            {
                lock (locker)
                {
                    foreach (SKey k in this.innerDict.Keys)
                    {
                        if (kCondtion(k, condtionItems))
                        {
                            yield return k;
                        }
                    }
                }
            }

            public override IEnumerable LoopForValues(ValueLoopCondtion vCondtion, params object[] condtionItems)
            {
                lock (locker)
                {
                    foreach (SValue v in this.innerDict.Values)
                    {
                        if (vCondtion(v, condtionItems))
                        {
                            yield return v;
                        }
                    }
                }
            }
            #endregion
        }
        #endregion
    }
}
