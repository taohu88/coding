using System.Collections.Generic;

namespace SumProblem
{
    class TestArrayVsListPerformance
    {
        private const int NumIterations = 10000;
        private const int Length = 10000;

        public string Test()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            int sum;
            var array = new int[Length];
            var list = new List<int>(Length);
            for (var i = 0; i < Length; ++i)
            {
                array[i] = i;
                list.Add(i);
            }

            stopwatch.Reset();
            stopwatch.Start();
            for (var it = 0; it < NumIterations; ++it)
            {
                sum = 0;
                for (var i = 0; i < Length; ++i)
                {
                    sum += array[i];
                }
            }
            var arrayReadTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var it = 0; it < NumIterations; ++it)
            {
                for (var i = 0; i < Length; ++i)
                {
                    array[i] = i;
                }
            }
            var arrayWriteTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var it = 0; it < NumIterations; ++it)
            {
                sum = 0;
                for (var i = 0; i < Length; ++i)
                {
                    sum += list[i];
                }
            }
            var listReadTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            for (var it = 0; it < NumIterations; ++it)
            {
                for (var i = 0; i < Length; ++i)
                {
                    list[i] = i;
                }
            }
            var listWriteTime = stopwatch.ElapsedMilliseconds;

            string report =
                "Test,Array Time,List Time\n"
                + "Read," + arrayReadTime + "," + listReadTime + "\n"
                + "Write," + arrayWriteTime + "," + listWriteTime;
            return report;
        }
    }
}
