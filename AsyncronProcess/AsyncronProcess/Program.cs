using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    //metoda main asyncrona care returneaza Task
    //async utilizeaza await in metoda
    static async Task Main(string[] args)
    {
        try
        {
            List<int> numbers = await GenerateNumbersAsync(); // metoda asyncrona si asteapta finalizarea acesteia
            List<int> evenNumbers = await FilterEvenNumbersAsync(numbers);
            DisplayNumbers(evenNumbers);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    //metoda asyncrona 
    static async Task<List<int>> GenerateNumbersAsync()
    {
        //simulam operatiune de lunga durata cu intarziere de 1 secunda
        await Task.Delay(1000);
        List<int> numbers = Enumerable.Range(1, 100).ToList();
        return numbers;
    }

    //metoda asyncrona care primeste lista si returneaza Task cu lista int
    static async Task<List<int>> FilterEvenNumbersAsync(List<int> numbers)
    {
        //ruleaza task separat care filtreaza numere pare
        return await Task.Run(() =>
        {
            //filtram numere pare
            List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            return evenNumbers;
        });
    }

    static void DisplayNumbers(List<int> numbers)
    {
        Console.WriteLine("Even numbers:");
        numbers.ForEach(n => Console.WriteLine(n));
    }
}
