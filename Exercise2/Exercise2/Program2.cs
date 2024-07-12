
using System;
using System.Collections.Generic;

namespace Exercise2
{
    public class BankAccount
    {
        public DateTime DataCrearii { get; set; }
        public string Nume { get; set; }
        public int AccountNumber { get; set; }
        public string Currency { get; set; }
        private int Pin { get; set; }

        private List<string> Tranzactii;
        private float Balance;

        public BankAccount(string nume, int accountNumber, string currency, int pin)
        {
            DataCrearii = DateTime.Now;
            Nume = nume;
            AccountNumber = accountNumber;
            Currency = currency;
            Pin = pin;
            Tranzactii = new List<string>();
            Balance = 0;
        }

        public void Deposit(float amount)
        {
            Balance += amount;
            Tranzactii.Add($"Ati depositat {amount} {Currency}. Balanta Noua: {Balance} {Currency}");
        }

        public bool Withdraw(float amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Tranzactii.Add($"Ati extras {amount} {Currency}. Balanta noua: {Balance} {Currency}");
                return true;
            }
            else
            {
                Tranzactii.Add("Nu ai bani in cont");
                return false;
            }
        }

        public float GetBalance()
        {
            return Balance;
        }

        public void GetTranzactii()
        {
            Console.WriteLine($"Istoricul tranzactiilor pentru contul {AccountNumber}");

            foreach (var tranzactie in Tranzactii)
            {
                Console.WriteLine(tranzactie);
            }
        }
    }

    public class Exercise2
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Alisa Melisa", 5678, "USD", 1234);
            BankAccount account2 = new BankAccount("Felicia Marusia", 9023, "USDT", 1035);

            account1.Deposit(500);
            account2.Deposit(600);

            Console.WriteLine($"Balanta curenta: {account1.GetBalance()} {account1.Currency}");

            account1.Withdraw(200);
            account2.Withdraw(100);

            Console.WriteLine($"Balanta curenta: {account1.GetBalance()} {account1.Currency}");
            Console.WriteLine($"Balanta curenta: {account2.GetBalance()} {account2.Currency}");

            account1.GetTranzactii();
            account2.GetTranzactii();
        }
    }
}