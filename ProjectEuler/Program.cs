using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static int[] shearchNumber = new int[] { 3, 5 };
        static int minNumber = 0;
        static int maxNumber = 1000;
        static int numTry = 50;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
        }

        static void calculating() {
            Stopwatch sw = Stopwatch.StartNew();

            Int64 sum = 0;
            Parallel.For(minNumber, maxNumber + 1, delegate (int i)
            {
                bool addSumm = false;
                foreach (int item in shearchNumber)
                    if (i % item == 0)
                        addSumm = true;
                if (addSumm)
                    sum += i;
            });

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
