namespace Task86;
public class NotificationsSystem
{
    public string[,] Notifications;
    private int Capacity = 10;
    private int Count = 0;

    public NotificationsSystem()
    {
        Notifications = new string[Capacity,2];
    }

    public void RegisterNotification(string UserName, string Message)
    {
        if (Count < Capacity)
        {
            Notifications[Count, 0] = UserName;
            Notifications[Count, 1] = Message;
            Count++;
        }
    }

    public void GetNotification(string UserName)
    {
        bool found = false;
        for (int i = 0; i < Count; i++)
        {
            if (Notifications[i, 0] == UserName)
            {
                Console.WriteLine($"Notification for { UserName } found");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Notification for { UserName } not found");
        }
    }

    public bool HasNotification(string UserName)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Notifications[i, 0] == UserName)
            {
                Console.WriteLine($"Notification for { UserName } found");
                return true;
            }
        }
        return false;
    }

}

class Program
{
    static void Main(string[] args)
    {
        NotificationsSystem notifications = new NotificationsSystem();
        notifications.RegisterNotification("Bob","You have been added to the notifications system");
        notifications.GetNotification("Bob");
        notifications.RegisterNotification("Alice", "You have been added to the notifications system");
        notifications.GetNotification("Alice");
        notifications.GetNotification("Hayk");
        if(notifications.HasNotification("Bob"))
        {
            Console.WriteLine("Bob has a notification");
        }
        if (notifications.HasNotification("Hayk"))
        {
            Console.WriteLine("Hayk has a notification");
        }
        else
        {
            Console.WriteLine("Hayk has no notification");
        }
    }
}