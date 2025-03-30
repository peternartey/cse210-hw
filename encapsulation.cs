using System;

class BankAccount
{
    private double balance; // Private field (Encapsulation)

    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(1000);
        account.Deposit(500);
        Console.WriteLine("Balance: " + account.GetBalance()); // Output: Balance: 1500
    }
}
