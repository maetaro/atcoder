#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
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
