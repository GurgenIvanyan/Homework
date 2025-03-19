namespace _arajadranq2;

public class Course
{
    public string Name { get; set; }
    public int Monthfee{get; set;}
    public Modul[] Moduls { get; set; }

    public Course(string name, int monthfee, Modul[] moduls)
    {
        Name = name;
        Monthfee = monthfee;
        Moduls = moduls;
    }
}

public class Modul
{
    public string Title { get; set; }
    public double Duration{get; set;}

    public Modul(string title, double duration)
    {
        Title = title;
        Duration = duration;
    }
}

public class Web : Course
{
    public string Type{get; set;}

    public Web(string name, int monthfee, string Type,Modul[] moduls) : base(name, monthfee, moduls)
    {
        this.Type = Type;
    }
}

public class Game : Course
{
    public string Engine{get; set;}

    public Game(string name, int monthfee,string Engine,Modul[] moduls) : base(name, monthfee, moduls)
    {
        this.Engine = Engine;
    }
}

public class Group
{
    public int StudentCount { get; set; }
    public string Name;
    public Course Course { get; set; }

    public Group(string name, int studentCount, Course course)
    {
        Name = name;
        Course = course;
        StudentCount = studentCount;
    }
    
}
public class Ai:Course
{
    public Ai(string name, int monthfee, Modul[] moduls) : base(name, monthfee, moduls)
    {
        
    }
    
}
class Program
{
    static void Main(string[] args)
    {
        Course[] courses = new Course[]
        {
            new Web("Frontend Development", 500000, "frontend", new Modul[]
            {
                new Modul("HTML & CSS", 2), new Modul("JavaScript", 3)
            }),
            new Web("Fullstack Development", 60000, "fullstack", new Modul[]
            {
                new Modul("Node.js", 4), new Modul("React", 5)
            }),
            new Ai("Machine Learning", 80000, new Modul[]
            {
                new Modul("Python for AI", 6), new Modul("Deep Learning", 8)
            }),
            new Game("Game Development", 72000, "Unity", new Modul[]
            {
                new Modul("C# for Unity", 5), new Modul("Physics in Games", 4)
            }),
            new Game("Game Dev Advanced", 42000, "Unreal", new Modul[]
            {
                new Modul("Blueprints", 6), new Modul("C++ for Unreal", 7)
            })
        };

        Group[] groups = new Group[]
        {
            new Group("Frontend Group 1", 15, courses[0]),
            new Group("Fullstack Group 1", 12, courses[1]),
            new Group("AI Group 1", 10, courses[2]),
            new Group("Game Dev Group 1", 20, courses[3]),
            new Group("Game Dev Group 2", 18, courses[4])
        };
        int WebMembersCount = 0;
        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i].Course is Web)
            {
                WebMembersCount += groups[i].StudentCount;
            }
        }

        Console.WriteLine("Web members count: " + WebMembersCount);
        double IncomeFromGame = 0;
        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i].Course is Game game && game.Engine == "Unreal")
            {
                IncomeFromGame += groups[i].StudentCount * groups[i].Course.Monthfee;
            }
        }
        Console.WriteLine($"Income from game: {IncomeFromGame}");
        int maxMember = 0;
        foreach (var group in groups)
        {
            if (group.StudentCount > maxMember)
            {
                maxMember = group.StudentCount;
            }
        }

        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i].StudentCount == maxMember)
            {
                Console.WriteLine($"the most popolar Cours is  {groups[i].Course.Name} with {groups[i].StudentCount} students");
            }
        }
    }
}