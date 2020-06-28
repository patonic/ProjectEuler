using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _26
{
    class Program
    {
        static int maxNum = 1000;
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

            int len = 0;
            int lenI = 0;
            Parallel.For(2, maxNum+1, (int i, ParallelLoopState pls) =>
            {
                int modulo = 1;
                List<int> num = new List<int>();
                do
                {
                    modulo *= 10;
                    if (num.Contains(modulo))
                        break;
                    num.Add(modulo);
                    modulo = modulo % i;
                } while (modulo != 0);
                if (modulo != 0)
                {
                    int count = num.Count - num.IndexOf(modulo);
                    lock (locker)
                    {
                        if (count > len)
                        {
                            len = count;
                            lenI = i;
                        }
                    }
                }
            });

            Console.WriteLine(lenI + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
