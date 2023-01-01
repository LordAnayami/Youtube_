//using System;
//using System.Diagnostics;
//using System.Linq;

//namespace Youtube
//{
//    class Program
//    {
//        public static long FindPrimeNumber(int n)
//        {
//            int count = 0;
//            long a = 2;
//            while (count < n)
//            {
//                long b = 2;
//                int prime = 1;
//                while (b * b <= a)
//                {
//                    if (a % b == 0)
//                    {
//                        prime = 0;
//                        break;
//                    }
//                    b++;
//                }
//                if (prime > 0)
//                    count++;
//                a++;
//            }
//            return (--a);
//        }
        

//        static void Main(string[] args)
//        {
//            int reps = 5;
//            int its = 50000;
            
//            Measure("baseline", reps, () =>
//            {
//                for (int i=0; i < its; i++)
//                {
//                    FindPrimeNumber(45);
//                }
//            });
//
//
//            var memFunc = utils.Momoize<int, long>(FindPrimeNumber);
//            Measure("memo", reps, () =>
//            {
//                for (int i = 0; i < its; i++)
//                {
//                    memFunc(45);
//                }
//            });
//        }
//        private static void Measure (string what, int reps, Action action)
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
