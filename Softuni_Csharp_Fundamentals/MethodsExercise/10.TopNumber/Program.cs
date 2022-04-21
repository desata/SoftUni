using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A top number is an integer that holds the following properties:
            //Its sum of digits is divisible by 8, e.g. 8, 17, 88
            //Holds at least one odd digit, e.g. 232, 707, 87578
            //Some examples of top numbers are: 17, 161, 251, 4310, 123200
            //Create a program to print all top numbers in the range[1…n].
            //You will receive a single integer from the console, representing the end value. Examples

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                bool isTopInteger = isDivisableByEight(i) && HasOddDigit(i);

                if (isTopInteger)
                {
                    Console.WriteLine(i);

                }
            }
        }
        static bool isDivisableByEight(int number)
        {
            int sum = 0;
            while (number > 0)
            {

                sum += number % 10;
                number /= 10;

            }
            if (sum % 8 == 0)
            {
                return true;
            }

            return false;

        }
        static bool HasOddDigit(int number)
        {
            while (number > 0)
            {
                number /= 10;

                if (number % 2 != 0)
                {
                    return true;

                }
            }
            return false;
        }

    }
}

