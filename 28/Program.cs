using System;
using System.Diagnostics;

namespace _28
{
    class Program
    {
        static int size = 1001;
        static int numTry = 25;


        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            UInt64 sum = 1;
            int inc = 1;
            int incForInc = 0;
            for (int i = 0; i < (size-1)/2; i++)
            {
                incForInc += 2;
                for (int j = 0; j < 4; j++)
                {
                    inc += incForInc;
                    sum += (ulong)inc;
                }
            }

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
