namespace Task93;

public  class SecurySystem
{
    public string Name { get; set; }
    public string Role { get; set; }
    public int[] data;

    public SecurySystem(string name, string role)
    {
        Name = name;
        Role = role;
        data = new int[10];
    }

    public int this[int index]
    {
        get
        {
            if (Role == "Admin" || Role == "User" || Role == "Guest")
            {
                return data[index];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            if (Role == "Admin" && index >=0 && index < data.Length)
            {
                data[index] = value;
            }
            else
            {
                Console.WriteLine("your role is invalid");
                return;
            }
        }
    }

    public string HasPermission(string Role)
    {
        switch (Role)
        {
            case "Admin":
                return "The administrator has permission to override the value of the product";
            case "User":
                return "The user has permission to buy the product.";
            case "Guest":
                return "The guest has no permissions";
            default:
                return "invalid Role";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        SecurySystem admin = new SecurySystem("John", "Admin");
        SecurySystem user= new SecurySystem("Bob", "User");
        SecurySystem guest = new SecurySystem("Guest", "Guest");
        Console.WriteLine(admin.HasPermission("Admin"));
        Console.WriteLine(user.HasPermission("User"));
        Console.WriteLine(guest.HasPermission("Guest"));
        admin[0] = 15;
        Console.WriteLine(admin[0]);
        user[2] = 24;
        
    }
}