using System;
using System.Collections.Generic;
using System.Collections;
namespace QueueT;

class MyQueue<T> : IEnumerable<T>
{
    private T[] _array;
    private int _head;
    private int _tail;
    private int _size;

    public MyQueue(int capacity = 4)
    {
        _array = new T[capacity];
        _head = 0;
        _tail = 0;
        _size = 0;
    }
    public int Size => _size;

    public void Enqueue(T item)
    {
        EnsureCapacity();
        _array[_tail] = item;
        _tail = (_tail + 1) % _array.Length;
        _size++;
    }

    public T Dequeue()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        T item = _array[_head];
        _array[_head] = default;
        _head = (_head + 1) % _array.Length;
        _size--;
        return item;
    }

    public T Peek()
    {
        return _array[_head];
    }

    private void EnsureCapacity()
    {
        if (_size == _array.Length)
        {
            T[] newArray = new T[_size * 2];
            Array.Copy(_array, newArray, _size);
            _array = newArray;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _size; i++)
        {
            yield return _array[_head+i % _array.Length];
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