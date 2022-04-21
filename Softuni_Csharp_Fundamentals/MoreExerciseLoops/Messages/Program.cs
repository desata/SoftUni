using System;

namespace Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = string.Empty;
            string message = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                input = Console.ReadLine();

                int number = int.Parse(input);
                int mainDigit = number % 10;
                int index = 0;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    index = (((mainDigit - 2) * 3) + (input.Length));
                    index += 97;
                }

                else if (mainDigit == 0)
                {
                    index = 32;
                }
                else
                {
                    index = (((mainDigit - 2) * 3) + (input.Length - 1));
                    index += 97;
                }
                char c = Convert.ToChar(index);
                message += c;

            }
            Console.WriteLine(message);
        }

    }
}
