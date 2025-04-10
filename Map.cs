namespace Map;

public static class ListExtensions
{
    public static List<T> Map<T>(this List<T> list, Func<T, T> transformer)
    {
        List<T> result = new List<T>();
        foreach (var element in list)
        {
            result.Add(transformer(element));
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>{1,2,3,4,5,6,7,8,9,10};
        var tmp = numbers.Map(a => a += 1);
        Console.WriteLine(tmp[2]);
    }
}