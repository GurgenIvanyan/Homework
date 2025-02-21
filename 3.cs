namespace Task3_21;

class Program
{
    public static void FindMax(ref int max, params int[] array)
    {
        foreach (int i in array)
        {
            if (i > max)
            {
                max = i;
            }
        }
    }
    
    static void Main(string[] args)
    {
        int[] array = new int[10];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter array element: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        int max = array[0];
        FindMax(ref max, array);
        Console.WriteLine($"Max element is: {max}");
    }
}