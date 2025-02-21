namespace Task4_21;

class Program
{
    public static void TempretureConvert(ref double fahrenheit, out double kelvin, double celsius)
    {
        fahrenheit = (celsius * 9 / 5) + 32;
        kelvin = celsius + 273.15;
    }
    
    static void Main()
    {
        Console.WriteLine("Enter temperature in Celsius");
        double celsius = double.Parse(Console.ReadLine());
        double fahrenheit = 0;
        double kelvin;
        TempretureConvert( ref fahrenheit, out kelvin, celsius);
        Console.WriteLine("Tempreture converted to fahrenheit: {0}", fahrenheit);
        Console.WriteLine("Tempreture converted to kelvin: {0}", kelvin);



    }
}