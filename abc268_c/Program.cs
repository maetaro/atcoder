using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
 
class Program
{
    static void Main(string[] args)
    {
        var n = long.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(e => long.Parse(e)).ToList();

        long max = 0L;
        for (int 試行回数 = 0; 試行回数 < n; 試行回数++)
        {
            long count = 0L;
            // for (long i = 0; i < n; i++)
            // {
            //     var 人 = i;
            //     var 料理 = p.IndexOf(i);
            //     var 人a = Get料理(i - 1, n);
            //     var 人b = Get料理(i    , n);
            //     var 人c = Get料理(i + 1, n);
            //     // Console.WriteLine($"{人} {料理} {人a} {人b} {人c}");
            //     bool ok = false;
            //     foreach (var item in new[] { 人a, 人b, 人c })
            //     {
            //         if (料理 == item)
            //         {
            //             // Console.WriteLine($"  {人} {料理} {item}");
            //             ok = true;
            //             break;
            //         }
            //     }
            //     if (ok)
            //     {
            //         count++;
            //     }
            // }
            for (int pIndex = 0; pIndex < p.Count; pIndex++)
            {
                var i = p[pIndex];
                var 人 = i;
                var 料理 = pIndex;
                var 人a = Get料理(i - 1, n);
                var 人b = Get料理(i    , n);
                var 人c = Get料理(i + 1, n);
                // Console.WriteLine($"{人} {料理} {人a} {人b} {人c}");
                bool ok = false;
                foreach (var item in new[] { 人a, 人b, 人c })
                {
                    if (料理 == item)
                    {
                        // Console.WriteLine($"  {人} {料理} {item}");
                        ok = true;
                        break;
                    }
                }
                if (ok)
                {
                    count++;
                }
            }
            max = Math.Max(max, count);
            if (max == n)
            {
                break;
            }
            var last = p.Last();
            p.RemoveAt(p.Count - 1);
            p.Insert(0, last);
        }

        var ans = max;
        Console.WriteLine($"{ans}");
    }
    private static long Get料理(long i, long n)
    {
        var x = i % n;
        if (x < 0)
        {
            return x + n;
        }
        return x;
    }
}
