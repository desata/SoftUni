using System;

namespace _01.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a program that, depending on the first line of the input, reads an int, double, or string.
            //•	If the data type is int, multiply the number by 2.
            //•	If the data type is real, multiply the number by 1.5 and format it to the second decimal point.
            //•	If the data type is a string, surround the input with "$".

            string input = Console.ReadLine();


            if (input == "int")
            {
                int data = int.Parse(Console.ReadLine());
                IsType(data);
            }
            else if (input == "real")
            {
                double data = double.Parse(Console.ReadLine());
                IsType(data);
            }
            else if (input == "string")
            { 
                string data = Console.ReadLine();
                IsType(data);
            }

        }
        static int IsType(int data)
        {
            int result = data * 2;
            Console.WriteLine(result);
            return result;
        }
        static double IsType(double data)
        {
            double result = data * 1.5;
            Console.WriteLine($"{result:f2}");
            return result;
        }
        static string IsType(string data)
        { 
            string result = "";
            Console.WriteLine($"${data}$");
            return result;
        }

    }
}
