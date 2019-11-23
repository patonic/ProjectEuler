using System;
using System.Diagnostics;

namespace _19
{
    class Program
    {
        static DateTime minDate = new DateTime(1901, 1, 1);
        static DateTime maxDate = new DateTime(2000, 12, 31);
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

            DateTime time = minDate;
            uint count = 0;
            while (time <= maxDate)
            {
                if (time.DayOfWeek == DayOfWeek.Sunday)
                    count++;
                time = time.AddMonths(1);
            }

            Console.WriteLine(count + " (" + sw.ElapsedMilliseconds + "ms)");
            sw.Stop();
        }
    }
}
