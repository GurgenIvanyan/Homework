using System;
using System.Collections.Generic;
using System.Collections;
namespace SortedSet;

class MySortedSet<T> : IEnumerable<T> where T : IComparable
{
 private T[] _items;
 private int _count;

 public MySortedSet(int capacity = 4)
 {
     _items = new T[capacity];
     _count = 0;
 }
 public int Count => _count;

 public bool Add(T item)
 {
     if(Contains(item))
         return false;
     EnsureCapacity();
     int i;
     for(i = _count-1;i>=0 && _items[i].CompareTo(item) > 0;i--)
         _items[i+1] = _items[i];
     _items[i+1] = item;
     _count++;
     return true;
 }

 public bool Remove(T item)
 {
     int index = BinarySearch(item);
     if (index < 0)
     {
         return false;
     }

     for (int i = index; i < _count - 1; i++)
     {
         _items[i] = _items[i + 1];
     }
     _items[_count-1] = default;
     return true;
 }

 public bool Contains(T item)
 {
     return BinarySearch(item) >= 0;
 }
 private void EnsureCapacity()
 {
     if (_count == _items.Length)
     {
         T[] newItems = new T[_items.Length * 2];
         Array.Copy(_items, newItems, _items.Length);
         _items = newItems;
     }
 }

 public int BinarySearch(T item)
 {
     int Left=0, Right=_items.Length-1;
     while (Left <= Right)
     {
         int mid = (Left+Right)/2;
         int cmp=_items[mid].CompareTo(item);
         if(cmp==0) return mid;
         if(cmp<0) Left = mid + 1;
         else Right = mid - 1;
     }
     return -1;
 }

 public IEnumerator<T> GetEnumerator()
 {
     for (int i = 0; i < _count; i++)
     {
         yield return _items[i];
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