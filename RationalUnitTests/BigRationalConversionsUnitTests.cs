using RationalLib;
using System.Numerics;

namespace RationalUnitTests
{
    [TestClass]
    public class BigRationalConversionsUnitTests
    {

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
        [DataRow(2, 4, 0)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5)]
        [DataRow(2, 8, 0)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, -4, 1)]
        [DataRow(-255, -255, 1)]
        public void Explicit_Conversion_To_Byte(int numerator, int denumerator, int expectedByte)
        {
            var obj = new BigRational(numerator, denumerator);
            byte x = (byte)obj;
            Assert.AreEqual(expectedByte, x);

        }
        [DataTestMethod]
        [DataRow(2, 4, (sbyte)0)]
        [DataRow(10, 2, (sbyte)5)]
        [DataRow(11, 2, (sbyte)5)]
        [DataRow(2, 8, (sbyte)0)]
        [DataRow(0, 4, (sbyte)0)]
        [DataRow(4, 4, (sbyte)1)]
        [DataRow(255, 255, (sbyte)1)]
        public void Explicit_Conversion_To_SByte(int numerator, int denumerator, int expectedSByte)
        {
            var obj = new BigRational(numerator, denumerator);
            sbyte x = (sbyte)obj;
            Assert.AreEqual(expectedSByte, x);

        }
        [DataTestMethod]
        [DataRow(2, -4, 0)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5)]
        [DataRow(2, 8, 0)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 4, -1)]
        [DataRow(4, -4, -1)]
        [DataRow(-32767, -32767, 1)]
        public void Explicit_Conversion_To_Int16(int numerator, int denumerator, int expectedInt16)
        {
            var obj = new BigRational(numerator, denumerator);
            short x = (short)obj;
            Assert.AreEqual(expectedInt16, x);

        }
        [DataTestMethod]
        [DataRow(2, 4, (ushort)0)]
        [DataRow(10, 2, (ushort)5)]
        [DataRow(11, 2, (ushort)5)]
        [DataRow(2, 8, (ushort)0)]
        [DataRow(0, 4, (ushort)0)]
        [DataRow(4, 4, (ushort)1)]
        [DataRow(4, 4, (ushort)1)]
        [DataRow(32767, 32767, (ushort)1)]
        public void Explicit_Conversion_To_UInt16(int numerator, int denumerator, ushort expectedUInt16)
        {
            var obj = new BigRational(numerator, denumerator);
            ushort x = (ushort)obj;
            Assert.AreEqual(expectedUInt16, x);

        }

        [DataTestMethod]
        [DataRow(2, -4, 0)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5)]
        [DataRow(2, 8, 0)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 4, -1)]
        [DataRow(4, -4, -1)]
        [DataRow(-2147483647, -2147483647, 1)]
        public void Explicit_Conversion_To_Int32(int numerator, int denumerator, int expectedInt32)
        {
            var obj = new BigRational(numerator, denumerator);
            int x = (int)obj;
            Assert.AreEqual(expectedInt32, x);

        }
        [DataTestMethod]
        [DataRow(2, 4, (uint)0)]
        [DataRow(10, 2, (uint)5)]
        [DataRow(11, 2, (uint)5)]
        [DataRow(2, 8, (uint)0)]
        [DataRow(0, 4, (uint)0)]
        [DataRow(10000, 400, (uint)25)]
        [DataRow(4, 4, (uint)1)]
        [DataRow(2147483647, 2147483647,(uint)1)]
        public void Explicit_Conversion_To_UInt32(int numerator, int denumerator, uint expectedUInt32)
        {
            var obj = new BigRational(numerator, denumerator);
            uint x = (uint)obj;
            Assert.AreEqual(expectedUInt32, x);

        }
        [DataTestMethod]
        [DataRow(2, -4, 0)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5)]
        [DataRow(2, 8, 0)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 4, -1)]
        [DataRow(4, -4, -1)]
        [DataRow(-9223372036854775807, -9223372036854775807, 1)]
        public void Explicit_Conversion_To_Int64(long numerator, long denumerator, int expectedInt64)
        {
            var obj = new BigRational(numerator, denumerator);
            long x = (long)obj;
            Assert.AreEqual(expectedInt64, x);

        }
        [DataTestMethod]
        [DataRow(2, 4, (ulong)0)]
        [DataRow(10, 2, (ulong)5)]
        [DataRow(11, 2, (ulong)5)]
        [DataRow(2, 8, (ulong)0)]
        [DataRow(0, 4, (ulong)0)]
        [DataRow(10000, 400, (ulong)25)]
        [DataRow(4, 4, (ulong)1)]
        [DataRow(9223372036854775807, 9223372036854775807, (ulong)1)]
        public void Explicit_Conversion_To_UInt64(long numerator, long denumerator, ulong expectedUInt64)
        {
            var obj = new BigRational(numerator, denumerator);
            ulong x = (ulong)obj;
            Assert.AreEqual(expectedUInt64, x);

        }
        [DataTestMethod]
        [DataRow(2, -4, -0.5)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5.5)]
        [DataRow(2, 8, 0.25)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 16, -4.0/16.0)]
        [DataRow(4, -16, -4/16.0)]
        public void Explicit_Conversion_To_Decimal(int numerator, int denumerator, double expectedDecimal)
        {
            decimal exp = Convert.ToDecimal(expectedDecimal);
            var obj = new BigRational(numerator, denumerator);
            decimal x = (decimal)obj;
            Assert.AreEqual(exp, x);

        }
        [DataTestMethod]
        [DataRow(2, -4, -0.5)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5.5)]
        [DataRow(2, 8, 0.25)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 16, -4.0 / 16.0)]
        [DataRow(4, -16, -4 / 16.0)]
        public void Explicit_Conversion_To_Double(long numerator, long denumerator, double expectedDouble)
        {
            var obj = new BigRational(numerator, denumerator);
            double x = (double)obj;
            Assert.AreEqual(expectedDouble, x);

        }
        [DataTestMethod]
        [DataRow(2, -4, -0.5)]
        [DataRow(10, 2, 5)]
        [DataRow(11, 2, 5.5)]
        [DataRow(2, 8, 0.25)]
        [DataRow(0, 4, 0)]
        [DataRow(-4, 16, -4.0 / 16.0)]
        [DataRow(4, -16, -4 / 16.0)]
        public void Explicit_Conversion_To_Float(long numerator, long denumerator, double expectedFloat)
        {
            float exp = Convert.ToSingle(expectedFloat);
            var obj = new BigRational(numerator, denumerator);
            float x = (float)obj;
            Assert.AreEqual(exp, x);

        }







    }
}