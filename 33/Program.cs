using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _33
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

            static ulong GCD(ulong a, ulong b)
            {
                while (a != 0 && b != 0)
                {
                    if (a > b)
                        a %= b;
                    else
                        b %= a;
                }

                return a == 0 ? b : a;
            }

            List<int> dividend = new List<int>();
            List<int> divider = new List<int>();
            Parallel.For(10, 100, (int x, ParallelLoopState pls) =>
            {
                List<char> listXP = x.ToString().ToList();
                for (int y = x + 1; y < 100; y++)
                {
                    List<char> listX = listXP.ToList();
                    List<char> listY = y.ToString().ToList();
                    bool succes = false;
                    foreach (char item in listXP)
                        if (listY.Remove(item))
                        {
                            if (item == '0')
                                break;
                            listX.Remove(item);
                            succes = true;
                            break;
                        }
                    if (succes)
                        if ((double)x / (double)y == Double.Parse(new string(listX.ToArray())) / Double.Parse(new string(listY.ToArray())))
                        {
                            lock (locker)
                            {
                                dividend.Add(x);
                                divider.Add(y);
                            }
                        }
                }
            });

            ulong x = 1;
            ulong y = 1;
            for (int i = 0; i < dividend.Count; i++)
            {
                x *= (ulong)dividend[i];
                y *= (ulong)divider[i];
            }


            Console.WriteLine((y/GCD(x, y)) + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
