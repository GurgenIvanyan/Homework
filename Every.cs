namespace Every;

public static class ListExtensions
{
    public static bool Every<T>(this List<T> list, Func<T, bool> predicate)
    {
        foreach (T item in list)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>{1,2,3,4,5,6};
        Console.WriteLine(numbers.Every(a=>a > 5 ));
        Console.WriteLine(numbers.Every(a=> a % 2 == 0));
    }
}