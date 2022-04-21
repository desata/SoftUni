using System;

public class Program
{
    public static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());

        if (n < m)
        {
            int num = n;
            decimal product = 1;

            do
            {
                product *= num;
                num++;
            }
            while (num <= m);

            Console.WriteLine($"product[n..m] = {product}");
        }
        else
        {
            Console.WriteLine("Error: n should be smaller than m.");
        }
    }
}
