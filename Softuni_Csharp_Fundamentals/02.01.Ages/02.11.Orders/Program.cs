using System;

namespace _02._11.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double cofeePrice = 0;
            double totalPrice = 0;

            for (int i = 1; i <= orders; i++)
            {
                double capsulesPrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());
                cofeePrice = ((days * capsuleCount) * capsulesPrice);
                totalPrice += cofeePrice;
                Console.WriteLine($"The price for the coffee is: ${cofeePrice:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
