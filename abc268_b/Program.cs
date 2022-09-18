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
        var s = Console.ReadLine();
        var t = Console.ReadLine();
        var ans = t.StartsWith(s) ? "Yes" : "No";
        Console.WriteLine($"{ans}");
    }
}
