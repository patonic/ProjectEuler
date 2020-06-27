using System;
using System.Diagnostics;
using System.Numerics;

namespace _25
{
    class Program
    {
        static int lenght = 100000;
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

            int n = 1;
            bool flag = true;
            BigInteger aNum = 1;
            BigInteger bNum = 0;

            while ((flag && (int)Math.Floor(BigInteger.Log10(aNum) + 1) < lenght) || (!flag && (int)Math.Floor(BigInteger.Log10(bNum) + 1) < lenght))
            {
                if (flag)
                    bNum += aNum;
                else
                    aNum += bNum;
                n++;
                flag = !flag;
            }

            /*BigInteger cNum = 0;
            while ((int)Math.Floor(BigInteger.Log10(aNum) + 1) < lenght)
            {
                cNum = aNum;
                aNum += bNum;
                bNum = cNum;
                n++;
            }*/

            Console.WriteLine(n + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
