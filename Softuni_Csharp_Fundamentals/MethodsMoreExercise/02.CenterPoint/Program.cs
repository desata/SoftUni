using System;

namespace _02.CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are given the coordinates of two points on a Cartesian coordinate system - X1, Y1, X2, and Y2.
            //Create a method that prints the point that is closest to the center of the coordinate system (0, 0) in the format (X, Y).
            //If the points are at the same distance from the center, print only the first one.

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            IsCloser(x1, y1, x2, y2);
        }
        static void IsCloser(double x1, double y1, double x2, double y2)
        {
            //string result = "";
            double sqc1 = (Math.Abs(x1 * x1) + Math.Abs(y1 * y1));
            double sqc2 = (Math.Abs(x2 * x2) + Math.Abs(y2 * y2));
            if (sqc1 < sqc2)
            {
               // result = ($"({x1}, {y1})");
                //Console.WriteLine(result);
                //return result;
                Console.WriteLine($"({x1}, {y1})");

            }
            else
            {
               // result = ($"({x2}, {y2})");
                Console.WriteLine($"({x2}, {y2})");
                //return result;

            }
        }
    }
}
