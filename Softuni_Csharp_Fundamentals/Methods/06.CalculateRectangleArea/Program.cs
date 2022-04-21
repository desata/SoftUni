using System;

namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method that calculates and returns the area of a rectangle. 
            //1.After reading the input
            //2.Create a method, but this time instead of typing "static void" before its name,
            //type "static double" as this will make it return a value of type double:

            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double area = GetArea(sideA, sideB);
            Console.WriteLine(area);

        }
        static double GetArea(double sideA, double sideB)
        {
            return sideA * sideB;

        }
    }
}
