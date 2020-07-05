using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _32
{
    class Program
    {
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

            string alphabet = "123456789";
            List<int> result = new List<int>();
            Parallel.For(1, (int)Math.Pow(10, alphabet.Length - 2), (int x, ParallelLoopState pls) =>
            {
                List<char> copyAlphabet = alphabet.ToList();
                foreach (char item in x.ToString())
                {
                    if (copyAlphabet.Contains(item))
                        copyAlphabet.Remove(item);
                    else
                        goto endParallel;
                }
            
                for (int y = x+1; y < (int)Math.Pow(10, alphabet.Length - 2); y++)
                {
                    int products = x * y;

                    if (x.ToString().Length + y.ToString().Length + products.ToString().Length != alphabet.Length || result.Contains(products))
                        continue;
                    List<char> copyAlphabet1 = copyAlphabet.ToList();
                    foreach (char item in y.ToString())
                    {
                        if (copyAlphabet1.Contains(item))
                            copyAlphabet1.Remove(item);
                        else
                            goto endFor;
                    }
                    foreach (char item in products.ToString())
                    {
                        if (copyAlphabet1.Contains(item))
                            copyAlphabet1.Remove(item);
                        else
                            goto endFor;
                    }
                    lock (locker)
                    {
                        result.Add(products);
                    }
                    endFor:;
                }
                endParallel:;
            });

            Console.WriteLine(result.Distinct().Count() + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
