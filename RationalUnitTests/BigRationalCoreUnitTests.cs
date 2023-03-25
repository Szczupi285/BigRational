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
        [DataRow(-2, 2, -2, 2)]
        [DataRow(-2, 2, 2, -2)]
        [DataRow(-5, 15, -1, 3)]
        [DataRow(1, -1, -1, 1)]
        [DataRow(2, 8, 1, 4)]
        [DataRow(0, 4, 0, 1)]
        [DataRow(1, 0, 3, 0)]
        [DataRow(-1, 0, -3, 0)]
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
        [DataRow(1, 0, -1, 0)]
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
        [DataRow(1, 0, 3, 0)]
        [DataRow(-1, 0, -3, 0)]
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
        [DataRow(1, 0, -1, 0)]
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