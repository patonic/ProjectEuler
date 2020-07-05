using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace _29
{
    class Program
    {
        static int minA = 2;
        static int minB = 2;
        static int maxA = 100;
        static int maxB = 100;
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

            List<double> list = new List<double>();
            double res = 0;
            for (int a = minA; a <= maxA; a++)
            {
                for (int b = minB;  b <= maxB; b++)
                {
                    res = Math.Pow(a, b);
                    if (!list.Contains(res))
                        list.Add(res);
                }
            }

            Console.WriteLine(list.Count + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
