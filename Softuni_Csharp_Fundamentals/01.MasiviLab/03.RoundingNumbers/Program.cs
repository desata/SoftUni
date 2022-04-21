using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read an array of real numbers (space separated), round them in "away from 0" style, and print the output as in the examples:

            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int roundedNumber = 0;

            //round
            foreach (double number in numbers)
            {

                roundedNumber = (int)Math.Round(number,MidpointRounding.AwayFromZero);
                //print
            Console.WriteLine($"{number} => {roundedNumber}");
            }

            
        }
    }
}
