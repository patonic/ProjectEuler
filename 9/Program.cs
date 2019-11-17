using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {
        static int maxNum = 1000;
        static int numTry = 3;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            BigInteger max = 0;
            int a = -1;
            int b = -1;
            int c = -1;
            Parallel.For(1, maxNum + 1, (int i, ParallelLoopState plsI) =>
               {
                   Parallel.For(1, maxNum + 1, (int j) =>
                   {
                       if (i + j <= maxNum)
                           Parallel.For(1, maxNum + 1, (int k) =>
                           {
                               if (i + j + k == maxNum && Math.Pow(i, 2) + Math.Pow(j, 2) == Math.Pow(k, 2))
                               {
                                   a = i;
                                   b = j;
                                   c = k;
                                   plsI.Break();
                               }
                           });
                   });
               });

            Console.WriteLine(a * b * c + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
