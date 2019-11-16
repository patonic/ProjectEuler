using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Program
    {
        static int min = 1;
        static int max = 20;
        static int numTry = 3;

        static void Main(string[] args)
        {
            for (int i = 0; i < numTry; i++)
                calculating();
            Console.ReadKey();
        }

        static void calculating()
        {
            Stopwatch sw = Stopwatch.StartNew();

            bool[] numbers = new bool[(max-min)+1];
            for (int i = max-1; i >= min; i--)
                for (int j = i-1; j >= min; j--)
                    if (i % j == 0)
                        numbers[j] = true;

            List<int> optimNum = new List<int>();
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] == false)
                    optimNum.Add(i + 1);
            int answer = 0;
            for (int i = 0; answer==0; i++)
            {
                bool check = true;
                foreach (int item in optimNum)
                    if (i % item != 0)
                        check = false;
                
                if (check)
                    answer = i;
            }

            Console.WriteLine(answer + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
