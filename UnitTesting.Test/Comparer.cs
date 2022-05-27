using System;
using System.Collections.Generic;

namespace UnitTesting.Test
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparisonFunction;

        public Comparer(Func<T, T, bool> func)
        {
            _comparisonFunction = func;
        }

        public bool Equals(T x, T t)
        {
            return _comparisonFunction(x, t);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
    
}

