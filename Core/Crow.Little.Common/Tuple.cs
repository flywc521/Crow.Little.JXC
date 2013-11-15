using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crow.Little.Common
{
    public sealed class Tuple<T, K, P, L, Z>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }
        public P Item3 { get; set; }
        public L Item4 { get; set; }
        public Z Item5 { get; set; }

        public Tuple(T t, K k, P p, L l, Z z)
        {
            Item1 = t;
            Item2 = k;
            Item3 = p;
            Item4 = l;
            Item5 = z;
        }
    }

    public sealed class Tuple<T, K, P, L>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }
        public P Item3 { get; set; }
        public L Item4 { get; set; }

        public Tuple(T t, K k, P p, L l)
        {
            Item1 = t;
            Item2 = k;
            Item3 = p;
            Item4 = l;
        }
    }

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
