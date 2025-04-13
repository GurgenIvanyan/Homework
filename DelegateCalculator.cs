namespace DelegateBasicCalculator;

class Program
{
    public delegate double Operation(double a, double b);
    public static double Add(double a, double b) => a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
           Console.WriteLine("Division by zero");
        }
        return a / b;
    }
    
    static void Main(string[] args)
    {
        Operation operation = null;
        Console.WriteLine("Enter numbers");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter operation: ");
        Console.Write("1=Add\n2=Subtract\n3=Multiply\n4=Divide");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                operation = Add;
                break;
            case 2:
                operation = Subtract;
                break;
            case 3:
                operation = Multiply;
                break;
            case 4:
                operation = Divide;
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
        double result = operation(a,b);
        Console.WriteLine($"The result is: {result}");

    }
}