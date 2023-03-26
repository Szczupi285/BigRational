using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public partial struct BigRational
    {
        #region Arithmetic operators
       
        public static BigRational operator +(BigRational u1, BigRational u2) => u1.Plus(u2);

        public static BigRational operator -(BigRational u1, BigRational u2)
        {
            //special cases
            if (u1 == BigRational.NaN || u2 == BigRational.NaN ||
                (u1.IsNegativeInfinity() && u2.IsNegativeInfinity()) || 
                (u1.IsPositiveInfinity() && u2.IsPositiveInfinity()))
                return BigRational.NaN;

            if (u1.IsNegativeInfinity() && u2.isFinite() || 
                (u1.IsNegativeInfinity() && u2.IsPositiveInfinity()))
                return BigRational.NegativeInfinity;

            if (u1.IsPositiveInfinity() && u2.isFinite())
                return BigRational.PositiveInfinity;

            return new BigRational(u1.Numerator * u2.Denominator - u1.Denominator * u2.Numerator,
                u1.Denominator * u2.Denominator);
        }
        // opposite number
        public static BigRational operator -(BigRational u1)
        {
            
            if(u1.IsNaN())
                return BigRational.NaN;
            
            if (u1.IsPositiveInfinity())
                return BigRational.NegativeInfinity;
            
            if (u1.IsNegativeInfinity())
                return BigRational.PositiveInfinity;
            
            return new BigRational(u1.Numerator * (-1), u1.Denominator);
        }
        public static BigRational operator *(BigRational u1, BigRational u2)
        {
            // special cases
            if (u1.IsNaN() || u2.IsNaN())
                return BigRational.NaN;

            if ((u1.IsPositiveInfinity() && u2.Numerator > 0) || 
                (u1.Numerator > 0 && u2.IsPositiveInfinity()) ||
                (u1.IsNegativeInfinity() && u2.Numerator < 0) ||
                (u1.Numerator < 0 && u2.IsNegativeInfinity()) || 
                    (u1.IsPositiveInfinity() && u2.IsPositiveInfinity()) ||
                    u1.IsNegativeInfinity() && u2.IsNegativeInfinity())
                return BigRational.PositiveInfinity;

            if ((u1.IsNegativeInfinity() && u2.Numerator > 0) ||
                u1.Numerator > 0 && u2.IsNegativeInfinity() || 
                u1.IsNegativeInfinity() && u2.IsPositiveInfinity() ||
                u1.IsPositiveInfinity() && u2.IsNegativeInfinity())
                return BigRational.NegativeInfinity;

            return new BigRational(u1.Numerator * u2.Numerator, u1.Denominator * u2.Denominator);

        }
        public static BigRational operator /(BigRational u1, BigRational u2)
        {
            // special cases
            if (u1.IsNaN() || u2.IsNaN())
                return BigRational.NaN;

            if ((u1.IsPositiveInfinity() && u2.Numerator > 0) ||
                (u1.Numerator > 0 && u2.IsPositiveInfinity()) ||
                (u1.IsNegativeInfinity() && u2.Numerator < 0) ||
                (u1.Numerator < 0 && u2.IsNegativeInfinity()))
                return BigRational.PositiveInfinity;

            if ((u1.IsNegativeInfinity() && u2.Numerator > 0) ||
                u1.Numerator > 0 && u2.IsNegativeInfinity())
                return BigRational.NegativeInfinity;

            return new BigRational(u1.Numerator * u2.Denominator, u1.Denominator * u2.Numerator);

        }

        public static BigRational operator ++(BigRational u1)
        {
            if (u1.IsNaN())
                return BigRational.NaN;
            if (u1.IsPositiveInfinity())
                return BigRational.PositiveInfinity;
            if (u1.IsNegativeInfinity())
                return BigRational.NegativeInfinity;



            return new BigRational(u1.Numerator, u1.Denominator) + BigRational.One;
        }
        public static BigRational operator --(BigRational u1)
        {
            if (u1.IsNaN())
                return BigRational.NaN;
            if (u1.IsPositiveInfinity())
                return BigRational.PositiveInfinity;
            if (u1.IsNegativeInfinity())
                return BigRational.NegativeInfinity;

            return new BigRational(u1.Numerator, u1.Denominator) - BigRational.One;
        }
        #endregion

        #region Methods
        private BigRational Plus(BigRational other)
        {
            // special cases
            if (this == BigRational.NaN || other == BigRational.NaN)
                return BigRational.NaN;

            if (this.IsPositiveInfinity() && other.IsPositiveInfinity())
                return BigRational.PositiveInfinity;

            if (this.IsNegativeInfinity() && other.IsNegativeInfinity())
                return BigRational.NegativeInfinity;

            if (this.IsPositiveInfinity() && other.IsNegativeInfinity()
                || this.IsNegativeInfinity() && other.IsPositiveInfinity())
                return BigRational.NaN;

            return new BigRational(this.Numerator * other.Denominator + this.Denominator * other.Numerator,
                this.Denominator * other.Denominator);
        }
        public static BigRational Sum(params BigRational[] input)
        {
            if (input.Length < 2)
                throw new ArgumentException("You need at least two numbers to get a sum");
            var x = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                x = x.Plus(input[i]);

            }
            return x;
        }

        public static BigRational Abs(BigRational u1) => new BigRational(BigInteger.Abs(u1.Numerator), u1.Denominator);

        public static int Sign(BigRational u1)
        {
            if(u1.Numerator > 0)
            {
                return 1;
            }
            if (u1.Numerator < 0)
                return -1;
            return 0;
        } 

       public static BigRational Floor(BigRational u1) => new BigRational(BigInteger.Divide(u1.Numerator, u1.Denominator), 1);
       public static BigRational Ceiling(BigRational u1) => new BigRational(BigInteger.Divide(u1.Numerator, u1.Denominator) + 1, 1);

       public static BigRational Max(BigRational u1, BigRational u2)
       {
            if (u1.Numerator * u2.Denominator > u1.Denominator * u2.Numerator)
                return u1;
            else
                return u2;
       }
       public static BigRational Min(BigRational u1, BigRational u2)
       {
            if (u1.Numerator * u2.Denominator < u1.Denominator * u2.Numerator)
                return u1;
            else
                return u2;
       }
       public static BigRational Pow(BigRational u1, int ToPow)
       {
            int temp = Math.Abs(ToPow);
            var x = u1;
            if (ToPow == 0)
                return BigRational.One;
            for (int i = 0; i < temp -1; i++)
            {
                x *= u1;
            }
            if (ToPow < 0)
                return BigRational.One / x;
                
            return x;
       }

        #endregion
    }
}
