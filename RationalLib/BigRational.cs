using System.Data;
using System.Data.Common;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace RationalLib
{
    
    public readonly struct BigRational : IEquatable<BigRational>
    {

        
        public readonly static BigRational NaN = new BigRational(0, 0);
        public readonly static BigRational Zero = new BigRational(0, 1);
        public readonly static BigRational One = new BigRational(1, 1);
        public readonly static BigRational Half = new BigRational(1, 2);


        // properties
        public BigInteger Numerator { get; init; }
        public BigInteger Denominator { get; init; }




        #region Constructors

        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            
           
            var GCD = BigInteger.GreatestCommonDivisor(numerator, denominator);

            if (GCD != 0) 
            {
                numerator /= GCD;
                denominator /= GCD;
            }



            if (denominator < 0)
            {
               
                Numerator = BigInteger.Negate(numerator);
                Denominator = BigInteger.Negate(denominator);
            }
            else
            {
                Numerator = numerator;
                Denominator = denominator;
            }
           


        }



        public BigRational(BigInteger input) : this(input, 1) { }
        public BigRational() : this(0, 1) { }

        public BigRational(string s) : this(Parse(s).Numerator, Parse(s).Denominator) { }

        
        public BigRational(decimal s)
        {

            string temp = s.ToString().Substring(s.ToString().IndexOf(",") + 1);
            int digAfterDecimalPoint = temp.Length;

            BigInteger den = new BigInteger(Math.Pow(10, digAfterDecimalPoint));
            BigInteger num;
            BigInteger befDecPoint = new BigInteger(s);
            BigInteger AftDecPoint = BigInteger.Parse(temp);
            if (s < 0)
            {
                num = BigInteger.Negate(befDecPoint * Denominator + AftDecPoint);

            }
            else
                num = befDecPoint * Denominator + AftDecPoint;


            BigRational TempObj = new BigRational(num, den);
            Numerator = TempObj.Numerator;
            Denominator = TempObj.Denominator;


        }

        public BigRational(double s) : this((decimal)s) { }
       






        #endregion

        public override string ToString()
        {

            if (this.IsNaN()) return "NaN";
            else if (this.IsPositiveInfinity()) return "+∞";
            else if (this.IsNegativeInfinity()) return "-∞";
            else return $"{Numerator}/{Denominator}";
        }

        #region exceptional cases methods
        bool IsNaN() => this.Numerator == 0 && this.Denominator == 0;

        bool IsInfinity() => this.Numerator != 0 && this.Denominator == 0;

        bool IsNegativeInfinity() => this.Numerator < 0 && this.Denominator == 0;

        bool IsPositiveInfinity() => this.Numerator > 0 && this.Denominator == 0;

        bool isFinite() => this.Denominator != 0;

        #endregion


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

        public static explicit operator int(BigRational input)
        {
            
            if (input == BigRational.NaN)
               throw new ArgumentException("NaN is not a number");
            return Convert.ToInt32((int)input.Numerator / (int)input.Denominator);
        }
        public decimal ToDecimal()
        {
            if (this == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return (decimal)this.Numerator / (decimal)this.Denominator;
           
        }
        public double ToDouble()
        {
            if (this == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return (double)this.Numerator / (double)this.Denominator;

        }
        public float ToSingle()
        {
            if (this == BigRational.NaN)
                throw new ArgumentException("NaN is not a number");
            return (float)this.Numerator / (float)this.Denominator;

        }

        #region IEquatable<BigRational>
        public override bool Equals(object? obj)
        {
            return obj is BigRational && Equals((BigRational)obj);
        }
        public bool Equals(BigRational other)
        {
             
            if (this.IsNaN() || other.IsNaN()) return false;
            if(this.IsPositiveInfinity() && other.IsPositiveInfinity()) return true;
            if (this.IsNegativeInfinity() && other.IsNegativeInfinity()) return true;

            if (this.Numerator == other.Numerator && this.Denominator == other.Denominator) return true;
            return false;
        }
        public static bool Equals(BigRational obj1, BigRational obj2) => obj1.Equals(obj2);
        
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        public static bool operator ==(BigRational obj1, BigRational obj2) => obj1.Equals(obj2);
        public static bool operator !=(BigRational obj1, BigRational obj2) => !obj1.Equals(obj2);

        
        #endregion
    }


}
   