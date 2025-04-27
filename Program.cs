namespace ConsoleApp16;
    public abstract class Brush
    {
        public abstract void Draw();
    }

    
    public class PencilBrush : Brush
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing pencil");
        }
    }
    public class InkBrush : Brush
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing ink");
        }
    }
    public class PaintBrush : Brush
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing paint");
        }
    }
    public abstract class BrushFactory
    {
        public abstract Brush CreateBrush();
    }
    public class PencilBrushFactory : BrushFactory
    {
        public override Brush CreateBrush()
        {
            return new PencilBrush();
        }
    }

    public class InkBrushFactory : BrushFactory
    {
        public override Brush CreateBrush()
        {
            return new InkBrush();
        }
    }

    public class PaintBrushFactory : BrushFactory
    {
        public override Brush CreateBrush()
        {
            return new PaintBrush();
        }
    }
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select Brush: pencil / ink / paint");
        string tool = Console.ReadLine()?.ToLower();

        BrushFactory factory = tool switch
        {
            "pencil" => new PencilBrushFactory(),
            "ink"    => new InkBrushFactory(),
            "paint"  => new PaintBrushFactory(),
            _        => throw new ArgumentException()
        };
        Brush brush = factory.CreateBrush();
        brush.Draw();
    }
}