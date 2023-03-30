using RationalLib;
namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new BigRational(2, 3);
            var p2 = new BigRational(4, 5);
            var p3 = new BigRational(8, 6);
            Console.WriteLine(new BigRational(-12, 90)); 
            Console.WriteLine(BigRational.Avg(p1,p2,p3));
            
           
        }
    }
}