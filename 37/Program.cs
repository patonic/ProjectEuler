using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _37
{
    class Program
    {
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

            List<int> numbers = new List<int> { 2 };
            int maxScan = 2;
            List<int> result = new List<int>();

            bool simplicityCheck(string number, bool left)
            {
                bool result = true;

                result = numbers.Contains(int.Parse(number));

                if (result && number.Length > 1)
                {
                    if (left)
                    {
                        if (!simplicityCheck(number.Substring(1), left))
                            result = false;
                    }
                    else
                    {
                        if (result &&
                            !simplicityCheck(number.Substring(0, number.Length - 1), left))
                            result = false;
                    }
                } 

                return result;
            }

            while (result.Count < 11)
            {
                result.Clear();

                for (int i = maxScan + 1; i <= maxScan + 1000000; i++)
                {
                    if (i % 2 == 0)
                        continue;
                    bool check = true;
                    Parallel.ForEach(numbers, (int num, ParallelLoopState pls) =>
                    {
                        if (i % num == 0)
                        {
                            check = false;
                            pls.Break();
                        }
                    });
                    if (check)
                        numbers.Add(i);
                }
                maxScan += 1000000;

                for (int i = numbers.Count - 1; i >= 0 && result.Count < 11; i--)
                {
                    string numberString = numbers[i].ToString();
                    if (simplicityCheck(numberString, true) && simplicityCheck(numberString, false))
                        if (numbers[i] >= 10)
                            result.Add(numbers[i]);
                }
                    
            }

            Console.WriteLine(result.Sum() + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
