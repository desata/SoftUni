using System;

public class Program
{
    public static void Main()
    {
        for (int num = 0; num < 10; num++)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine();
        Console.WriteLine();

        int n = 5;
        decimal factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"{n}! = {factorial}");
        Console.WriteLine();

        for (int i = 1, sum = 1; i <= 128; i = i * 2, sum += i)
        {
            Console.WriteLine($"i={i}, sum={sum}");
        }

        Console.WriteLine();

        for (string line = Console.ReadLine(); !string.IsNullOrEmpty(line); line = Console.ReadLine())
        {
            Console.WriteLine("Just read: " + line);
        }
    }
}
