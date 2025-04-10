using System;
using System.Collections.Generic;
namespace Memoize;

class Program
{
    public static Func<int, int> Memoize(Func<int, int> func)
    {
        var cache = new Dictionary<int, int>();
        return (int input) =>
        {
            if (cache.ContainsKey(input))
            {
                Console.Write("From Cache: ");
                return cache[input];
            }

            var result = func(input);
            cache.Add(input, result);
            return result;
        };
    }

    public static int factorial(int n)
    {
        if (n == 0) return 1;
        return n * factorial(n - 1);
    }

    static void Main(string[] args)
    {
        var memoFac = Memoize(factorial);
        Console.WriteLine(memoFac(5));  
        Console.WriteLine(memoFac(5));
    }
}