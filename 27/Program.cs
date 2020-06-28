using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _27
{
    class Program
    {
        static int minA = -999;
        static int maxA = 999;
        static int minB = -1000;
        static int maxB = 1000;
        static int numTry = 25;
        static object locker = new object();
        static object locker1 = new object();


        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<long> numbers = new List<long> { 2 };

            bool checkPrime(long prime)
            {
                if (prime > numbers.Last())
                    lock (locker)
                    {
                        generateNewNumbers(prime);
                    }
                return numbers.Contains(prime);
            }

            void generateNewNumbers(long max)
            {
                for (long i = numbers.Last(); i <= max; i++)
                {
                    bool check = true;
                    Parallel.ForEach(numbers, (long num) =>
                    {
                        if (i % num == 0)
                            check = false;
                    });
                    if (check)
                        numbers.Add(i);
                }
            }

            int count = 0;
            int countA = 0;
            int countB = 0;
            Parallel.For(minA, maxA + 1, (int a, ParallelLoopState pls) =>
            {
                for (int b = minB; b < maxB; b++)
                {
                    int n = 0;
                    while (checkPrime((n * n) + (n * a) + b))
                        n++;
                    lock (locker1)
                    {
                        if (n > count)
                        {
                            count = n;
                            countA = a;
                            countB = b;
                        }
                    }
                }
            });

            Console.WriteLine(countA*countB + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
