using System;

public class WeatherReport
{
    public int Temperature;
    public int Humidity;
    public string WeatherCondition;

    public WeatherReport(int temperature, int humidity, string weatherCondition)
    {
        Temperature = temperature;
        Humidity = humidity;
        WeatherCondition = weatherCondition;
    }

    public void PrintReport()
    {
        Console.WriteLine($"Temperature:  {Temperature} Humidity:  {Humidity}%  WeatherCondition:  {WeatherCondition}");
    }
}

class Program
{
    public static void Main()
    {
        WeatherReport[] reports = new WeatherReport[5];
        {
            reports[0] = new WeatherReport(9, 80, "rain");
            reports[1] = new WeatherReport(10, 70, "rain");
            reports[2] = new WeatherReport(16, 25, "sunny");
            reports[3] = new WeatherReport(17, 24, "sunny");
            reports[4] = new WeatherReport(13, 60, "rain");
        }

        foreach(WeatherReport report in reports)
        {
            report.PrintReport();
        }
    }
}    