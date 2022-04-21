using System;

namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method, which receives two numbers as parameters:
            //•	The first number – the base
            //•	The second number – the power
            // The method should return the base rase to the given power.
            // 2 8 = 256

            double theBase = double.Parse(Console.ReadLine());
            double thePower = double.Parse(Console.ReadLine());

            double result = GetPower(theBase, thePower);
            Console.WriteLine($"{result}");
        }
        static double GetPower(double theBase, double thePower)
        {
            double result = Math.Pow(theBase, thePower);

            return result;
        }
    }
}
