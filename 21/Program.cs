using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _21
{
    class Program
    {
        static int maxNum = 10000;
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

            List<int> result = new List<int>();

            for (int i = 2; i <= maxNum; i++)
            {
                if (result.Contains(i))
                    continue;

                if (i == 220)
                { }    

                int sumA = sumDividers(i);
                if (sumA == i)
                    continue;
                int sumB = sumDividers(sumA);

                if (i == sumB)
                {
                    result.Add(i);
                    result.Add(sumA);
                }

            }

            Console.WriteLine(result.Sum() + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }

        static int sumDividers(int num)
        {
            int sum = 0;
            Parallel.For(1, (num / 2) + 1, (int i, ParallelLoopState pls) =>
            {
                if (num % i == 0)
                    sum += i;
            });
            return sum;
        }
    }
}
