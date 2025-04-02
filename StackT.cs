using System;
using System.Collections.Generic;
using System.Collections;
namespace StackT;

class MyStack<T> : IEnumerable<T>
{
    private T[] _array;
    private int _size;

    public MyStack(int capacity = 4)
    {
        _array = new T[capacity];
        _size = 0;
    }
    public int Size => _size;

    public void Push(T item)
    {
        EnsureCapacity();
        _array[_size++] = item;
    }

    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T item = _array[--_size];
        _array[_size] = default;
        return item;
    }

    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _array[--_size];
    }
    
    public bool IsEmpty => _size == 0;
    private void EnsureCapacity()
    {
        if (_size == _array.Length)
        {
            T[] newArray = new T[_array.Length * 2];
            Array.Copy(_array, newArray, _size);
            _array = newArray;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            yield return _array[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}