using System;
using System.Collections.Generic;
using System.Collections;
namespace ListT;

public class MyList<T> : IEnumerable<T>, ICloneable
{
    private T[] _array;
    public int _count;

    public MyList(int capacity=4)
    {
        _array = new T[capacity];   
        _count = 0;
    }
    public int Count =>_count;

    public void Add(T item)
    {
        EnsureCapacity();
        _array[_count++] = item;
    }

    public bool Remove(T item)
    {
     int index=IndexOf(item);
     if (index == -1)
     {
         return false;
     }
     RemoveAt(index);
     return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
        _array[--_count] = default;
    }

    public bool Contains(T item)
    {
        if (item == null)
        {
            return false;
        }
        return IndexOf(item) != -1;
    }

    public void Insert(int index, T item)
    {
        EnsureCapacity();
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = _count; i > index; i--)
        {
            _array[i] = _array[i - 1];
        }
        _array[index] = item;
        _count++;
    }

    public int BinarySearch(T item, IComparer<T> comparer)
    {
        comparer??= Comparer<T>.Default;
        int Left=0, Right=_count-1;
        while (Left <= Right)
        {
            int mid= (Left + Right) / 2;
            int comparison = comparer.Compare(_array[mid], item);
            if(comparison == 0) return mid; 
            if(comparison < 0) Left = mid + 1;
            else Right = mid - 1;
        }

        return -1;
    }
    public IEnumerator<T> GetEnumerator(){
        for (int i = 0; i < _count; i++)
        {
            yield return _array[i];
        } 
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public object Clone()
    {
        MyList<T> copy = new MyList<T>(_array.Length);
        for (int i = 0; i < _array.Length; i++)
        {
            copy.Add(_array[i]);
        }
        return copy;
    }
    private void EnsureCapacity()
    {
        if (_count == _array.Length)
        {
         T[] newArray = new T[_array.Length * 2];
         Array.Copy(_array, newArray, _array.Length);
         _array = newArray;
        }
    }

    private int IndexOf(T item)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if(EqualityComparer<T>.Default.Equals(_array[i], item)) return i;
        }
        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}