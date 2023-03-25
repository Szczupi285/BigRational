using RationalLib;
namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new BigRational(-2, 4);
            var p2 = new BigRational(0, 0);

            
            Console.WriteLine(p1.CompareTo(p2));
            Console.WriteLine(p1 < p2);
            Console.WriteLine(p1 > p2);
            Console.WriteLine(p1 <= p2);
            Console.WriteLine(p1 >= p2);
            Console.WriteLine(-1.0/0.0 > 1000000000000.0);
           
            Console.WriteLine();
            
            byte s = 5;
            BigRational p4 = s;
            double f = s;
            Console.WriteLine(p1);
            decimal temp = (decimal)p1;

            Console.WriteLine(temp);

           
        }
    }
}