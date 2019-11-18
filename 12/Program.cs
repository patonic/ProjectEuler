using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _12
{
    class Program
    {
        static int maxNum = 500;
        static int numTry = 1;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            int count = -1;
            int num = 0;
            for (int i = 1; count <= maxNum; i++)
            {
                count = 0;
                num += i;
                Parallel.For(1, num + 1, (int i, ParallelLoopState pls) =>
                  {
                      if (num % i == 0)
                      {
                          count++;
                          if (count > maxNum)
                              pls.Break();
                      }
                  });
            }

            Console.WriteLine(num + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
