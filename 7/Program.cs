using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _7
{
    class Program
    {
        static long maxNum = 100;
        static int numTry = 50;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            double summA = Math.Pow(((maxNum * (maxNum + 1)) / 2), 2);
            double summB = 0;
            Parallel.For(1, maxNum + 1, delegate (long i)
            {
                summB += Math.Pow(i, 2);
            });

            Console.WriteLine(summA - summB + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
