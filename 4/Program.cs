using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static long numDig = 3;
        static int numTry = 1;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<long> numbers = new List<long>();
            long startNumber = Convert.ToInt64(Math.Pow(10, numDig-1));
            Parallel.For(startNumber, Convert.ToInt64(Math.Pow(10, numDig)), delegate (long i)
            {
                Parallel.For(startNumber, Convert.ToInt64(Math.Pow(10, numDig)), delegate (long j)
                {
                    bool check = true;
                    string num = Convert.ToString(i*j);

                    for (int n = 0; n <= num.Length / 2; n++)
                        if (num[n] != num[(num.Length - 1) - n])
                            check = false;
                    if (check)
                        numbers.Add(Convert.ToInt64(num));
                });
            });

            Console.WriteLine(numbers.Max() + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
