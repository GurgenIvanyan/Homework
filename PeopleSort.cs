namespace ConsoleApp6;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>()
        {
            new Person() { Name = "John", Age = 25 },
            new Person() { Name = "Alice", Age = 35 },
            new Person() { Name = "Mary", Age = 26 },
            new Person() { Name = "Anna", Age = 28 },
        };
        people.Sort((p1,p2) => p1.Age.CompareTo(p2.Age));
        foreach (Person p in people)
        {
            Console.WriteLine($"{p.Name} - {p.Age}");
        }
        people.Sort((p1,p2)=>p1.Name.CompareTo(p2.Name));
        Console.WriteLine("--------------------------------------------");
        foreach (Person p in people)
        {
            Console.WriteLine($"{p.Name} - {p.Age}");
        }
        

    }
}