namespace HashMap;

sealed class Node<T>
{
    public string Key;
    public T? Value;
    public Node<T>? Next;
    public Node(string key ,T value, Node<T>? next = null)
    {
        this.Key = key;
        this.Value = value;
        this.Next = next;
    }
}

sealed class MyDictionary<K,T>
{
    private Node<T>?[] _buckets;
    private int _capacity = 7;
    private int _count;
    
    private readonly double _threshold = 0.74;

    public MyDictionary()
    {
        _buckets = new Node<T>?[_capacity];
    }

    private double GetLoadFactor()
    {
        return (double)_count / _capacity;
    }
    
    private int GetIndex(string key)
    {
        return GetHash(key) % _capacity;
    }

    private int GetReHashIndex(string key, int capacity)
    {
        return GetHash(key) % capacity;
    }

    private int GetHash(string key)
    {
        ulong hash = 0;
        foreach (char c in key)
        {
            hash = (ulong)c + (hash << 6) + (hash << 16) - hash;
        }
        return (int)(hash & 0x7FFFFFFF); 
    }


    private void ReHashing()
    {
        int newCapacity = _capacity * 2;
        Node<T>?[] newBuckets = new Node<T>?[newCapacity];

        for (int i = 0; i < _buckets.Length; i++)
        {
            Node<T>? curr = _buckets[i];

            while (curr != null)
            {
                Node<T>? next = curr.Next;
                int newIndex = GetReHashIndex(curr.Key, newCapacity);
                curr.Next = newBuckets[newIndex];
                newBuckets[newIndex] = curr;
                
                curr = next;
            }
        }
        
        _capacity = newCapacity;
        _buckets = newBuckets;
    }

    public bool ContainsKey(string key)
    {
        if (key == null) return false;
        
        int index = GetIndex(key);
        
        Node<T>? curr = _buckets[index];
        while (curr != null)
        {
            if (curr.Key == key) return true;
            curr = curr.Next;
        }
        
        return false;
    }
    
    public void Put(string key, T value)
    {
        if (GetLoadFactor() > _threshold)
        {
            ReHashing();
        }
        
        int index = GetIndex(key);
        Node<T> newNode = new Node<T>(key, value, _buckets[index]);
        _buckets[index] = newNode;
        _count++;
    }

    public bool Remove(string key)
    {
        if (key == null) return false;
        
        int index = GetIndex(key);
        Node<T>? curr = _buckets[index];
        Node<T>? prev = null;

        while (curr != null)
        {
            if (curr.Key == key)
            {
                if (prev == null)
                    _buckets[index] = curr.Next;
                else
                    prev.Next = curr.Next;

                _count--;
                return true;
            }

            prev = curr;
            curr = curr.Next;
        }

        return false;

    }

    public T? Get(string key)
    {
        if (key == null) return default;
        int index = GetIndex(key);
        Node<T>? curr = _buckets[index];

        while (curr != null)
        {
            if (curr.Key == key)
            {
                return curr.Value;
            }
            
            curr = curr.Next;
        }
        
        return default;
    }
    
}
class Program
{
    static void Main()
    {
        var myDict = new MyDictionary<string, int>();

        
        myDict.Put("apple", 5);
        myDict.Put("banana", 10);
        myDict.Put("orange", 7);
        myDict.Put("grape", 3);
        myDict.Put("melon", 8);
        myDict.Put("kiwi", 2);
        myDict.Put("lemon", 1); 

    
        Console.WriteLine("banana => " + myDict.Get("banana")); 
        Console.WriteLine("kiwi => " + myDict.Get("kiwi"));      

        Console.WriteLine("Contains 'orange'? " + myDict.ContainsKey("orange")); 
        Console.WriteLine("Contains 'peach'? " + myDict.ContainsKey("peach"));   

      
        Console.WriteLine("Removing 'grape': " + myDict.Remove("grape"));
        Console.WriteLine("Removing 'plum': " + myDict.Remove("plum"));   
        
        Console.WriteLine("grape => " + myDict.Get("grape")); 

        
        myDict.Put("collision1", 100);
        myDict.Put("collision2", 200);
        myDict.Put("collision3", 300);

        Console.WriteLine("collision2 => " + myDict.Get("collision2")); 
    }
}
