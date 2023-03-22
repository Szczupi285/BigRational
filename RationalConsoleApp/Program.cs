using RationalLib;
using System.Numerics;
BigInteger f123 = BigInteger.Pow(321421421, 3);
BigInteger f125 = BigInteger.Pow(421542, 3);






var v = new BigRational(f123, f125);
Console.WriteLine(v.ToDecimal());
decimal s = -0.422m;
double s1 = -0.422;
int temp = s.ToString().Substring(s.ToString().IndexOf(",") + 1).Length;

BigRational y = new BigRational(4, 10);
BigRational x = new BigRational(s);
BigRational x1 = new BigRational(s1);
Console.WriteLine(x);
Console.WriteLine(x1);
Console.WriteLine(y);