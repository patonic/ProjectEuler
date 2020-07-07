using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _36
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

            ulong sum = 0;
            Parallel.For(1, max, (int x, ParallelLoopState pls) =>
            {
                bool good = true;
                string base10 = Convert.ToString(x, 10);
                for (int i = 0; i < base10.Length/2 && good; i++)
                    if (base10[i] != base10[base10.Length - (i + 1)])
                        good = false;
                string base2 = Convert.ToString(x, 2);
                for (int i = 0; i < base2.Length / 2 && good; i++)
                    if (base2[i] != base2[base2.Length - (i + 1)])
                        good = false;
                if (good)
                    lock (locker)
                        sum += (ulong)x;
            });

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
