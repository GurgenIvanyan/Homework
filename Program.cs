namespace arajadranq4;

public abstract class Shape
{
    public abstract double Surface();
    public abstract void Draw();

    public void print()
    {
     Console.WriteLine($"{GetType().Name}   S={Surface()}");
     Console.WriteLine();
     Draw();
    }
}

public class Square : Shape
{
    private double side { get; set; }

    public Square(double side)
    {
        this.side = side;
    }

    public override double Surface()
    {
        return side * side;
    }

    public override void Draw()
    {
        for (int i = 0; i < side; i++)
        {
            for (int j = 0; j < side; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}

public class Rectangle : Shape
    {
        private double Width{ get; set; }
        private double Height{ get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double Surface()
        {
            return Height * Width;
        }

        public override void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }



class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[2];
        shapes[0] = new Square(5);
        shapes[1] = new Rectangle(3, 4);
        foreach (Shape shape in shapes)
        {
            shape.print();
        }
    }
}