namespace MassageHandler;

class Program
{
    public delegate void MessageHandler(string message);

    public class Notifier
    {
        public MessageHandler handler;

        public void Send(string message)
        {
            handler.Invoke(message);
        }

        public static void ConsoleHandler(string message) => Console.WriteLine(message);
        public static void FileHandler(string message) => Console.WriteLine(message);
        public static void EmailHandler(string message) => Console.WriteLine(message);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MassageHandler!");
            Console.WriteLine("Enter the message you want to send:");
            string message = Console.ReadLine();
            Notifier notifier = new Notifier();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Send an email\n2) Send a file\n3) Send an email\n4) All)");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("by Console");
                    notifier.handler = ConsoleHandler;
                    break;
                case 2:
                    notifier.handler = FileHandler;
                    Console.WriteLine("by File");
                    break;
                case 3:
                    notifier.handler = EmailHandler;
                    Console.WriteLine("by Email");
                    break;
                case 4:
                    Console.WriteLine("the message you want send by all Handlers");
                    notifier.handler = EmailHandler;
                    notifier.handler += ConsoleHandler;
                    notifier.handler += FileHandler;
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }

            notifier.Send(message);
        }
    }
}