using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _34
{
    class Program
    {
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

            int[] factorial = new int[10];
            for (int i = 0; i < 10; i++)
            {
                factorial[i] = 1;
                for (int j = 2; j <= i; j++)
                    factorial[i] *= j;
            }

            int max = 0;
            for (int i = 1; true; i++)
            {
                max = (max * 10) + 9;
                if (max > factorial[9] * i)
                    break;
            }

            int sum = 0;

            Parallel.For(3, max, (int x, ParallelLoopState pls) =>
            {
                int sumNum = 0;
                int copyX = x;
                while (copyX > 0)
                {
                    sumNum += factorial[copyX % 10];
                    if (sumNum > x)
                        break;
                    copyX /= 10;
                }
                if (sumNum == x)
                    lock (locker)
                    {
                        sum += x;
                    }
            });

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
