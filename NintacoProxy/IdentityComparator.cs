using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nintaco
{
    class IdentityComparator : IEqualityComparer<object>
    {

        public new bool Equals(object x, object y)
        {
            return Object.ReferenceEquals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}
