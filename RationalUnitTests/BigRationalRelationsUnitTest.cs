using RationalLib;
using System.Numerics;

namespace RationalUnitTests
{
    [TestClass]
    public class BigRationalRelationsUnitTests
    {
        [DataTestMethod]
        [DataRow(-2, 2, 0)]
        

        public void CompareTo_Self(int numerator, int denumerator, int result)
        {
            var obj1 = new BigRational(numerator, denumerator);
            

            Assert.IsTrue(obj1.CompareTo(obj1) == result);
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2, 0)]
        [DataRow(-2, 2, 2, -2, 0)]
        [DataRow(-2, 8, 1, -4, 0)]
        [DataRow(-2, 4, 1, 2, -1)]
        [DataRow(1, 2, -2, 4, 1)]
        [DataRow(1, 10, 2, 10, -1)]
        [DataRow(2, 10, 1, 10, 1)]
        
        public void CompareTo_Other(int numerator, int denumerator, int secondNumerator, int secondDenumerator, int result)
        {
            var obj1 = new BigRational(numerator, denumerator);
            var obj2 = new BigRational(secondNumerator, secondDenumerator);

            Assert.IsTrue(obj1.CompareTo(obj2) == result);
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2, false)]
        [DataRow(-2, 2, 2, 2, true)]
        [DataRow(1, 4, 2, 4, true)]
        [DataRow(2, 4, 1, 4, false)]
        [DataRow(0, 0, 0, 0, false)]
        public void Less_Than_Operator(int numerator, int denumerator, int secondNumerator, int secondDenumerator, bool result)
        {
            {
                var obj1 = new BigRational(numerator, denumerator);
                var obj2 = new BigRational(secondNumerator, secondDenumerator);

                Assert.IsTrue(obj1 < obj2 == result);
            }
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2, true)]
        [DataRow(-2, 2, 2, 2, true)]
        [DataRow(1, 4, 2, 4, true)]
        [DataRow(2, 4, 1, 4, false)]
        [DataRow(0, 0, 0, 0, false)]

        public void Less_Or_Equal_Than_Operator(int numerator, int denumerator, int secondNumerator, int secondDenumerator, bool result)
        {
            {
                var obj1 = new BigRational(numerator, denumerator);
                var obj2 = new BigRational(secondNumerator, secondDenumerator);

                Assert.IsTrue(obj1 <= obj2 == result);
            }
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2, false)]
        [DataRow(-2, 2, 2, 2, false)]
        [DataRow(1, 4, 2, 4, false)]
        [DataRow(2, 4, 1, 4, true)]
        [DataRow(0, 0, 0, 0, false)]

        public void Greater_Than_Operator(int numerator, int denumerator, int secondNumerator, int secondDenumerator, bool result)
        {
            {
                var obj1 = new BigRational(numerator, denumerator);
                var obj2 = new BigRational(secondNumerator, secondDenumerator);

                Assert.IsTrue(obj1 > obj2 == result);
            }
        }
        [DataTestMethod]
        [DataRow(-2, 2, -2, 2, true)]
        [DataRow(-2, 2, 2, 2, false)]
        [DataRow(1, 4, 2, 4, false)]
        [DataRow(2, 4, 1, 4, true)]
        [DataRow(0, 0, 0, 0, false)]

        public void Greater_Or_Equal_Than_Operator(int numerator, int denumerator, int secondNumerator, int secondDenumerator, bool result)
        {
            {
                var obj1 = new BigRational(numerator, denumerator);
                var obj2 = new BigRational(secondNumerator, secondDenumerator);

                Assert.IsTrue(obj1 >= obj2 == result);
            }
        }






    }
}