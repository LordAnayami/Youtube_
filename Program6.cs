//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Youtube
//{
//    class Program
//    // gdy data trafia do tego samej zmiennej w obydwu przypadkach
//    {

//        private static ThreadLocal<int> threadData = new ThreadLocal<int>(() => 
//        { return 0; }
//        ); // gdy bez tego tylko static int threadData; to daje 2 lub 1  w zależności co skończyło się później


            



//        static void Main(string[] args)
//        {

//            Task t1 = Task.Factory.StartNew(() =>
//            {
//                threadData.Value = 1;


//            });

//            Task t2 = Task.Factory.StartNew(() =>
//            {
//                threadData.Value = 2;


//            });

//            t1.Wait();
//            t2.Wait();


//            Console.WriteLine(threadData);
//        }
//        private static void Measure(string what, int reps, Action action)
//        {
//            action();
//            double[] results = new double[reps];
//            for (int i = 0; i < reps; ++i)
//            {
//                Stopwatch sw = Stopwatch.StartNew();
//                action();
//                results[i] = sw.Elapsed.TotalMilliseconds;
//            }
//            Console.WriteLine($"{what} - AVG = {results.Average()}, Min = {results.Min()}, Max = {results.Max()}");

//        }
//    }



//}
