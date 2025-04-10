using System;
using System.Collections.Generic;

namespace ManagedCache
{
    class Program
    {
        public static (Func<int, bool> IsPrime, Action ClearCache) ManagedCache()
        {
            var cache = new Dictionary<int, bool>();
            Func<int, bool> IsPrime = (number) =>
            {
                if (cache.ContainsKey(number))
                {
                    Console.WriteLine($"Found prime cache: {number}"); 
                    return cache[number];
                }

                if (number <= 1)
                {
                    cache[number] = false; 
                    return false;
                }

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        cache[number] = false; 
                        return false;
                    }
                }

                cache[number] = true; 
                return true;
            };
            Action ClearCache = () =>
            {
                cache.Clear();
                Console.WriteLine("Cache cleared."); 
            };

            
            return (IsPrime, ClearCache);
        }

        static void Main(string[] args)
        {
            var fn = ManagedCache();
            Console.WriteLine(fn.IsPrime(13));  
            Console.WriteLine(fn.IsPrime(13));  
            fn.ClearCache();
            Console.WriteLine(fn.IsPrime(13));  
        }
    }
}