using System;
using System.Collections.Generic;
using System.Collections;
namespace DLL;
    
public class Node<T>
{
    public Node<T> prev;
    public Node<T> next;
    public T Value;

    public Node(T value)
    {
        prev = null;
        next = null;
        Value = value;
    }

}

public class DoubleLinkedList<T> : IEnumerable<T>, IEnumerable
{
    Node<T> head;
    Node<T> tail;
    public int Count { get; private set; }

    public DoubleLinkedList(Node<T> head, Node<T> tail, int count)
    {
        head = null;
        tail = null;
        Count = 0;
    }

    public void AddFirst(T value)
    {
         var newNode = new Node<T>(value);
         if (head == null)
         {
             head = newNode;
             tail = head;
         }
         else
         {
             head.prev = newNode;
             newNode.next = head;
             head = newNode;
         }
         Count++;
    }

    public void AddLast(T value)
    {
        var newNode = new Node<T>(value);
        if (tail == null)
        {
            head = newNode;
            tail = head;
        }
        else
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
        Count++;
    }

    public void RemoveFirst()
    {
        if (head == null)
        {
            throw new NullReferenceException("Cannot remove from an empty node.");
        }
        else
        {
            head = head.next;
            head.prev = null;
        }
        Count--;
    }

    public void RemoveLast()
    {
        if (tail == null)
        {
            throw new NullReferenceException("Cannot remove from an empty node.");
        }

        if (head == tail)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.prev;
            tail.next = null;
        }
        Count--;
    }

    public bool Remove(T value)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (current == head)
                    RemoveFirst();
                else if (current == tail)
                    RemoveLast();
                else
                {
                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                    Count--;
                }
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.next;
        }
    }

     IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}