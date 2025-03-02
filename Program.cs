namespace Task_7_2;

public class InkReservior
{
    private string Color { get; set; }
    private double InkAmount { get; set; }

    public InkReservior(string color, double inkAmount)
    {
        Color = color;
        InkAmount = inkAmount;
    }

    public static InkReservior operator +(InkReservior a, InkReservior b)
    {
        if (a.Color == b.Color)
        {
            double NewInk = a.InkAmount + b.InkAmount;
            return new InkReservior(a.Color, NewInk);
        }
        else
        {
            Console.Write("the colors are not the same");
            return a;
        }

    }

    public static InkReservior operator -(InkReservior a, double amount)
    {
        double amountOfInk =a.InkAmount - amount;
        if (amountOfInk >= 0)
        {
            return new InkReservior(a.Color, amountOfInk);
        }
        else
        {
            Console.Write("the ink`s amount is not valid");
            return a;
        }
    }

    public override string ToString()
    {
        return $"Color: {Color}, InkAmount: {InkAmount}";
    }
    
}

class Program
{
    static void Main()
    {
        InkReservior inkReservior1 = new InkReservior("Red", 5.0);
        InkReservior inkReservior2 = new InkReservior("Green", 6.0);
        InkReservior inkReservior3 = new InkReservior("Red", 4.0);
        InkReservior newInkReservior = inkReservior1 + inkReservior3;
        Console.WriteLine(newInkReservior);
        InkReservior inkReservior4 = inkReservior2 - 3.0;
        Console.WriteLine(inkReservior4);

    }
}