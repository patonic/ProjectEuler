using System;
using System.Diagnostics;
using System.Numerics;

namespace _16
{
    class Program
    {
        static int maxN = 1000;
        static int numTry = 10;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            BigInteger pow = BigInteger.Pow(2, maxN);

            string powString = pow.ToString();
            BigInteger sum = 0;
            for (int i = 0; i < powString.Length; i++)
                sum += BigInteger.Parse(powString.Substring(i, 1));

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }


    }
}
