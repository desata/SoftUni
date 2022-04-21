using System;
using System.Collections.Generic;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are given two lines – the first one can be a really big number (0 to 10na50ta).
            //The second one will be a single-digit number (0 to 9). Your task is to display the product of these numbers.
            //Note: do not use the BigInteger class.
            string lineOne = Console.ReadLine();
            int lineTwo = int.Parse(Console.ReadLine());
            List<char> result = new List<char>();
            int firstNumber = 0;

            if (lineTwo == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = lineOne.Length - 1; i >= 0; i--)
            {
                int currResult = 0;
                int lastDigitLineOne = ((lineOne[i]) - 48);

                currResult = (lastDigitLineOne * lineTwo) + firstNumber;
                int lastNumber = (currResult % 10);

                result.Add((char)(lastNumber + 48));

                firstNumber = currResult / 10;
            }
            if (firstNumber > 0)
            {
                result.Add((char)(firstNumber + 48));
            }
            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
