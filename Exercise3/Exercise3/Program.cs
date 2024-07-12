
using System;

public class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }
    public int Salary { get; set; }

    public virtual double CalculateAnnualSalary()
    {
        return Salary * 12;
    }
}

class FullTimeEmployee : Employee
{
    public double Bonus { get; set; }

    public override double CalculateAnnualSalary()
    {
        return (Salary * 12) + Bonus;
    }
}

class PartTimeEmployee : Employee
{
    public int HoursWorkedPerMonth { get; set; }
    public float HourlyRate { get; set; }

    public override double CalculateAnnualSalary()
    {
        return HourlyRate * HoursWorkedPerMonth * 12;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee
        {
            Name = "Arina Pereteatcu",
            ID = 1,
            Salary = 13000,
            Bonus = 5000
        };

        PartTimeEmployee partTimeEmployee = new PartTimeEmployee
        {
            Name = "Antonio Margina",
            ID = 2,
            HourlyRate = 35,
            HoursWorkedPerMonth = 80
        };

        Console.WriteLine($"{fullTimeEmployee.Name}'s annual salary: {fullTimeEmployee.CalculateAnnualSalary()} ");
        Console.WriteLine($"{partTimeEmployee.Name}'s annual salary: {partTimeEmployee.CalculateAnnualSalary()} ");
    }
}