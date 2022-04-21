using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();
            double result = 0.0;

            if (inputUnit == "mm")
            {
                if (outputUnit == "cm")
                {
                    result = number * 0.1;
                    Console.WriteLine($"{result:f3}");
                }
                else if (outputUnit == "m")
                {
                    result = number * 0.001;
                    Console.WriteLine($"{result:f3}");
                }
            }
            else if (inputUnit == "cm")
            {
                if (outputUnit == "mm")
                {
                    result = number * 10;
                    Console.WriteLine($"{result:f3}");
                }
                else if (outputUnit == "m")
                {
                    result = number * 0.01;
                    Console.WriteLine($"{result:f3}");
                }
            }
            else if (inputUnit == "m")
            {
                if (outputUnit == "cm")
                {
                    result = number * 100;
                    Console.WriteLine($"{result:f3}");
                }
                else if (outputUnit == "mm")
                {
                    result = number * 1000;
                    Console.WriteLine($"{result:f3}");
                }
            }
        }
    }
}
