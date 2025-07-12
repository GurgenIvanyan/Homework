namespace HashSet;

sealed class Node<T>
{
    private T? _value;
    private Node<T>? _next;

    public T Value { get => _value; set => _value = value; }
    public Node<T> Next { get => _next; set => _next = value; }
    
    public Node()
    {
        _value = default(T);
        _next = null;
    }

    public Node(T value, Node<T> next)
    {
        _value = value;
        this._next = next;
    }
}

sealed class MyHashSet
{
    private Node<int>[] _array;
    private int _count;
    private int _capacity = 7;
    private readonly double _threshold = 0.74;

    public int Size => _count;

    public MyHashSet()
    {
        _array = new Node<int>[_capacity];
    }

    private int GetIndex(int key)
    {
        return GetHashFunction(key) % _capacity;
    }

    private int GetHashFunction(int key)
    {
        unchecked
        {
            uint x = (uint)key;
            x += (x << 12);
            x ^= (x >> 22);
            x += (x << 4);
            x ^= (x >> 9);
            x += (x << 10);
            x ^= (x >> 2);
            x += (x << 7);
            x ^= (x >> 12);
        
            return (int)(x & 0x7FFFFFFF); 
        }
    }

    private double GetLoadFactor()
    {
        return (double)_count/_capacity;
    }

    private void ReHashing()
    {
        _capacity *= 2; 
        Node<int>[] newArray = new Node<int>[_capacity];

        for (int i = 0; i < _array.Length; i++)
        {
            Node<int> curr = _array[i];

            while (curr != null)
            {
                Node<int> next = curr.Next;
                
                int index = GetIndex(curr.Value);
                curr.Next = newArray[index];
                newArray[index] = curr;
                
                curr = next;
            }
        }
        
        _array = newArray;
    }
    
    public void Add(int item)
    {
        if (Contains(item)) return;
        if (GetLoadFactor() > _threshold)
        {
            ReHashing();
        }
        
        int index = GetIndex(item);

        
        Node<int> newNode = new Node<int>(item, _array[index]);

        _array[index] = newNode;
        _count++;
    }

    public bool Remove(int item)
    {
        int index = GetIndex(item);
        Node<int> curr = new Node<int>(0, _array[index]);
        
        if (curr.Next == null) return false;
        
        while(curr.Next != null)
        {
            if (curr.Next.Value.Equals(item))
            {
                curr.Next = curr.Next.Next;
                _count--;
                return true;
            }
            curr = curr.Next;
        }

        return false;
    }

    public bool Contains(int item)
    {
        int index = GetIndex(item);
        Node<int> curr = _array[index];
        
        while(curr != null)
        {
            if (curr.Value.Equals(item))
            {
                return true;
            }
            curr = curr.Next;
        }
        return false;
    }
    
}

class Program
{
    static void Main()
    {
        MyHashSet set = new MyHashSet();

        set.Add(15);
        set.Add(12);
        set.Add(30);
        set.Add(99);    
        Console.WriteLine("Contains 99? " + set.Contains(99)); 
        Console.WriteLine("Contains 3? " + set.Contains(3));  
        set.Remove(99);
        Console.WriteLine("Contains 99 after remove? " + set.Contains(99));
        set.Add(4);
        set.Add(1);
        Console.WriteLine("Contains 1? " + set.Contains(1));
    }
}