using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public partial struct BigRational
    {
        #region implicit conversion integral numeric types to BigRational
        
        public static implicit operator BigRational(byte input) => new BigRational(input, 1);
        public static implicit operator BigRational(sbyte input) => new BigRational(input, 1);
        public static implicit operator BigRational(short input) => new BigRational(input, 1);
        public static implicit operator BigRational(ushort input) => new BigRational(input, 1);
        public static implicit operator BigRational(int input) => new BigRational(input, 1);
        public static implicit operator BigRational(uint input) => new BigRational(input, 1);
        public static implicit operator BigRational(long input) => new BigRational(input, 1);
        public static implicit operator BigRational(ulong input) => new BigRational(input, 1);

        #endregion

        #region explicit BigRational conversion 
        
        public static explicit operator sbyte(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToSByte((sbyte)input.Numerator / (sbyte)input.Denominator);
        }

        public static explicit operator byte(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToByte((byte)input.Numerator / (byte)input.Denominator);
        }
        public static explicit operator short(BigRational input)
        {
            
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToInt16((short)input.Numerator / (short)input.Denominator);
        }

        public static explicit operator ushort(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToUInt16((ushort)input.Numerator / (ushort)input.Denominator);
        }

        public static explicit operator int(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToInt32((int)input.Numerator / (int)input.Denominator);
        }

        public static explicit operator uint(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToUInt32((uint)input.Numerator / (uint)input.Denominator);
        }

        public static explicit operator long(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToInt64((long)input.Numerator / (long)input.Denominator);
        }

        public static explicit operator ulong(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return Convert.ToUInt64((ulong)input.Numerator / (ulong)input.Denominator);
        }

        public static explicit operator decimal(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return (decimal)input.Numerator / (decimal)input.Denominator;
        }

        public static explicit operator double(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return (double)input.Numerator / (double)input.Denominator;
        }

        public static explicit operator float(BigRational input)
        {
            if (input == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return (float)input.Numerator / (float)input.Denominator;
        }
        #endregion

        #region Parsing methods
        public static BigRational Parse(string s)
        {

            var Array = s.Split("/");
            if (Array.Length != 2)
                throw new FormatException("wrong format");

            return new BigRational(BigInteger.Parse(Array[0]), BigInteger.Parse(Array[1]));

        }
        public static bool TryParse(string? s, out BigRational result)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentNullException("value is null");
            result = BigRational.Zero;
            var Array = s.Split("/");

            if (Array.Length != 2)
                return false;
            else if ((Array[0] == "0" && Array[1] == "0") || (Array[0] == "-0" && Array[1] == "0")
                || (Array[0] == "0" && Array[1] == "-0") || (Array[0] == "-0" && Array[1] == "-0"))
                return false;
            else if (BigInteger.TryParse(Array[0], out _) == false || BigInteger.TryParse(Array[1], out _) == false)
                return false;
            else
            {
                result = new BigRational(BigInteger.Parse(Array[0]), BigInteger.Parse(Array[1]));
                return true;
            }
        }
        #endregion

    }
}
