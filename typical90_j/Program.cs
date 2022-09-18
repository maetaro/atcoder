#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = ReadLine();
        var cps = ReadLines(n, line => (c:toLong(line.Split()[0]), p:toLong(line.Split()[1]))).ToArray();
        var q = ReadLine();
        var lrs = ReadLines(q, line => (l:toLong(line.Split()[0]), r:toLong(line.Split()[1]))).ToArray();
        // 一種類のデータを何回も見る。
        // 区間の総和は累積和
        var sums1 = new List<long>();
        var sums2 = new List<long>();
        sums1.Add(0L);
        sums2.Add(0L);
        for (long i = 0; i < n; i++)
        {
            // long temp = 0;
            var cp = cps[i];
            // if (i > 0)
            // {
            //     temp = cps[i - 1].p;
            // }
            long temp1 = i == 0 ? 0 : sums1.Last();
            long temp2 = i == 0 ? 0 : sums2.Last();
            if (cp.c == 1L)
            {
                temp1 += cp.p;
            }
            if (cp.c == 2L)
            {
                temp2 += cp.p;
            }
            sums1.Add(temp1);
            sums2.Add(temp2);
        }
        // for (int i = 0; i < n; i++)
        // {
        //     cw($"{sums2[i]}");
        // }
        for (int j = 0; j < q; j++)
        {
            // long sum1 = 0;
            // long sum2 = 0;
            var lr = lrs[j];
            // long l1 = sums1[((int)lr.r - 1)];
            // long r1 = sums1[((int)lr.l - 1 - 1)];
            int r = (int)lr.r;
            int l = (int)lr.l;
            // if (l <= 0) l = 1;
            // if (r <= 0) r = 1;
            long ans1 = sums1[r] - sums1[l - 1];
            long ans2 = sums2[r] - sums2[l - 1];
            // long l1 = 0;
            // for (long i = lr.l - 1; i >= 1; i--)
            // {
            //     cw($"l1: {i} {l1}");
            //     var cp = csums[(int)i - 1];
            //     if (cp.c == 1L)
            //     {
            //         l1 = cp.csum;
            //         break;
            //     }
            // }
            // long r1 = 0L;
            // for (long i = lr.r; i >= lr.l; i--)
            // {
            //     cw($"r1: {i} {r1}");
            //     var cp = csums[(int)i - 1];
            //     if (cp.c == 1L)
            //     {
            //         r1 = cp.csum;
            //         break;
            //     }
            // }
            // long l2 = 0L;
            // for (long i = lr.l - 1; i >= 1; i--)
            // {
            //     var cp = csums[(int)i - 1];
            //     cw($"l2: {i} {l2}");
            //     if (cp.c == 2L)
            //     {
            //         l2 = cp.csum;
            //         cw($"* l2: {i} {l2}");
            //         break;
            //     }
            // }
            // long r2 = 0L;
            // for (long i = lr.r; i >= lr.l; i--)
            // {
            //     cw($"r2: {i} {r2}");
            //     var cp = csums[(int)i - 1];
            //     if (cp.c == 2L)
            //     {
            //         r2 = cp.csum;
            //         break;
            //     }
            // }
            // sum1 = r1 - l1;
            // // cw($"{sum2} {r2} {l2}");
            // sum2 = r2 - l2;
            // for (long i = lr.l; i <= lr.r; i++)
            // {
            //     var cp = cps[i - 1];
            //     if (cp.c == 1L)
            //     {
            //         sum1 += cp.p;
            //     }
            //     else
            //     {
            //         sum2 += cp.p;
            //     }
            // }
            cw($"{ans1} {ans2}");
        }
    }
    private static long ReadLine()
    {
        var line = Console.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            throw new Exception($"{nameof(line)} is empty");
        }
        return long.Parse(line);
    }
    private static IEnumerable<TResult> ReadLines<TResult>(long count, Func<string, TResult> selector)
    {
        for (int i = 0; i < count; i++)
        {
            var line = Console.ReadLine();
            yield return selector(line);
        }
    }
    private static long toLong(string s)
    {
        return long.Parse(s);
    }
    private static long[] ReadLineLongItems()
    {
        var line = Console.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            throw new Exception($"{nameof(line)} is empty");
        }
        return line.Split().Select(e => long.Parse(e)).ToArray();
    }
    private static long[] FillArray(int count, long value)
    {
        return Enumerable.Range(0, count).Select(e => value).ToArray();
    }
    private static void cw(string value)
    {
        Console.WriteLine(value);
    }
}
