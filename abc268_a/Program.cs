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
        var n = Console.ReadLine().Split().Select(e => long.Parse(e)).ToArray();
        int ans = n.Distinct().Count();
        Console.WriteLine($"{ans}");
    }
}
