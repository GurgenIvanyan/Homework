using System.ComponentModel.DataAnnotations;

namespace Tasks71;

class Person
{
    public string Firstname { get; set;}
    
    public string Lastname { get; set;}
    private string Fullname;
    private bool valid = true;

    public string FullName
    {
        get
        {
            if (valid == true)
            {
                Fullname = $"{Firstname} {Lastname}";
                valid = false;
            }
            return Fullname;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person p = new Person();
        p.Firstname = "John";
        p.Lastname = "Doe";
        Console.WriteLine(p.FullName);
        p.Firstname = "Bob";
        p.Lastname = "Smith";
        Console.WriteLine(p.FullName);
    }
}