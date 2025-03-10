namespace Task84;
public class BankAccount
{
    public string AccountNumber { get; set; }
    private double Balance { get; set; }

    public BankAccount(string accountNumber, double accountBalance)
    {  
        AccountNumber = accountNumber;
        Balance = accountBalance;
    }

    public double Balance1
    {
     get => Balance;
     set => Balance = value;
    }

    public double Deposit(ref double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        Balance += amount;
        return Balance;
    }

    public double Withdraw(ref double amount)
    {
        if (amount < 0 && amount > Balance)
        {
            throw new ArgumentException("Amount cannot be negative or big");
        }
        Balance -= amount;
        return Balance;
    }

    public double Transfer(BankAccount Source,BankAccount destination, double amount)
    {
        if (amount < 0 && amount  > Source.Balance)
        {
            throw new ArgumentException("Amount cannot be negative");
        }
        Source.Balance -= amount;
        destination.Balance += amount;
        return destination.Balance;
    }
    
    
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("001", 5000);
        BankAccount account2 = new BankAccount("002", 10000);
        double AmountForDeposit = 20000;
        account1.Deposit(ref AmountForDeposit);
        Console.WriteLine(account1.Balance1);
        double AmountForWithdraw = 7000;
        account2.Withdraw(ref AmountForWithdraw);
        Console.WriteLine(account2.Balance1);
        double AmountForTransfer = 3000;
        account1.Transfer(account1,account2, AmountForTransfer);
        Console.WriteLine(account1.Balance1);
        Console.WriteLine(account2.Balance1);
    }
}