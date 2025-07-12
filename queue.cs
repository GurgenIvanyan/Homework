using System;

namespace Queue;

public class MyQueue<T>
{      
    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count;

    public MyQueue()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public int Count => _count;

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public void Enqueue(T item)
    {
        Node newNode = new Node(item);

        if (_tail != null)
        {
            _tail.Next = newNode;
        }

        _tail = newNode;

        if (_head == null)
        {
            _head = _tail;
        }

        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        T value = _head!.Value;
        _head = _head.Next;

        if (_head == null)
        {
            _tail = null;
        }

        _count--;
        return value;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        return _head!.Value;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public void Print()
    {
        Node? current = _head;
        while (current != null)
        {
            Console.Write($"{current.Value} ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}