using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _22
{
    class Program
    {
        static char[] alphabet = { '_', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static string file = "names.txt";
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

            List<string> names = File.ReadAllText(file).Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < names.Count; i++)
                names[i] = names[i].Trim('"');

            names.Sort();
            UInt64 sum = 0;

            for (int i = 0; i < names.Count; i++)
            {
                int aValue = 0;
                foreach (var item in names[i])
                    aValue += Array.IndexOf(alphabet, item);
                sum = sum + (UInt64)(aValue * (i+1));
            }

            Console.WriteLine(sum + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
