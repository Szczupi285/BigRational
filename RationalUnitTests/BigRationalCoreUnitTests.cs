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
    }
}