using System;

public abstract class BankAccount
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; private set;}

    public SavingsAccount(string accountNumber, decimal balance, decimal interestRate) : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public override void Deposit(decimal amount)
    {
        if (amount <= 0)
        {

            Console.WriteLine("Suma trebuie sa fie mai mare decat 0");
            return;
        }
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Suma trebuie sa fie mai mare decat 0");
        }
        if (amount > Balance)
        {
            throw new Exception("Suma insuficienta");
        }
        Balance -= amount;
    }

}

class CheckingAccount : BankAccount
{
    public decimal OverdraftLimit { get; private set; }

    public CheckingAccount(string accountNumber, decimal initialBalance, decimal overdraftLimit): base(accountNumber, initialBalance)
    { 
        OverdraftLimit = overdraftLimit;
    }

    public override void Deposit(decimal amount)
    {
        if (amount <= 0)
        {

            Console.WriteLine("Suma trebuie sa fie mai mare decat 0");
            return;
        }
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Suma trebuie sa fie mai mare decat 0");
        }
        if (amount > Balance + OverdraftLimit)
        {
            throw new Exception("Suma depaseste limita");
        }
        Balance -= amount;
    }

}

class Program
{
    static void Main(string[] args)
    {
        SavingsAccount savings = new SavingsAccount("AUF456", 1000m, 0.05m);
        savings.Deposit(300m);
        savings.Withdraw(200m);
        Console.WriteLine($"Cont de economii: {savings.AccountNumber}, Balanta: {savings.Balance}");

        CheckingAccount checking = new CheckingAccount("Cont123", 1000m, 500m);
        checking.Deposit(300m);
        checking.Withdraw(1200m);
        Console.WriteLine($"Cont curent: {checking.AccountNumber}, Balanta: {checking.Balance}");
    }
}