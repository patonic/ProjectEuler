using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _23
{
    class Program
    {
        static int maxNum = 28123;
        static int numTry = 25;
        static object locker = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> abundantNumbers = new List<int>();

            Parallel.For(12, maxNum, (int i, ParallelLoopState pls) =>
            {
                int sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                        sum += j;
                    if (sum > i)
                    {
                        lock (locker)
                        {
                            abundantNumbers.Add(i);
                        }
                        break;
                    }
                }
            });

            abundantNumbers.Sort();

            int sum = 0;

            Parallel.For(1, maxNum+1, (int num, ParallelLoopState pls) =>
            {
                for (int i = 0; i < abundantNumbers.Count; i++)
                {
                    for (int j = i; j < abundantNumbers.Count; j++)
                    {
                        if (abundantNumbers[i] + abundantNumbers[j] > num)
                            break;
                        if (abundantNumbers[i] + abundantNumbers[j] == num)
                            goto continueParallel;
                    }

                    if (abundantNumbers[i] + abundantNumbers[i] > num)
                        break;
                }
                lock (locker)
                {
                    sum += num;

                }
                continueParallel:;
            });

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
