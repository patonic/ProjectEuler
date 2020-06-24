using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _25
{
    class Program
    {
        static string[] alphabet = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static int pos = 1000000;
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

            

            Console.WriteLine(1 + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
