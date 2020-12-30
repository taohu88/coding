using System;
using System.Collections;
using System.Collections.Generic;

namespace SumProblem
{
    class Program
    {

        static List<Tuple<T, T>> FindSum<T>(List<T> aList, T target )
        {
            var r = new List<Tuple<T, T>>();

            for (var i = 0; i < aList.Count; ++i)
            {
                for (var j = i+1; j < aList.Count; ++j)
                {
                    if (((dynamic)aList[i] + (dynamic)aList[j]) == target)
                    {
                        r.Add(new Tuple<T, T>(aList[i], aList[j]));
                    }
                }
            }
            return r;
        }

        static List<Tuple<T, T>> FastSum<T>(List<T> aList, T target)
        {
            var r = new List<Tuple<T, T>>();
            var h = new Dictionary<T, T>();

            foreach (var x in aList)
            {
                var y = (dynamic)target - (dynamic)x;
                if (h.ContainsKey(y))
                {
                    r.Add(new Tuple<T, T>(y, x));
                }
                h.TryAdd(x, x);
            }
            return r;
        }

        static void Main(string[] args)
        {
            var numL = new List<int>();
            var r = new Random();
            for (var i = 0; i < 20; ++i)
            {
                numL.Add(r.Next(100));
            }

            foreach (var item in numL)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();

            var target = r.Next(100);
            Console.WriteLine($"Target is {target}");

            var results = FastSum(numL, target);
            foreach (var item in results)
            {
                Console.WriteLine($"{item}");
            }

            //var testPerf = new TestArrayVsListPerformance();
            //var t = testPerf.Test();
            //Console.WriteLine(t);
        }
    }
}
