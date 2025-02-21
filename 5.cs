namespace Task5_21;

class Program
{
    public static void CalculateArea(ref double area, out double perimeter, double radius)
    {
        area = Math.PI * radius * radius;
        perimeter = 2 * Math.PI * radius;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter radius: ");
        double radius = double.Parse(Console.ReadLine());
        double area = 0;
        double perimeter;
        CalculateArea(ref area, out perimeter, radius);
        Console.WriteLine($"Area = {area}");    
        Console.WriteLine($"Perimeter = {perimeter}");
    }
}