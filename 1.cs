using System;
namespace Task1_21;

class Program
{

    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Sub(int a, int b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static float Divide(int a, int b)
    {
         return  (float)a / b;
        
    }

    static void Calculator()
    {
        while (true)
        {
            Console.WriteLine("Please enter A number: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter B number: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter operation: ");
            char operation = char.Parse(Console.ReadLine());
            if (operation == '+')
            {
                Console.WriteLine(Add(a, b));
            }
            else if (operation == '-')
            {
                Console.WriteLine(Sub(a, b));
            }
            else if (operation == '*')
            {
                Console.WriteLine(Multiply(a, b));
            }
            else if (operation == '/')
            {
                if (b != 0)
                {
                    Console.WriteLine(Divide(a, b));
                }
            }
            Console.WriteLine("press q for continue or x to exit");
            char ContinueOrBreak = char.Parse(Console.ReadLine());
            if (ContinueOrBreak == 'x')
            {
                break;
            }

        }
    }

    public static void Main()
    {
     Calculator();   
    }
}