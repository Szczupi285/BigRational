using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public partial struct BigRational : IComparable<BigRational>
    {
        public int CompareTo(BigRational other)
        {
            
            if(this.Equals(other)) return 0;
            if (this.Numerator * other.Denominator > other.Numerator * this.Denominator) return 1;
            return -1;
        }

        public static bool operator <(BigRational left, BigRational right)
        {
            if(left.IsNaN() || right.IsNaN()) return false;
            
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(BigRational left, BigRational right)
        {
            if (left.IsNaN() || right.IsNaN()) return false;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(BigRational left, BigRational right)
        {
            if (left.IsNaN() || right.IsNaN()) return false;

            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(BigRational left, BigRational right)
        {
            if (left.IsNaN() || right.IsNaN()) return false;

            return left.CompareTo(right) >= 0;
        }
    }
}
