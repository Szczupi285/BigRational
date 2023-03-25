using System.Numerics;
using System.Runtime.CompilerServices;
using RationalLib;
namespace RationalLib
{
    public readonly partial struct BigRationalRelations : IComparable<BigRationalRelations>
    {
        
        public int CompareTo(BigRationalRelations other)
        {
            
            
            if (this.Equals(other)) return 0;
            
            
        }
        
        public static bool operator <(BigRational left, BigRational right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(BigRational left, BigRational right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(BigRational left, BigRational right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(BigRational left, BigRational right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}