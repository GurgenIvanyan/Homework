namespace EventDriven;

public class NotificationMassage
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Recipient { get; set; }

    public NotificationMassage(string title, string body, string recipient)
    {
        Title = title;
        Body = body;
        Recipient = recipient;
    }
}

public interface INotificationSender
{
    public void Send(NotificationMassage massage);
}

public class EmailSender : INotificationSender
{
    public void Send(NotificationMassage massage)
    {
        Console.WriteLine("Sending notification by Email");
    }
}

public class SmsSender : INotificationSender
{
    public void Send(NotificationMassage massage)
    {
        Console.WriteLine("Sending notification by Sms");
    }
}

public class PushNotificationSender : INotificationSender
{
    public void Send(NotificationMassage massage)
    {
        Console.WriteLine("Sending notification by Push");
    }
}

public class TelegramSender : INotificationSender
{
    public void Send(NotificationMassage massage)
    {
        Console.WriteLine("Sending notification by Telegram");
    }
}

public class NotificationManager
{
    public event Action<NotificationMassage> OnNotificationReady;
    public event Action<DateTime, NotificationMassage> OnNotificationSent;
    private List<INotificationSender> _senders;

    public NotificationManager(IEnumerable<INotificationSender> senders)
    {
     _senders = senders.ToList();
     OnNotificationReady += NotifyAllSenders;
    }
    public void PrepareNotification(NotificationMassage massage)
    {
        OnNotificationReady?.Invoke(massage);
        OnNotificationSent?.Invoke(DateTime.Now, massage);
    }

    public void NotifyAllSenders(NotificationMassage massage)
    {
        foreach (var sender in _senders)
        {
            sender.Send(massage);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var senders = new List<INotificationSender>()
        {
            new EmailSender(),
            new SmsSender(),
            new PushNotificationSender(),
            new TelegramSender(),
        };
        var notificationManager = new NotificationManager(senders);
        notificationManager.OnNotificationSent += (sender, notification) =>
        {
            Console.WriteLine($"Notification sent at {DateTime.Now} to {notification.Recipient}");
        };
        var massage = new NotificationMassage("x", "y", "z");
        notificationManager.PrepareNotification(massage);

    }
}