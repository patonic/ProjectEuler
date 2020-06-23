using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _23
{
    class Program
    {
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

            

            Console.WriteLine(1 + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
