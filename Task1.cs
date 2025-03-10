using System.Drawing;

namespace Task81;

class Array
{
    int[] array = new int[10];
    public int Capacity;
    public int Size;

    public Array(int capacity, int size)
    {
        Capacity = 10;
        Size = size;
        array = new int[Capacity];
    }

    public void Display()
    {
        for (int i = 0; i < Size; i++)
        {
            Console.Write($"{array[i]} ");
        }
    }

    public void Add()
    {
        for (int i = 0; i < Size; i++)
        {
            Console.WriteLine("Enter number");
            array[i] = int.Parse(Console.ReadLine());
        }
        
    } 
    public void AddIndex(int index)
    {
        if (index < 0 || index >= Size)
        {
            throw new IndexOutOfRangeException();
        }
        array[index] = int.Parse(Console.ReadLine());
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= Size)
        {
            throw new IndexOutOfRangeException();
        }
        else if (index == 0)
        {
            for (int i = 0; i < Size-1; i++)
            {
                array[i] = array[i + 1];
            }
        }
        else if (index == Size - 1)
        {
            Size--;
        }
        else
        {
            for (int i = index; i < Size - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Array a = new Array(10,0);
        Console.WriteLine("Enter array size: ");
        a.Size = int.Parse(Console.ReadLine());
        if (a.Size > a.Capacity)
        {
            a.Capacity = a.Size * 2;
            Array b=new Array(a.Capacity,a.Size);
            b.Add();
            b.Display();
            int indexForB=int.Parse(Console.ReadLine());
            b.AddIndex(indexForB);
            int indexForRemoveB=int.Parse(Console.ReadLine());
            b.Remove(indexForRemoveB);
        }
        Console.WriteLine("Enter array elements ");
        a.Add();
        a.Display();
        Console.WriteLine("Enter an index to add element: ");
        int index = int.Parse(Console.ReadLine());
        a.AddIndex(index);
        a.Display();
        Console.WriteLine("Enter an index to remove element: ");
        int indexForRemove=int.Parse(Console.ReadLine());
        a.Remove(indexForRemove);
        a.Display();
    }
}