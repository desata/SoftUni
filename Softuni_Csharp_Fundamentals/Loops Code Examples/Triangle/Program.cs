using System;

public class Program
{
    public static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();

        for (int row = 1; row <= n; row++)
        {
            for (int column = 1; column <= row; column++)
            {
                Console.Write($"{column} ");
            }

            Console.WriteLine();
        }
    }
}
