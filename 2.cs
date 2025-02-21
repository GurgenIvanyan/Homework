namespace Task2_21;

class Program
{
    public static void SwapNumbers(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }
    public static void Main()
    {
       
        Console.WriteLine("Enter first number: ");
       int first = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        int second = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"first and second number before swapping: {first} {second} ");
        SwapNumbers(ref first, ref second);
        Console.WriteLine($"first and second number after swapping: {first} {second} ");
        
    }
}