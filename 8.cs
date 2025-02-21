namespace Task8_21;

class Program
{
    public static int Fibonacci(int n){
        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2);
        
    }
    static void Main(string[] args)
    {
        Console.WriteLine("input number");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));

    }
}