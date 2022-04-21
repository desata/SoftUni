using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Please enter n: ");
        int n = int.Parse(Console.ReadLine());
        
        Console.Write("Please enter m: ");
        int m = int.Parse(Console.ReadLine());

        for (int i = n; i <= m; i++)
        {
            bool isPrime = true;
            int maxDivisor = (int)Math.Sqrt(i);

            for (int j = 2; j <= maxDivisor; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine($"{i} is prime");
            }
        }
    }
}
