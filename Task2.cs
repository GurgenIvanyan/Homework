

namespace Task92;

public abstract class Vehicle
{
    public string Brand { get; set; } 
    abstract public void Move();
    abstract public void ConsumeFuel();

    public Vehicle(string brand)
    {
        Brand = brand;
    }
}

public class LandVehicle : Vehicle
{
    public LandVehicle(string brand) : base(brand){}
    
    public override void Move()
    {
        Console.WriteLine($"The {Brand} is moving on the ground");
    }

    public override void ConsumeFuel()
    {
        Console.WriteLine($"The {Brand} is consuming petrol");
    }
}

public class WaterVehicle : Vehicle
{
    public WaterVehicle(string brand) : base(brand){}
    public override void Move()
    {
        Console.WriteLine($"The {Brand} is moving on the water");
        
    }

    public override void ConsumeFuel()
    {
        Console.WriteLine($"The {Brand} is consuming fuel");
    }
}

public class AirVehicle : Vehicle
{
    public AirVehicle(string brand) : base(brand){}
    public override void Move()
    {
        Console.WriteLine($"The {Brand} is moving on the air");
    }

    public override void ConsumeFuel()
    {
        Console.WriteLine($"The {Brand} is consuming disel");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of each vehicle type
        LandVehicle landVehicle = new LandVehicle("Toyota");
        WaterVehicle waterVehicle = new WaterVehicle("Yacht");
        AirVehicle airVehicle = new AirVehicle("Boeing");

        Vehicle[] vehicles = new Vehicle[] { landVehicle, waterVehicle, airVehicle };

       
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
            vehicle.ConsumeFuel();
        }
    }
}