using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

namespace _14
{
    class Program
    {
        static int maxNum = 1000000;
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

            int num = -1;
            int count = -1;
            Parallel.For(2, maxNum, (int i, ParallelLoopState pls) =>
            {
                BigInteger currN = i;
                int currC = 0;
                while (currN != 1) {
                    if (currN % 2 == 0)
                        currN /= 2;
                    else
                        currN = (3 * currN) + 1;
                    currC++;
                }
                if (currC > count)
                {
                    count = currC;
                    num = i;
                }
            });

            Console.WriteLine(num + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
