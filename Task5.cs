namespace Tasks75;

class Grid3d
{
    private int[,,] _grid;
    int X, Y, Z;
    public int[,,] Grid
    {
        get => _grid;
        set => _grid = value;
    }

    public Grid3d(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        _grid = new int[X, Y, Z];
    }
    

    public int this[int x, int y, int z]
    { 
        get{
            if (x < 0 || x >= X || y < 0 || y >= Y || z < 0 || z >= Z)
            {
              throw new IndexOutOfRangeException("Grid out of range");
            }
            return _grid[x, y, z];
        }
        set
        {
            if (x < 0 || x >= X || y < 0 || y >= Y || z < 0 || z >= Z)
            {
                throw new IndexOutOfRangeException("input is out of range");
            }
            _grid[x, y, z] = value;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Grid3d grid =new Grid3d(1,2,3);
        grid[0, 0, 1] = 55;
        Console.WriteLine(grid[0, 0, 1]);
        Console.WriteLine(grid[1,1,1]);
    }
}