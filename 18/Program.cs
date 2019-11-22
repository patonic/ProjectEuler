using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _18
{
    class Program
    {
        static string numbers = "75N95 64N17 47 82N18 35 87 10N20 04 82 47 65N19 01 23 75 03 34N88 02 77 73 07 63 67N99 65 04 28 06 16 70 92N41 41 26 56 83 40 80 70 33N41 48 72 33 47 32 37 16 94 29N53 71 44 65 25 43 91 52 97 51 14N70 11 33 28 77 73 17 78 39 68 17 57N91 71 52 38 17 14 91 43 58 50 27 29 48N63 66 04 68 89 53 67 30 73 16 69 87 40 31N04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
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

            List<List<BigInteger>> mass = new List<List<BigInteger>>();
            foreach (string line in numbers.Split("N"))
                mass.Add(line.Split(" ").ToList().ConvertAll(x => BigInteger.Parse(x)));

            List<List<BigInteger>> massPath = new List<List<BigInteger>>();
            massPath.Add(mass[mass.Count - 1]);
            for (int y = mass.Count - 2; y >= 0; y--)
            {
                massPath.Insert(0, new List<BigInteger>());
                for (int x = 0; x <= massPath[1].Count - 2; x++)
                {
                    if (massPath[1][x] > massPath[1][x + 1])
                        massPath[0].Add(massPath[1][x]+ mass[y][x]);
                    else
                        massPath[0].Add(massPath[1][x + 1] + mass[y][x]);
                }
            }

            Console.WriteLine(massPath[0][0] + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
