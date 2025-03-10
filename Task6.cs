namespace Tasks76;

class Person
{
    public string Name { get; set; }
    private double _id { get; set; }

    public double Id
    {
        get => _id;
        set => _id = value;
        
    }

    public Person(string name, double id)
    {
        Name = name;
        Id = _id;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Id: {Id}";
    }
}
class ContactArray
{
    public Person[] contacts = new Person[10];
    public int count = 0;

    public Person this[string name]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].Name == name && contacts[i] != null)
                {
                    return contacts[i];
                }
            }
            return null;
        }
    }

    public Person this[int id]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].Id == id)
                {
                    return contacts[i];
                }
            }
            return null;
        }
    }

    public void Add(Person person)
    {
        contacts[count] = person;
        count++;
    }

    public void Print()
    {
        for (int i = 0; i < contacts.Length; i++)
        {
            Console.WriteLine($"{contacts[i].Name} \t {contacts[i].Id}");
        }
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("John",1);
        ContactArray contactArray = new ContactArray();
        contactArray.Add(person);
        contactArray.Print();
    }
}