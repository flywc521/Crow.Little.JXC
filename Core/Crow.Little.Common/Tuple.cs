using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.Common
{
    public sealed class Tuple<T, K, P>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }
        public P Item3 { get; set; }

        public Tuple(T t, K k, P p)
        {
            Item1 = t;
            Item2 = k;
            Item3 = p;
        }
    }

    public sealed class Tuple<T, K>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }

        public Tuple(T t, K k)
        {
            Item1 = t;
            Item2 = k;
        }
    }
}
