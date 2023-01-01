//using System;
//using System.Diagnostics;
//using System.Linq;

//namespace Youtube
//{
//    class Program
//    {

//        object TestProperty
//        {
//            get;
//            set;

//        }


//       static void Main(string[] args)
//        {
//            int reps = 5;
//            int its = 10000;
//            Measure("createNative", reps, () =>
//            {
//                for (int i = 0; i < its; ++i) {createNative(); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();

//            Measure("createObjects", reps, () =>
//            {
//                for (int i = 0; i < its; ++i) { create<object>(); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();
//            Type objType = typeof(Object);
//            Measure("createReflect", reps, () =>
//            {
//                for (int i = 0; i < its; ++i) { createReflect(objType); }

//            });

//            GC.Collect();
//            GC.WaitForPendingFinalizers();
//            GC.Collect();
            
//            Measure("createIL", reps, () =>
//            {
//                for (int i = 0; i < its; ++i)
//                { 
//                    FastObjectAllocator<object>.New();
                   
//                }

//            });

//        }

//        static T create<T>() where T : new()
//        { return new T(); }

//        static object createNative()
//        { return new object(); }

//        static object createReflect(Type t)
//        {
//            return Activator.CreateInstance(t);
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
