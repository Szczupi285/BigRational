using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using RationalLib;
using System.Data;
using System.Numerics;

namespace RationalUnitTests
{
    [TestClass]
    public class BigRationalArithmeticUnitTests
    {

        [DataTestMethod]
        [DataRow(2, 2, 2, 2, 2, 1)]
        [DataRow(2, 2, -2, 2, 0, 1)]
        [DataRow(-2, 2, -2, 2, -2, 1)]
        [DataRow(0, 1, 0, 1, 0, 1)]
        [DataRow(12, 2, -4, 2, 4, 1)]

        public void Addition_Operator(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int expectedNumerator, int expectedDenumerator)
        {
            Assert.IsTrue(new BigRational(Numerator_1, Denumerator_1) + new BigRational(Numerator_2, Denumerator_2) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 2, 0, 1)]
        [DataRow(2, 2, -2, 2, 2, 1)]
        [DataRow(-2, 2, -2, 2, 0, 1)]
        [DataRow(-2, 2, 2, 2, -2, 1)]
        [DataRow(0, 1, 0, 1, 0, 1)]
        [DataRow(12, 2, -4, 2, 8, 1)]

        public void Subtraction_Operator(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int expectedNumerator, int expectedDenumerator)
        {
            Assert.IsTrue(new BigRational(Numerator_1, Denumerator_1) - new BigRational(Numerator_2, Denumerator_2) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(2, 2, -1, 1)]
        [DataRow(1, 1, -1, 1)]
        [DataRow(-1, 1, 1, 1)]
        [DataRow(-2, 2, 1, 1)]

        public void Negete_Operator(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator)
        {
            Assert.IsTrue(-new BigRational(Numerator_1, Denumerator_1) == new BigRational(expectedNumerator, expectedDenumerator));
        }
        
        [DataTestMethod]
        [DataRow(4, 2, 4, 2, 4, 1)]
        [DataRow(4, 2, -4, 2, -4, 1)]
        [DataRow(-4, 2, 4, 2, -4, 1)]
        [DataRow(-4, 2, -4, 2, 4, 1)]
        [DataRow(0, 1, 0, 1, 0, 1)]
        public void Multiplication_Operator(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int expectedNumerator, int expectedDenumerator)
        {
            Assert.IsTrue(new BigRational(Numerator_1, Denumerator_1) * new BigRational(Numerator_2, Denumerator_2) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(4, 2, 2, 2, 2, 1)]
        [DataRow(4, 2, -2, 2, -2, 1)]
        [DataRow(-4, 2, 2, 2, -2, 1)]
        [DataRow(-4, 2, -2, 2, 2, 1)]
        public void Division_Operator(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int expectedNumerator, int expectedDenumerator)
        {
            
            Assert.IsTrue(new BigRational(Numerator_1, Denumerator_1) / new BigRational(Numerator_2, Denumerator_2) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(2, 1, 3, 1)]
        [DataRow(-2, 1, -1, 1)]
        [DataRow(0, 1, 1, 1)]
        public void Incrementation_Operator(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator)
        {
            BigRational Test = new BigRational(Numerator_1, Denumerator_1);
            Test++;
            Assert.IsTrue(Test == new BigRational(expectedNumerator, expectedDenumerator));
        }
        [DataTestMethod]
        [DataRow(2, 1, 1, 1)]
        [DataRow(-2, 1, -3, 1)]
        [DataRow(0, 1, -1, 1)]
        public void Decrementation_Operator(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator)
        {
            BigRational Test = new BigRational(Numerator_1, Denumerator_1);
            Test--;
            Assert.IsTrue(Test == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod] // 0 = "+", 1 = "- with two parameters", 2 = "*", 3 = "/" 4 = "- negate one parameter" 5 = "++", 6 = "--"
        [DataRow(0, 0, 2, 1, 0)]
        [DataRow(0, 0, 0, 1, 1)]
        [DataRow(0, 0, 4, 1, 2)]
        [DataRow(0, 1, 0, 1, 3)]
        [DataRow(0, 0, 0, 0, 4)]
        [DataRow(0, 0, 0, 0, 5)]
        [DataRow(0, 0, 0, 0, 6)]

        public void NaN_Result_Cases(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int sign)
        {
            BigRational NaN;
            if (sign == 0)
                NaN = (new BigRational(Numerator_1, Denumerator_1) + new BigRational(Numerator_2, Denumerator_2));
            else if (sign == 1)
                NaN = (new BigRational(Numerator_1, Denumerator_1) - new BigRational(Numerator_2, Denumerator_2));
            else if (sign == 2)
                NaN = (new BigRational(Numerator_1, Denumerator_1) * new BigRational(Numerator_2, Denumerator_2));
            else if (sign == 3)
                NaN = (new BigRational(Numerator_1, Denumerator_1) / new BigRational(Numerator_2, Denumerator_2));
            else if (sign == 4)
                NaN = -new BigRational(Numerator_1, Denumerator_1);
            else if (sign == 5)
            {
                NaN = new BigRational(Numerator_1, Denumerator_1);
                NaN++;
            }
            else
            {
                NaN = new BigRational(Numerator_1, Denumerator_1);
                NaN--;
            }
            Assert.IsTrue(NaN.Numerator == 0 && NaN.Denominator == 0);
        }

        [DataTestMethod]
        [DataRow(4, 1, 2, 1, 3, 1 , 9, 1)]
        [DataRow(-4, 1, -2, 1, -3, 1 , -9, 1)]
        [DataRow(-4, 1, 2, 1, 3, 1 , 1, 1)]
        [DataRow(-4, 1, -2, 1, 3, 1 , -3, 1)]
        public void Sum_Method(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int Numerator_3, int Denumerator_3, int expectedNumerator, int expectedDenumerator)
        {
            BigRational test = BigRational.Sum(new BigRational(Numerator_1, Denumerator_1), new BigRational(Numerator_2, Denumerator_2), new BigRational(Numerator_3, Denumerator_3));
            Assert.IsTrue(test == new BigRational(expectedNumerator, expectedDenumerator));
        }
        [DataTestMethod]
        [DataRow(2, 1, 2, 1)]
        [DataRow(-2, 1, 2, 1)]
        [DataRow(0, 1, 0, 1)]
        public void Abs_Method(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator)
        {
            BigRational Test = BigRational.Abs(new BigRational(Numerator_1, Denumerator_1));
            Assert.IsTrue(Test == new BigRational(expectedNumerator, expectedDenumerator));
        }
        [DataTestMethod]
        [DataRow(2, 1, 1)]
        [DataRow(-2, 1, -1)]
        [DataRow(0, 1, 0)]
        public void Sign_Method(int Numerator_1, int Denumerator_1, int expectedNum)
        {
            int temp = BigRational.Sign(new BigRational(Numerator_1, Denumerator_1));
            Assert.IsTrue(temp == expectedNum);
        }

        [DataTestMethod]
        [DataRow(7, 3, 2, 1)]
        [DataRow(12, 3, 4, 1)]
        [DataRow(18, 4, 4, 1)]
        public void Floor_Method(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator)
        {
            Assert.IsTrue(BigRational.Floor(new BigRational(Numerator_1, Denumerator_1)) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(7, 3, 3, 1)]
        [DataRow(12, 3, 4, 1)]
        [DataRow(18, 4, 5, 1)]
        public void Ceiling_Method(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator)
        {
            Assert.IsTrue(BigRational.Ceiling((new BigRational(Numerator_1, Denumerator_1))) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(4, 2, 2, 2, 2, 1)]
        [DataRow(-4, 2, 2, 2, 1, 1)]
        [DataRow(4, 2, -4, 2, 2, 1)]
        [DataRow(-6, 2, -4, 2, -2, 1)]
        [DataRow(-4, 2, -4, 2, -2, 1)]
        public void Max_Method(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int expectedNumerator, int expectedDenumerator)
        {

            Assert.IsTrue(BigRational.Max(new BigRational(Numerator_1,Denumerator_1),new BigRational(Numerator_2,Denumerator_2)) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(4, 2, 2, 2, 1, 1)]
        [DataRow(-4, 2, 2, 2, -2, 1)]
        [DataRow(4, 2, -4, 2, -2, 1)]
        [DataRow(-6, 2, -4, 2, -3, 1)]
        [DataRow(-4, 2, -4, 2, -2, 1)]
        public void Min_Method(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int expectedNumerator, int expectedDenumerator)
        {

            Assert.IsTrue(BigRational.Min(new BigRational(Numerator_1, Denumerator_1), new BigRational(Numerator_2, Denumerator_2)) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(2, 1, 8, 1, 3)]
        [DataRow(2, 1, 1, 8, -3)]
        [DataRow(-2, 1, 4, 1, 2)]
        [DataRow(-2, 1, 1, 4, -2)]
        [DataRow(-2, 1, -8, 1, 3)]
        [DataRow(-2, 1, -1, 8, -3)]
        [DataRow(-2, 1, 16, 1, 4)]
        [DataRow(-2, 1, 1, 16, -4)]
        [DataRow(0, 1, 0, 1, 3)]
        public void Pow_Method(int Numerator_1, int Denumerator_1, int expectedNumerator, int expectedDenumerator, int ToPow)
        {
            Assert.IsTrue(BigRational.Pow(new BigRational(Numerator_1, Denumerator_1), ToPow) == new BigRational(expectedNumerator, expectedDenumerator));
        }

        [DataTestMethod]
        [DataRow(2, 3, 4, 5, 8, 6, 14, 15)]
        [DataRow(-2, 3, -4, 5, -8, 6, -14, 15)]
        [DataRow(-2, 3, -4, 5, 8, 6, -2, 45)]
        [DataRow(4, 3, 4, 3, 4, 3, 4, 3)]

        public void Avg_Method(int Numerator_1, int Denumerator_1, int Numerator_2, int Denumerator_2, int Numerator_3, int Denumerator_3, int expectedNumerator, int expectedDenumerator)
        {
            BigRational test = BigRational.Avg(new BigRational(Numerator_1, Denumerator_1), new BigRational(Numerator_2, Denumerator_2), new BigRational(Numerator_3, Denumerator_3));
            Assert.IsTrue(test == new BigRational(expectedNumerator, expectedDenumerator));
        }


    }
}