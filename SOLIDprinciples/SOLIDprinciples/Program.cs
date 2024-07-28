using System;

public class Order
{
    public int Id { get; set; }
    public double Amount { get; set; }
}

public interface IProcessPayment
{
    void ProcessPayment(Order order);
}

public class CreditCardPaymentProcess : IProcessPayment
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing payment");
    }
}

public class PayPalPaymentProcess : IProcessPayment
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing Paypal payment");
    }
}

public class BankTransferPaymentProcess : IProcessPayment
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing bank transfer");
    }
}

public class DataBase
{
    public void SaveToDataBase(Order order)
    {
        Console.WriteLine("Saving order to database");
    }

    public Order LoadFromDataBase(int orderID)
    {
        Console.WriteLine("Loading order from database");
        return new Order();
    }
}