using System.Collections;

namespace ArrayListImplementation;

class MyArrayList : ICloneable, IEnumerable
{
    private object[] _items;
    private int _count;

    public MyArrayList(int capacity = 4)
    {
        _items = new object[capacity];
        _count = 0;
    }

    public int Count => _count;

    public void Add(object item)
    {
        EnsureCapacity();
        _items[_count++] = item;
    }

    public bool Remove(object item)
    {
        int index = IndexOf(item);
        if (index >= 0 || index < _count)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
            
        }
        _items[--_count] = null;

    }

    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }

    public void Insert(int index, object item)
    {
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException();
        }

        EnsureCapacity();
        for (int i = _count; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[index] = item;
        _count++;
    }

    public int BinarySearch(object item, IComparer comparer = null)
    {
        comparer ??= Comparer.Default;
        int Left = 0, Right = _count - 1;
        while (Left <= Right)
        {
            int middle = (Left + Right) / 2;
            int comparison = comparer.Compare(_items[middle], item);
            if (comparison == 0) return middle;
            if (comparison < 0)  Left = middle + 1;
            else Right = middle - 1;
        }

        return -1;
    }

    private void EnsureCapacity()
    {
        if (_count == _items.Length)
        {
            object[] newItems = new object[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
    }

    private int IndexOf(object item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (Equals(_items[i], item))
                return i;
        }

        return -1;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    public object Clone()
    {
        var clone = new MyArrayList(_items.Length);
        for (int i = 0; i < _count; i++)
        {
            clone.Add(_items[i]);
        }
        return clone;
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        var list = new MyArrayList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Insert(1, 10);

        Console.WriteLine("List items:");
        foreach (var item in list)
            Console.WriteLine(item);

        Console.WriteLine("Contains 10: " + list.Contains(10));
        Console.WriteLine("Binary Search (10): " + list.BinarySearch(10));

        list.RemoveAt(1);
        Console.WriteLine("After removing index 1:");
        foreach (var item in list)
            Console.WriteLine(item);
    }
}