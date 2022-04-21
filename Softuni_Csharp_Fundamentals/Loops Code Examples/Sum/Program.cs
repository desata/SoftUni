using System;

public class Program
{
    public static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int number = 1;
        int sum = 1;

        Console.Write("The sum 1");
        while (number < n)
        {
            number++;
            sum += number;
            Console.Write($"+{number}");
        }
        Console.WriteLine($" = {sum}");
    }
}
