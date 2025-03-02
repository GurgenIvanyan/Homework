public class WaterTank
{
    private double Capacity { get; }
    public double CurrentLevel;

    public WaterTank(double capacity, double level)
    {
        Capacity = capacity;
        CurrentLevel = level;
    }

    public static WaterTank operator +(WaterTank a, WaterTank b)
    {
        double newLevel = a.CurrentLevel + b.CurrentLevel;
        if (newLevel <= a.Capacity)
        {
            return new WaterTank(a.Capacity, newLevel);
        }
        else
        {
            Console.WriteLine("Cannot add more than capacity");
            return a;
        }
    }

    public static WaterTank operator -(WaterTank a, double liters)
    {
        double newLevel2 = a.CurrentLevel - liters;
        if (newLevel2 >= 0)
        {
            return new WaterTank(a.Capacity, newLevel2);
        }
        else
        {
            Console.WriteLine("Cannot subtract more than current level");
            return a;
        }
    }

    public override string ToString()
    {
        return $"Capacity: {Capacity}, CurrentLevel: {CurrentLevel}";
    }
}


class Program
{
    static void Main()
    {
        WaterTank waterTank1 = new WaterTank(100, 50);
        WaterTank waterTank2 = new WaterTank(100, 30);
        WaterTank newWaterTank = waterTank1 + waterTank2;
        Console.WriteLine(newWaterTank);
        WaterTank waterTank3 = newWaterTank - 60;
        Console.WriteLine(waterTank3);

    }
}

