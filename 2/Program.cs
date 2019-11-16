using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static int maxNumber = 4000000;
        static int numTry = 50;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Int64 sum = 0;

            Int32 a = 1;
            Int32 b = 0;
            Int32 c = 0;

            while (a <= maxNumber)
            {
                c = a + b;
                b = a;
                a = c;
                if (c % 2 == 0)
                    sum += c;
            }

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
