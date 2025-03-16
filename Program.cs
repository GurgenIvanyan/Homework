public class Parent
{
    public string Name{get;set;}
    public int Age{get;set;}
    public double salary{get;set;}

    public Parent(string name, int age, double salary)
    {
        Name = name;
        Age = age;
        this.salary = salary;
    }
    
}

public class Child
{
    public string Name{get;set;}
    public int Age{get;set;}
    public Parent Father{get;set;}
    public Parent Mother{get;set;}

    public Child(string name, int age,Parent Mother,Parent Father)
    {
        Name = name;
        Age = age;
        this.Father = Father;
        this.Mother = Mother;
    }

    public double FamilyIncome()
    {
        return Father.salary + Mother.salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Child[] children = new Child[]
        {
            new Child("Tigran", 13, new Parent("Anna", 32, 270000), new Parent("Arman", 44, 500000)),
            new Child("Narek", 10, new Parent("Mariam", 30, 200000), new Parent("Gor", 39, 400000)),
            new Child("Sona", 15, new Parent("Lusine", 35, 320000), new Parent("Hayk", 38, 450000)),
            new Child("Ani", 12, new Parent("Nune", 28, 430000), new Parent("Samvel", 36, 450000)),
            new Child("Arman", 9, new Parent("Seda", 29, 280000), new Parent("Karen", 33, 330000)),
            new Child("David", 14, new Parent("Elina", 31, 270000), new Parent("Arsen", 42, 480000)),
            new Child("Lilit", 11, new Parent("Margarita", 26, 260000), new Parent("Gevorg", 34, 370000)),
            new Child("Artur", 16, new Parent("Tatevik", 30, 310000), new Parent("Harut", 41, 490000)),
            new Child("Hayk", 8, new Parent("Gayane", 27, 220000), new Parent("Tigran", 32, 300000)),
            new Child("Emma", 17, new Parent("Ani", 33, 290000), new Parent("Vahagn", 45, 510000)),
        };
        foreach (var child in children)
        {
            if (child.Father.Age + child.Mother.Age <= 70)
            {
                Console.WriteLine($"{child.Name}, {child.Age}");
            }
        }

        // Find the oldest child
        var oldestChild = children[0];
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].Age > oldestChild.Age)
                oldestChild = children[i];
        }

        // Check if Father is null before accessing its properties
        if (oldestChild.Father != null)
        {
            Console.WriteLine($"Oldest child's father's salary: {oldestChild.Father.salary}");
        }
        else
        {
            Console.WriteLine("Father is null for the oldest child.");
        }

        // Find the richest family
        var richestFamily = children[0];
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].FamilyIncome() > richestFamily.FamilyIncome())
            {
                richestFamily = children[i];
            }
        }

        Console.WriteLine($"Richest family child: {richestFamily.Name}, {richestFamily.Age}");

        int youngestChild = 0;
        int oldestChild_ = 0;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].Age < children[youngestChild].Age) youngestChild = i;
            if (children[i].Age > children[oldestChild_].Age) oldestChild_ = i;
        }

        
        Child temp = children[youngestChild];
        children[youngestChild] = children[oldestChild_];
        children[oldestChild_] = temp;

        
        foreach (var child in children)
        {
            Console.WriteLine($"{child.Name}, {child.Age}");
        }
    }
}