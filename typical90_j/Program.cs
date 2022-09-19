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
        // 1オリジンで扱えるように0要素目はダミー値
        sums1.Add(0L);
        sums2.Add(0L);
        for (long i = 0; i < n; i++)
        {
            var cp = cps[i];
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
        for (int j = 0; j < q; j++)
        {
            var lr = lrs[j];
            int r = (int)lr.r;
            int l = (int)lr.l;
            long ans1 = sums1[r] - sums1[l - 1];
            long ans2 = sums2[r] - sums2[l - 1];
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
