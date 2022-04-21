using System;

public class Program
{
    public static void Main()
    {
        Console.Write("n = ");

        int n = int.Parse(Console.ReadLine());
        decimal factorial = 1;

        do
        {
            factorial *= n;
            n--;
        }
        while (n > 0);

        Console.WriteLine($"n! = {factorial}");
    }
}
