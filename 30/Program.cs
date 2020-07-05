using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _30
{
    class Program
    {
        static int powY = 5;
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

            int max = 0;

            for (int i = 1; true; i++)
            {
                max = (max * 10) + 9;
                if (max > Math.Pow(9, powY) * i)
                    break;
            }
            //max = (max - 9) / 10;

            ulong result = 0;
            Parallel.For(2, max+1, (int i, ParallelLoopState pls) =>
            {
                int sum = 0;
                foreach (char item in i.ToString())
                {
                    sum += (int)Math.Pow(Double.Parse(item.ToString()), powY);
                }
                if (i == sum)
                    lock (locker)
                    {
                        result += (ulong)sum;
                    }
            });

            Console.WriteLine(result + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
