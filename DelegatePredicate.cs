using System;
using System.Collections.Generic;
namespace DelegagtePredicate;

class Program
{
    public delegate bool Predicate<in T>(T obj);

    public static List<T> Filter<T>(List<T> list, Predicate<T> predicate)
    {
        List<T> result = new List<T>();
        foreach (T obj in list)
        {
            if(predicate(obj))
                result.Add(obj);
        }
        return result;
    }

    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> EvenNumbers = Filter(numbers, x => x % 2 == 0);
        foreach(int number in EvenNumbers)
            Console.WriteLine(number);
        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Anna" };
        List<string> FilteredNames = Filter(names, x=>x.StartsWith("A"));
        foreach(string name in FilteredNames)
            Console.WriteLine(name);
    }
}