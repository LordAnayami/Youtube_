//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace Youtube
//{
//    class Program99
//    {

//        public class TestObject
//        { public int Data = 0; }

//        public class Manager
//        {
//            private List<TestObject> items = new List<TestObject>();
//            public void Add(TestObject o)
//            {
//                items.Add(o);
//            }

//            public void Remove(TestObject o)
//            {
//                items.Remove(o);
//            }

//            public void Update()
//            {
//                foreach (var o in items)
//                {
//                    Console.WriteLine(o.Data);
//                }
//            }


//        }

//        public class WeakManager
//        {
//            private List<WeakReference<TestObject>> items = new List<WeakReference<TestObject>>();
//            public void Add(TestObject o)
//            {
//                WeakReference<TestObject> weakRef = new WeakReference<TestObject>(o);
//                items.Add(weakRef);
//            }

           

//            public void Update()
//            {
//                List<WeakReference<TestObject>> delList = new List<WeakReference<TestObject>>();
//                foreach (WeakReference<TestObject> weak in items)
//                {
//                    TestObject o;
//                    if (weak.TryGetTarget(out o))
//                    {
//                        Console.WriteLine(o.Data);
//                    }
//                    else
//                    {
//                        delList.Add(weak);
//                        Console.WriteLine("Deleted");
//                    }
//                    foreach(var weak2 in delList)
//                    {
//                        items.Remove(weak2);
//                    }
//                }
//            }


//        }


//        static Manager mgr = new Manager();
//        static WeakManager Weakmgr = new WeakManager();

//        static int counter = 0;
//        static public void AddToManager(TestObject o)
//        {
//            mgr.Add(o);

//        }
//         static public TestObject newObject()
//        {
//            TestObject o = new TestObject();
//            o.Data = counter++;
//            return o;
//        }


//        static void TestManager()
//        {
//            var o1 = newObject();
//            var o2 = newObject();
//            var o3 = newObject();

//            mgr.Add(o1);
//            mgr.Add(o2);
//            mgr.Add(o3);


          
//        }
//        static void TestWeakManager()
//        {
//            var o1 = newObject();
//            var o2 = newObject();
//            var o3 = newObject();

//            mgr.Add(o1);
//            mgr.Add(o2);
//            mgr.Add(o3);

//            o1 = null;
//            o2 = null;
//            o3 = null;

//        }


//        static void Main(string[] args)
//        {
            

//            while (true)
//            {
//                Console.WriteLine("dumping manager");
//                mgr.Update();
//                Console.WriteLine("dumping weakmanager");
//                mgr.Update();

//                Thread.Sleep(1000);

//                var x = new byte[1000];
//                x[500] = 0;
//            }
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
