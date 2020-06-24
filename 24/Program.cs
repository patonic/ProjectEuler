using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace _24
{
    class Program
    {
        static string[] alphabet = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static int pos = 1000000;
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

            List<string> mass = alphabet.ToList();
            string result = "";
            int permutationPoints = pos - 1;
            while (mass.Count > 0)
            {
                int fact = FactTree(mass.Count - 1);
                int index = permutationPoints / fact;
                result = result + mass[index];
                mass.RemoveAt(index);
                permutationPoints -= fact * index;
            }

            Console.WriteLine(result + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }

        static int ProdTree(int l, int r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return l * r;
            int m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        static int FactTree(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }
    }
}
