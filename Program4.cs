//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;

//namespace Youtube
//{
//    class Program
//    {

//        static int[] bytes = new int[20480];
//        static void BaselineArray()
//        {
//            int length = bytes.Length;
//            for (int i=0;i< length; i++)
//                {
//                    bytes[i] = (byte)i;
//                }
            
//        }

//        static unsafe void UnsafeArray() //nie sprawdza czy jestesmy poza zasiegiem
//        {

//            int length = bytes.Length; 
//                fixed (int* pBytes = bytes)
//                {
//                int* ptr = pBytes;
//                    for (int i = 0; i < length; i++)
//                    {
//                    byte* bptr = (byte*)&(*ptr);

//                    *(bptr + 0) = 0;
//                    *(bptr + 1) = 0;
//                    *(bptr + 2) = 0;
//                    *(bptr + 3) = 0;

//                    *ptr = (byte)i;
//                        ptr++;
//                    }
//                }
           
//        }
//        static void Main(string[] args)
//        {
//            Measure("baseline", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i) 
//                { BaselineArray(); }

//                        });


//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            Measure("unsafeArray", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { UnsafeArray(); }

//            });
//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

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
