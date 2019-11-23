using System;
using System.Diagnostics;
using System.Numerics;
using System.Linq;

namespace _20
{
    class Program
    {
        static int maxNum = 100;
        static int numTry = 25;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            BigInteger num = 1;
            for (int i = 2; i <= maxNum; i++)
                num *= i;

            Console.WriteLine(Array.ConvertAll(num.ToString().ToCharArray(), x => Int32.Parse(x.ToString())).Sum() + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
