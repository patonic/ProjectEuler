using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _10
{
    class Program
    {
        static int maxNum = 2000000;
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

            double number = 2;
            List<int> numbers = new List<int> { 2 };
            for (int i = 3; i < maxNum; i += 2)
            {
                bool check = true;
                Parallel.ForEach(numbers, (int num) =>
                {
                    if (i % num == 0)
                        check = false;
                });
                if (check)
                    numbers.Add(i);
            }

            BigInteger sum = 0;
            foreach (BigInteger item in numbers)
                sum += item;

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
