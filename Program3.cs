//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;

//namespace Youtube
//{
//    class Program
//    {
//        [StructLayout(LayoutKind.Explicit)]
//        struct ByteArray
//        {
//            [FieldOffset(0)]
//            public byte Byte1;
//            [FieldOffset(1)]
//            public byte Byte2;
//            [FieldOffset(2)]
//            public byte Byte3;
//            [FieldOffset(3)]
//            public byte Byte4;
//            [FieldOffset(0)]
//            public int ColorInt1;
//        }

//        static void Main(string[] args)
//        {
//            ByteArray ba;

//            ba.ColorInt1 = 0;
//            ba.Byte1 = 255;
//            ba.Byte2 = 128;
//            ba.Byte3 = 0;
//            ba.Byte4 = 255;
           

//            Console.WriteLine($"B1:{ba.Byte1} B2: {ba.Byte2}, B3: {ba.Byte3}, B4: {ba.Byte4}, I1:{ba.ColorInt1}");
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
