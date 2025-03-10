namespace Task83;

public class Grid
{
    private int[,] grid{get;set;}
    private int Rows{get;set;}
    private int Cols{get;set;}

    public Grid(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        grid = new int[Rows, Cols];
    }

    public int this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
            {
                throw new IndexOutOfRangeException();
            }
            return grid[row, col];
        }
        set
        {
            if (col < Rows && col > -1)
            {
                grid[row, col] = value;
            }
        }
    }

    public int[] GetRow(int row)
    {
        if (row < 0 || row >= Rows)
        {
            throw new IndexOutOfRangeException();
        }
        int[] RowValues = new int[Cols];
        for (int i = 0; i < Rows; i++)
        {
            RowValues[i] = grid[row, i];
        }
        return RowValues;
    }

    public int[] GetCol(int col)
    {
        if (col < 0 || col >= Cols)
        {
            throw new IndexOutOfRangeException();
        }
        int[] ColValues = new int[Rows];
        for (int i = 0; i < Cols; i++)
        {
            ColValues[i] = grid[i, col];
        }
        return ColValues;
    }

    public void Display()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                Console.Write($"{grid[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {   
        Grid grid = new Grid(3, 3);
        Console.WriteLine("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of cols: ");
        int cols = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter numbers of grid: ");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
        grid.Display();
        Console.WriteLine("Enter row that you want to see:");
        int row = int.Parse(Console.ReadLine());
        int[] RowValues=grid.GetRow(row);
        Console.WriteLine($"Row {row}: " + string.Join(", ", RowValues));
        Console.WriteLine("Enter col that you want to see:");
        int col = int.Parse(Console.ReadLine());
        int[] ColValues = grid.GetCol(col);
        Console.WriteLine($"Col {col}: " + string.Join(", ", ColValues));
        
    }
}