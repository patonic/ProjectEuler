using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static long number = 600851475143;
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

            List<long> numbers = new List<long>();
            Parallel.For(2, number / 2, delegate (long i)
            {
                if (number % i == 0)
                {
                    bool check = false;
                    for (long j = 2; j < i && !check; j++)
                        if (i % j == 0)
                            check = true;
                    if (!check)
                        numbers.Add(i);
                }
            });

            Console.WriteLine(numbers.Max() + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
