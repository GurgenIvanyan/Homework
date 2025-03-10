namespace Task82;

public class StorageSystem
{
    public string[] Data;

    public StorageSystem(int capacity)
    {
        Data = new string[capacity];
    }

    public void Add(int index, string data, User user)
    {
        if (user.Permissions("Write"))
        {
            if (index < Data.Length)
            {
                Data[index] = data;
                Console.WriteLine("Added to Storage System");
            }
            else
            {
                Console.WriteLine("the index is out of range");
            }
        }
        else
        {
            Console.WriteLine("You do not have permission to add data to this storage system.");
        }
    }

    public void Remove(int index, User user)
    {
        if (user.Permissions("Delete"))
        {
            if (index >= 0 && index <= Data.Length)
            {
                Data[index] = null;
                Console.WriteLine("Removed from Storage System");
            }
            else
                {
                    Console.WriteLine("The index is out of range");
                }
            }
        else{
            Console.WriteLine("You do not have permission to remove data from this storage system.");
        }
    }

    public string Read(int index, User user)
    {
        if (user.Permissions("Read"))
        {
            if (index >= 0 && index <= Data.Length && Data[index] != null)
            {
                return Data[index];
            }
            else
            {
                Console.WriteLine("The index is out of range");
                return null;
            }
        }
        else
        {
            Console.WriteLine("You do not have permission to read data from this storage system.");
            return null;
        }
    }
}

public class User
{
    public string Role { get; private set; }
    public string[] permissions;

    public User(string role)
    {
        Role = role;
        permissions = SetPermissions(Role);
    }

    public string[] SetPermissions(string role)
    {
        switch (role)
        {
            case "Admin":
                return new string[] { "Read", "Write", "Delete" };
            case "Editor":
                return new string[] { "Read", "Write" };
            case "Viewer":
                return new string[] { "Read" };
            default:
                return new string[] { };
        }
    }

    public bool Permissions(string role)
    {
        foreach (var permission in permissions)
        {
            if (permission == role)
            
             return true;
        }
        return false;
    }
}


class Program
{
    static void Main(string[] args)
    {
        User AdminUser = new User("Admin");
        User EditorUser = new User("Editor");
        User ViewerUser = new User("Viewer");
        StorageSystem StorageSystem = new StorageSystem(3);
        StorageSystem.Add(0,"Data For Admin", AdminUser);
        Console.WriteLine(StorageSystem.Read(0,AdminUser));
        StorageSystem.Remove(0,AdminUser);
        StorageSystem.Add(1,"Data For Editor", EditorUser);
        Console.WriteLine(StorageSystem.Read(1,AdminUser));
        StorageSystem.Remove(1,AdminUser);
        StorageSystem.Add(2, "Data For Viewer", ViewerUser);
        Console.WriteLine(StorageSystem.Read(2,AdminUser));
        StorageSystem.Remove(2,AdminUser);
    }
}