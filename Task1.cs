namespace Task91;
using System;

public interface IPaymentMethod
{
    bool ValidateTransaction(TransactionDetails transactionDetails);
    decimal CalculateFee(decimal amount);
    decimal ProcessPayment(decimal amount, TransactionDetails transactionDetails);
}

public class TransactionDetails
{
    public string CreditCardNumber { get; set; }
    public string PaypalAccountNumber { get; set; }
    public string BankAccountNumber { get; set; }
}

public class CreditCardPayment : IPaymentMethod
{
    public bool ValidateTransaction(TransactionDetails transactionDetails)
    {
        if (string.IsNullOrEmpty(transactionDetails.CreditCardNumber))
        {
            Console.WriteLine("Invalid CreditCard Number.");
            return false;
        }
        return true;
    }

    public decimal CalculateFee(decimal amount)
    {
        return amount * 0.05m; 
    }

    public decimal ProcessPayment(decimal amount, TransactionDetails transactionDetails)
    {
        if (ValidateTransaction(transactionDetails))
        {
            decimal fee = CalculateFee(amount);
            return amount - fee;
        }

        return 0m;
    }
}

public class PaypalPayment : IPaymentMethod
{
    public bool ValidateTransaction(TransactionDetails transactionDetails)
    {
        if (string.IsNullOrEmpty(transactionDetails.PaypalAccountNumber))
        {
            Console.WriteLine("Invalid PayPal Account Number.");
            return false;
        }
        return true;
    }

    public decimal CalculateFee(decimal amount)
    {
        return amount * 0.10m; 
    }

    public decimal ProcessPayment(decimal amount, TransactionDetails transactionDetails)
    {
        if (ValidateTransaction(transactionDetails))
        {
            decimal fee = CalculateFee(amount);
            return amount - fee;
        }
        return 0m;
    }
}

public class BankTransferPayment : IPaymentMethod
{
    public bool ValidateTransaction(TransactionDetails transactionDetails)
    {
        if (string.IsNullOrEmpty(transactionDetails.BankAccountNumber))
        {
            Console.WriteLine("Invalid Bank Account Number.");
            return false;
        }
        return true;
    }

    public decimal CalculateFee(decimal amount)
    {
        return amount * 0.09m; 
    }

    public decimal ProcessPayment(decimal amount, TransactionDetails transactionDetails)
    {
        if (ValidateTransaction(transactionDetails))
        {
            decimal fee = CalculateFee(amount);
            return amount - fee;
        }
        return 0m;
    }
}

public class PaymentMethodFactory
{
    public static IPaymentMethod GetPaymentMethod(string paymentMethodType)
    {
        switch (paymentMethodType.ToLower())
        {
            case "creditcard":
                return new CreditCardPayment();
            case "paypal":
                return new PaypalPayment();
            case "banktransfer":
                return new BankTransferPayment();
            default:
                throw new ArgumentException("Invalid payment method.");
        }
    }
}

public class Checkout
{
    public void ProcessTransaction(decimal amount, string paymentMethodType, TransactionDetails transactionDetails)
    {
        IPaymentMethod paymentMethod = PaymentMethodFactory.GetPaymentMethod(paymentMethodType);

        decimal netAmount = paymentMethod.ProcessPayment(amount, transactionDetails);

        if (netAmount > 0)
        {
            Console.WriteLine($"Payment processed successfully! Net amount: {netAmount:C}");
        }
        else
        {
            Console.WriteLine("Payment failed.");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        
        var transactionDetails1 = new TransactionDetails
        {
            CreditCardNumber = "1234-5678-9876-5432", 
            PaypalAccountNumber = "", 
            BankAccountNumber = ""
        };

        var checkout = new Checkout();
        checkout.ProcessTransaction(100m, "creditcard", transactionDetails1);

        
        var transactionDetails2 = new TransactionDetails
        {
            CreditCardNumber = "",
            PaypalAccountNumber = "user@paypal.com", 
            BankAccountNumber = ""
        };

        checkout.ProcessTransaction(300m, "paypal", transactionDetails2);

        var transactionDetails3 = new TransactionDetails
        {
            CreditCardNumber = "",
            PaypalAccountNumber = "",
            BankAccountNumber = "123456789" 
        };

        checkout.ProcessTransaction(300m, "banktransfer", transactionDetails3);
    }
}


