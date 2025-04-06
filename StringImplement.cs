using System.Text;
using System.Collections.Generic;
namespace StringImplement;

static class Extensions
{
    public static List<string> MySplit(this string str, char separator)
    {
        int start = 0;
        List<string> parts = new List<string>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == separator)
            {
                parts.Add(str.Substring(start, i - start));
                start = i + 1;
            }
        }
        parts.Add(str.Substring(start));
        return parts;
    }

    public static int IndexOf(this string str, string search)
    {
        if (str == null || search == null || str.Length == 0 || search.Length > str.Length)
        {
            return -1;
        }
        
        for (int i = 0; i <= str.Length - search.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < search.Length; j++)
            {
                if (str[i + j] != search[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
            {
                return i;
            }
        }
        return -1;
    }

    public static bool Contains(this string str, string search)
    {
        return str.IndexOf(search) != -1;
    }

    public static string Substring(this string str, int start, int length)
    {
        string result = string.Empty;
        for (int i = start; i <= length; i++)
        {
            result += str[i];
        }

        return result;
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        Random random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            int index = random.Next(n--);
            T temp = list[index];
            list[index] = list[n];
            list[n] = temp;
        }
    }

    public static void Reverse<T>(this IList<T> list)
    {
        for (int i = list.Count/2; i >= 0; i--)
        {
            T temp = list[i];
            list[i] = list[list.Count - 1 - i];
            list[list.Count - 1 - i] = temp;
        }
    }

    public static List<T> Slice<T>(this IList<T> list, int start, int length)
    {
        List<T> slice = new List<T>();
        for (int i = start; i < length; i++)
        {
            slice.Add(list[i]);
        }
        return slice;
    }

    public static T TAt<T>(this IList<T> list, int index)
    {
        if (index >= list.Count)
        {
            throw new IndexOutOfRangeException();
        }
        if (index < 0)
        {
            return list[list.Count - index];
        }
        return list[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        string sb = "Anna, has, a Car"; 
        List<string> result =Extensions.MySplit(sb, ',');
        foreach (var part in result) 
        {
            
            Console.WriteLine(part.Trim()); 
        }

        Console.WriteLine(Extensions.IndexOf(sb, "nn"));
        Console.WriteLine(Extensions.Substring(sb,1, 4));
        List<string> workers = new List<string>() { "Anna", "Bob", "Jack" };
        Extensions.Shuffle(workers);
        foreach (string name in workers)
        {
            Console.WriteLine(name);
        }
        Extensions.Reverse(workers);
        foreach (string name in workers)
        {
            Console.WriteLine(name);
        }
    }
}
