using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _35
{
    class Program
    {
        static int max = 1000000;
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

            List<int> numbers = new List<int> { 2 };
            for (int i = numbers.Last(); i < max; i++)
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

            int count = 0;
            Parallel.For(1, max, (int x, ParallelLoopState pls) =>
            {
                string num = x.ToString();
                bool good = true;
                for (int i = 0; i < num.Length; i++)
                {
                    if (num.Length > 1)
                        num = num.Substring(1) + num[0];
                    int numI = int.Parse(num);
                    if (!numbers.Contains(numI))
                        good = false;
                    if (!good)
                        break;
                }
                if (good)
                    lock (locker)
                        count++;
            });

            Console.WriteLine(count + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
