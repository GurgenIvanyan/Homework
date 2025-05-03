namespace Command;
using System;
using System.Collections.Generic;
class BankAccount
{
    public string Owner { get; }
    public int Balance { get; private set; }

    public BankAccount(string owner, int initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(int amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount} to {Owner}. New balance: {Balance}");
    }

    public bool Withdraw(int amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount} from {Owner}. New balance: {Balance}");
            return true;
        }
        else
        {
            Console.WriteLine($" Withdrawal failed for {Owner}. Insufficient funds.");
            return false;
        }
    }
}

interface ITransactionCommand
{
    void Execute();
    void Undo();
}

class DepositCommand : ITransactionCommand
{
    private readonly BankAccount _account;
    private readonly int _amount;

    public DepositCommand(BankAccount account, int amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _account.Deposit(_amount);
    }

    public void Undo()
    {
        _account.Withdraw(_amount);
        Console.WriteLine($"Undo: Reversed deposit of {_amount}. Balance is now: {_account.Balance}");
    }
}
class WithdrawCommand : ITransactionCommand
{
    private readonly BankAccount _account;
    private readonly int _amount;
    private bool _succeeded;

    public WithdrawCommand(BankAccount account, int amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _succeeded = _account.Withdraw(_amount);
    }

    public void Undo()
    {
        if (_succeeded)
        {
            _account.Deposit(_amount);
            Console.WriteLine($"Undo: Reversed withdrawal of {_amount}. Balance is now: {_account.Balance}");
        }
        else
        {
            Console.WriteLine("Undo: Withdrawal of 0 skipped.");
        }
    }
}

class TransactionInvoker
{
    private readonly Stack<ITransactionCommand> _history = new();

    public void ExecuteCommand(ITransactionCommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLast()
    {
        if (_history.Count > 0)
        {
            var command = _history.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount("John", 1000);

        var deposit = new DepositCommand(account, 200);
        var withdraw = new WithdrawCommand(account, 150);
        var invalidWithdraw = new WithdrawCommand(account, 5000);

        var invoker = new TransactionInvoker();
        invoker.ExecuteCommand(deposit);
        invoker.ExecuteCommand(withdraw);
        invoker.ExecuteCommand(invalidWithdraw);

        invoker.UndoLast(); 
        invoker.UndoLast(); 

        Console.WriteLine("Final balance: " + account.Balance);
    }
}