using System;
using System.Linq;

namespace Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Read an array of real numbers (space separated), round them in "away from 0" style, and print the output as in the example
            //3.14 => 3

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    numbers[i] = 0;
                }
                
                Console.WriteLine($"{numbers[i]} => {(int)Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            }


        }
    }
}
