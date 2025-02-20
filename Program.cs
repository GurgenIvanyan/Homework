using System;

public class Product
{
    public string Name;
    public int Price;
    public int StockQuantity;

    public Product(string Name, int Price, int StockQuantity)
    {
        this.Name = Name;
        this.Price = Price;
        this.StockQuantity = StockQuantity;
    }

    public void Display()
    {
        Console.WriteLine($"Product Name: {this.Name} Price: {this.Price} Stock Quantity: {this.StockQuantity}");
    }
}

class Program
{
    public static void Main()
    {
        Product product1 = new Product(" Apple", 200, 5);
        Product product2 = new Product(" Orange", 300, 3);
        Product product3 = new Product(" banana", 400, 10);
        product1.Display();
        product2.Display();
        product3.Display();
    }
}