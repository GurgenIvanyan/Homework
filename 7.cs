namespace Task7_21;

class Program
{
    static void Main()
    {
        Console.WriteLine("input number a");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("input number b");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("input number c");
        double c = double.Parse(Console.ReadLine());
        double root1 = 0;
        double root2;
        bool valid;
        QuadraticRoot(a, b, c, ref root1, out root2, out valid);
        if (valid)
        {
            Console.WriteLine("Root1 = " + root1);
            Console.WriteLine("Root2 = " + root2);
        }
        else
        {
            Console.WriteLine("no real root");
        }

    }
    public static void QuadraticRoot(double a,double b,double c, ref double root1,out double root2,out bool valid){
        double diskrimininant = (b * b) - (4 * a * c);
        if (diskrimininant >= 0)
        {
            root1 = (-b + Math.Sqrt(diskrimininant)) / (2 * a);
            root2 = (-b - Math.Sqrt(diskrimininant)) / (2 * a);
            valid = true;
        }
        else
        {
            root1 = 0;
            root2 = 0;
            valid = false;
        }
    }
}