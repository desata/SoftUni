using System;

namespace _09.GreaterofTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are given an input of two values of the same type.
            //The values can be of type int, char, or string.
            //Create methods called GetMax(), which can compare int, char, or string and returns the biggest of the two values.

            string type = Console.ReadLine();
            GetMax(type);
        }
        static void GetMax(string type)
        {
            

            if (type == "int")
            {
                int valueOne = int.Parse(Console.ReadLine());
                int valueTwo = int.Parse(Console.ReadLine());
                if (valueOne > valueTwo)
                {
                    Console.WriteLine(valueOne);
                }
                else
                {
                    Console.WriteLine(valueTwo);
                }
            }
            if (type == "char")
            {
                char valueOne = char.Parse(Console.ReadLine());
                char valueTwo = char.Parse(Console.ReadLine());

                if ((int)valueOne > (int)valueTwo)
                {
                    Console.WriteLine(valueOne);
                }
                else
                {
                    Console.WriteLine(valueTwo);
                }
            }
            if (type == "string")
            {
                string valueOne = Console.ReadLine();
                string valueTwo = Console.ReadLine();
                if (valueOne.CompareTo(valueTwo) > 0)
                {
                    Console.WriteLine(valueOne);
                }
                else
                {
                    Console.WriteLine(valueTwo);
                }
            }

            
        }
    }
}
