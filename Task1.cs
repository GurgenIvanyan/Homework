using System;

public class DynamicIntArray
{
    private int[] _items;
    private int _count;

    public DynamicIntArray(int initialCapacity = 4)
    {
        _items = new int[initialCapacity];
        _count = 0;
    }
    
    public int Length => _count;

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Index is out of range.");
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Index is out of range.");
            _items[index] = value;
        }
    }

    
    public void Add(int item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[_count++] = item;
    }

    public bool Remove(int item)
    {
        int index = Array.IndexOf(_items, item, 0, _count);
        if (index == -1)
            return false; 

        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[--_count] = 0;
        
        if (_count > 0 && _count == _items.Length / 4)
        {
            Resize(_items.Length / 2);
        }

        return true;
    }
    private void Resize(int newCapacity)
    {
        int[] newArray = new int[newCapacity];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }
}

public class Program
{
    public static void Main()
    {
        
        var array = new DynamicIntArray();
        array.Add(10);
        array.Add(20);
        array.Add(30);

        Console.WriteLine("Array numbers:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }

        Console.WriteLine("Removing 20:");
        array.Remove(20);

        Console.WriteLine("Array numbers after removal:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
        
    }
}
