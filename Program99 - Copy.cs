using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Youtube
{
    class Program99
    {



        static void Main(string[] args)
        {


            Measure("not", 5, () =>
             {
                 for (int i = 0; i < 1000000; i++)
                 {
                     FastObjectAllocator<object>.New();
                 }
             });
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Measure("inline", 5, () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    FastObjectAllocator<object>.NewInline();
                }
            });
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }



        private static void Measure(string what, int reps, Action action)
        {
            action();
            double[] results = new double[reps];
            for (int i = 0; i < reps; ++i)
            {
                Stopwatch sw = Stopwatch.StartNew();
                action();
                results[i] = sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine($"{what} - AVG = {results.Average()}, Min = {results.Min()}, Max = {results.Max()}");

        }


    }
}
