using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace _32
{
    class Program
    {
        static int score = 200;
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

            

            Console.WriteLine(rec(score) + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
