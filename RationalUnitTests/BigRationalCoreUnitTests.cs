using RationalLib;
using System.Numerics;

namespace RationalUnitTests
{
    [TestClass]
    public class BigRationalCoreUnitTests
    {
        [DataTestMethod]
        [DataRow(1, 4, 1, 4)]
        [DataRow(5, 1, 5, 1)]
        [DataRow(1, 1, 1, 1)]
        public void Constructor_Positive_irreducible_values(int numerator, int denumerator, int exectedNumerator, int expectedDenumerator)
        {
            var obj = new BigRational(numerator, denumerator);

            Assert.AreEqual(obj.Numerator, exectedNumerator);
            Assert.AreEqual(obj.Denominator, expectedDenumerator);
        }

        [DataTestMethod]
        [DataRow(1, -4, -1, 4)]
        [DataRow(5, -1, -5, 1)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(-2, 3, -2, 3)]
        public void Constructor_Negative_irreducible_values(int numerator, int denumerator, int exectedNumerator, int expectedDenumerator)
        {
            var obj = new BigRational(numerator, denumerator);

            Assert.AreEqual(obj.Numerator, exectedNumerator);
            Assert.AreEqual(obj.Denominator, expectedDenumerator);
        }

        [DataTestMethod]
        [DataRow(2, -4, -1, 2)]
        [DataRow(-5, 15, -1, 3)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(2, 8, 1, 4)]
        [DataRow(0, 4, 0, 1)]
        public void Constructor_reduction(int numerator, int denumerator, int exectedNumerator, int expectedDenumerator)
        {
            var obj = new BigRational(numerator, denumerator);

            Assert.AreEqual(obj.Numerator, exectedNumerator);
            Assert.AreEqual(obj.Denominator, expectedDenumerator);
        }

        [DataTestMethod]
        [DataRow("-1/2", -1, 2)]
        [DataRow("-5/15", -1, 3)]
        [DataRow("1/-1", -1, 1)]
        [DataRow("2/8", 1, 4)]
        [DataRow("0/4", 0, 1)]
        public void Parse(string input, int exectedNumerator, int expectedDenumerator)
        {
            var obj = BigRational.Parse(input);

            Assert.AreEqual(obj.Numerator, exectedNumerator);
            Assert.AreEqual(obj.Denominator, expectedDenumerator);
        }
        [DataTestMethod]
        [DataRow("-1/2", -1, 2)]
        [DataRow("-5/15", -1, 3)]
        [DataRow("1/-1", -1, 1)]
        [DataRow("2/8", 1, 4)]
        [DataRow("0/4", 0, 1)]
        public void TryParse_True(string input, int exectedNumerator, int expectedDenumerator)
        {
            BigRational result;
            var IsSuccesful = BigRational.TryParse(input, out result);
            Assert.IsTrue(IsSuccesful); 
            Assert.AreEqual(result.Numerator, exectedNumerator);
            Assert.AreEqual(result.Denominator, expectedDenumerator);
        }
        [DataTestMethod]
        [DataRow("0/0")]
        [DataRow("-0/0")]
        [DataRow("0/-0")]
        [DataRow("-0/-0")]
        [DataRow("a0/0")]
        [DataRow("12/b")]
        [DataRow("b/b")]
        [DataRow("2/2/3")]
        [DataRow("-2/-2/-3")]
        
        public void TryParse_False(string input)
        {
            BigRational result;
            var IsSuccesful = BigRational.TryParse(input, out result);
            Assert.IsFalse(IsSuccesful);
           
        }

        [DataTestMethod]
        [DataRow(2, -4, 0)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5)]
        [DataRow(2, 8, 0)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 4, -1)]
        [DataRow(4, -4, -1)]
        [DataRow(-4, -4, 1)]
        public void Explicit_Conversion_To_Int32(int numerator, int denumerator, int expectedInt32)
        {
            var obj = new BigRational(numerator, denumerator);
            int x = (int)obj;
            Assert.AreEqual(expectedInt32, x);
            
        }

        [DataTestMethod]
        [DataRow(-2, 2, -2, 2)]
        [DataRow(-2, 2, 2, -2)]
        [DataRow(-5, 15, -1, 3)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(2, 8, 1, 4)]
        [DataRow(0, 4, 0, 1)]
        public void Equals_True(int numerator, int denumerator, int secondNumerator, int secondDenumerator)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsTrue(obj1.Equals(obj2));
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 1)]
        [DataRow(-2, 2, 2, -1)]
        [DataRow(-5, 15, -1, 2)]
        [DataRow(1, -1, -1, 4)]
        [DataRow(2, 8, 1, 3)]
        [DataRow(0, 4, 1, 4)]
        [DataRow(0, 0, 0, 0)]
        public void Equals_False(int numerator, int denumerator, int secondNumerator, int secondDenumerator)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsFalse(obj1.Equals(obj2));
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2)]
        [DataRow(-2, 2, 2, -2)]
        [DataRow(-5, 15, -1, 3)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(2, 8, 1, 4)]
        [DataRow(0, 4, 0, 1)]
        public void Static_Equals_True(int numerator, int denumerator, int secondNumerator, int secondDenumerator)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsTrue(BigRational.Equals(obj1, obj2));
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 1)]
        [DataRow(-2, 2, 2, -1)]
        [DataRow(-5, 15, -1, 2)]
        [DataRow(1, -1, -1, 4)]
        [DataRow(2, 8, 1, 3)]
        [DataRow(0, 4, 1, 4)]
        [DataRow(0, 0, 0, 0)]
        public void Static_Equals_False(int numerator, int denumerator, int secondNumerator, int secondDenumerator)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsFalse(BigRational.Equals(obj1, obj2));
        }

        [DataTestMethod]
        [DataRow(-2, 2, -2, 2)]
        [DataRow(-2, 2, 2, -2)]
        [DataRow(-5, 15, -1, 3)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(2, 8, 1, 4)]
        [DataRow(0, 4, 0, 1)]
        public void Equality_operator(int numerator, int denumerator, int secondNumerator, int secondDenumerator)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsTrue(obj1 == obj2);
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2)]
        [DataRow(-2, 2, 2, -2)]
        [DataRow(-5, 15, -1, 3)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(2, 8, 1, 4)]
        [DataRow(0, 4, 0, 1)]
        public void Inequality_operator(int numerator, int denumerator, int secondNumerator, int secondDenumerator)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsFalse(obj1 != obj2);
        }

       



    }
}