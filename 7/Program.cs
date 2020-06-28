using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _7
{
    class Program
    {
        static int maxNum = 10001; 
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

            List<long> numbers = new List<long> {2};
            for (long i = 3; numbers.Count !=maxNum; i+=2)
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

            Console.WriteLine(numbers[maxNum-1] + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
