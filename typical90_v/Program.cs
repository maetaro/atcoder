#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // var (a,b,c) = ReadLine().Split();
        var abc = ReadLine(line => line.Split());
        var a = toLong(abc[0]);
        var b = toLong(abc[1]);
        var c = toLong(abc[2]);
        // A,B,Cが等しくなれば正方形と考える。
        // 全ての立方体が同じ大きさになるようにする？
        // 2 2 3 は3回で2 2 2と1 1 1の立方体になるのでは？
        var d = Gcd(a, b);
        // cw($"{d}");
        d = Gcd(d, c);
        // cw($"{d}");
        // cw($"{a} {a/d}");
        // cw($"{b} {b/d}");
        // cw($"{c} {c/d}");
        ulong ans = (ulong)((a / d) - 1)
            + (ulong)((b / d) - 1)
            + (ulong)((c / d) - 1);
        Console.WriteLine($"{ans}");
    }
    private static ulong Gcd(ulong x, ulong y)
    {
        if (x == 0) return y;
        if (y == 0) return x;
        if (x >= y)
        {
            x = x % y;
        }
        else
        {
            y = y % x;
        }
        return Gcd(x, y);
    }
    private static ulong ReadLine()
    {
        return ReadLine(ulong.Parse);
    }
    private static TResult ReadLine<TResult>(Func<string, TResult> selector)
    {
        var line = Console.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            throw new Exception($"{nameof(line)} is empty");
        }
        return selector(line);
    }
    private static IEnumerable<TResult> ReadLines<TResult>(ulong count, Func<string, TResult> selector)
    {
        for (ulong i = 0; i < count; i++)
        {
            var line = Console.ReadLine();
            yield return selector(line);
        }
    }
    private static ulong toLong(string s)
    {
        return ulong.Parse(s);
    }
    private static ulong[] FillArray(int count, ulong value)
    {
        return Enumerable.Range(0, count).Select(e => value).ToArray();
    }
    private static void cw(string value)
    {
        Console.WriteLine(value);
    }
}
