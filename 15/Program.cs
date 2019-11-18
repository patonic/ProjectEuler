using System;
using System.Diagnostics;
using System.Numerics;

namespace _15
{
    class Program
    {
        static int maxXY = 20;
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

            BigInteger result;
            BigInteger n = (maxXY * 2);
            BigInteger nF = 1;
            for (int i = 1; i <= n; i++)
                nF *= i;
            BigInteger k = maxXY;
            BigInteger kF = 1;
            for (int i = 1; i <= k; i++)
                kF *= i;
            BigInteger n_kF = 1;
            for (int i = 1; i <= n-k; i++)
                n_kF *= i;

            Console.WriteLine(nF/(kF*n_kF) + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }


    }
}
