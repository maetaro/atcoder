#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 入力
        var x = ReadLineLongItems();
        var h = x[0];
        var w = x[1];
        var a = new List<long[]>();
        for (int i = 0; i < h; i++)
        {
            a.Add(ReadLineLongItems());
        }
 
        var hsum = new List<long>();
        for (int i = 0; i < h; i++)
        {
            var sum = 0L;
            for (int j = 0; j < w; j++)
            {
                sum += a[i][j];
            }
            hsum.Add(sum);
        }
        var wsum = new List<long>();
        for (int j = 0; j < w; j++)
        {
            var sum = 0L;
            for (int i = 0; i < h; i++)
            {
                sum += a[i][j];
            }
            wsum.Add(sum);
        }
        for (int i = 0; i < h; i++)
        {
            var line = new List<long>();
            for (int j = 0; j < w; j++)
            {
                long ans = hsum[i] + wsum[j] - a[i][j];
                line.Add(ans);
            }
            cw(string.Join(" ", line));
        }
    }
    private static long ReadLineLong()
    {
        var line = Console.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            throw new Exception($"{nameof(line)} is empty");
        }
        return long.Parse(line);
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
