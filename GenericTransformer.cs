using System;
using System.Collections.Generic;
namespace GenericTransformer;

class Program
{
    public delegate T Transformer<T>(T input);

    public static List<T> Transform<T>(Transformer<T> transformer,List<T> list)
    {
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            result.Add(transformer(item));
        }
        return result;
    }
    static void Main(string[] args)
    {
        List<string> names = new List<string>() { "john", "bob", "alice" };
        List<string> UpperNames = Transform(s => s.ToUpper(), names);
        foreach (string name in UpperNames)
        {
            Console.WriteLine(name);
        }
        List<int> numbers = new List<int>() { 2, 3, 4};
        List<int> SquareNumbers = Transform(s => s * s, numbers);
        foreach (int number in SquareNumbers)
        {
            Console.WriteLine(number);
        }
        
    }
}