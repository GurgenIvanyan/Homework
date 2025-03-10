namespace Tasks72;

class Product
{
    private double _price { get; set; }
    private double _stock { get; set; }

    public double Price
    {
        get => _price;
        set => _price = value < 0 ? 0 : value;
    }

    public double Stock
    {
        get => _stock;
        set => _stock = value < 0 ? 10 : value;
    }

    public Product(double price, double stock)
    {
        Price = price;
        Stock = stock;
    }

    public override string ToString()
    {
        return $"Price: {Price}, Stock: {Stock}";
    }
}


class Program
{
    static void Main()
    {
        Product p1 = new Product(10.0, 20.0);
        Product p2 = new Product(-1, -1);
        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToString());
        
    }
}