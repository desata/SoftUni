using System;

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Guess the number!");
            Console.WriteLine("Please enter number between 1 and 5: ");
            int inputNumber = int.Parse(Console.ReadLine());
            int number = random.Next(1, 6);
            int count = 1;

            while (inputNumber != number)
            {
                Console.WriteLine($"Try again! Try # {count}");
                inputNumber = int.Parse(Console.ReadLine());
                count++;
            }

            Console.WriteLine("Sucess!!!");
            Console.WriteLine($"You win from the {count} attempt!");
        }
    }
}
