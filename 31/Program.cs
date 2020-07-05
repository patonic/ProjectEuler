using System;
using System.Diagnostics;

namespace _31
{
    class Program
    {
        static int score = 200;
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

            int rec(int mod, int maxLevel = 10)
            {
                int res = 0;
                if (mod >= 200 && maxLevel >= 9) //9
                    for (int i = 1; i <= mod/200; i++)
                        res += rec(mod-(200*i), 8);
                if (mod >= 100 && maxLevel >= 8) //8
                    for (int i = 1; i <= mod / 100; i++)
                        res += rec(mod - (100 * i), 7);
                if (mod >= 50 && maxLevel >= 7)  //7
                    for (int i = 1; i <= mod / 50; i++)
                        res += rec(mod - (50 * i), 6);
                if (mod >= 20 && maxLevel >= 6)  //6
                    for (int i = 1; i <= mod / 20; i++)
                        res += rec(mod - (20 * i), 5);
                if (mod >= 10 && maxLevel >= 5)  //5
                    for (int i = 1; i <= mod / 10; i++)
                        res += rec(mod - (10 * i), 4);
                if (mod >= 5 && maxLevel >= 4)   //4
                    for (int i = 1; i <= mod / 5; i++)
                        res += rec(mod - (5 * i), 3);
                if (mod >= 2 && maxLevel >= 3)   //3
                    for (int i = 1; i <= mod / 2; i++)
                        res += rec(mod - (2 * i), 2);
                if (mod >= 1 && maxLevel >= 2)   //2
                    res++;
                if (mod == 0 && maxLevel >= 1)   //1
                    res++;

                return res;
            }

            Console.WriteLine(rec(score) + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
