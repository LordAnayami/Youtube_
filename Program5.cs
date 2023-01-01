//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;

//namespace Youtube
//{
//    class Program
//    {
//        public static int TestNewStack(int size, int value)
//        {
//            int[] someNumbers = new int[size];
//            for (int i=0; i< someNumbers.Length; i++)
//            {
//                someNumbers[i] = value;
//            }
//            return someNumbers[value];
//        }
//        public unsafe static int TestAllocStack(int size, int value)
//        {
//            int* someNumbers = stackalloc int[size];

//            //otherFunc(someNumbers);
//            for (int i = 0; i < size; i++)
//            {
//                *(someNumbers +1) = value;
//            }
//            return someNumbers[value];
//        }

//        static void Main(string[] args)
//        { int arraySize = 5000;

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.Batch; //stary garbage collector
            
//            Measure("baseline base", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestNewStack(arraySize, i % arraySize); }

//            });


//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();
            
//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.Interactive; 

//            Measure("baseline interactive", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestNewStack(arraySize, i % arraySize); }

//            });


//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.LowLatency; 

//            Measure("baseline LowLatency", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestNewStack(arraySize, i % arraySize); }

//            });


//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.SustainedLowLatency; 

//            Measure("baseline sustain", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestNewStack(arraySize, i % arraySize); }

//            });


//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.Batch;

//            Measure("stackalloc base", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestAllocStack(arraySize, i % arraySize); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.Interactive;

//            Measure("stackalloc interactive", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestAllocStack(arraySize, i % arraySize); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.LowLatency; //używać tylko gdy trzeba bo wyłącza bc

//            Measure("stackalloc LowLatency", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestAllocStack(arraySize, i % arraySize); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.SustainedLowLatency; //używać tylko gdy trzeba bo wyłącza bc
//            Measure("stackalloc sustain", 5, () =>
//            {
//                for (int i = 0; i < 100000; ++i)
//                { TestAllocStack(arraySize, i % arraySize); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

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
