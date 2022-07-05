using System;

namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int d = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double litters = ((d * w * v)*0.001) * (1 - percent/100); ;

            Console.WriteLine(litters);
        }
    }
}
