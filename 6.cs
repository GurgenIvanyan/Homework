namespace Task6_21;

class Program
{
    public static int Calculate(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }
    static void Main(string[] args)
    {
        int[] numbers= new int[5];
        for (int i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(Calculate(numbers));
        
    }
}