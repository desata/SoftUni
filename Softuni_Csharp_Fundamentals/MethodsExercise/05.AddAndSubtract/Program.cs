using System;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive 3 integers.
            //Create a method that returns the sum of the first two integers and another method that subtracts the third integer from the result of the sum method.

            int integerOne = int.Parse(Console.ReadLine());
            int integerTwo = int.Parse(Console.ReadLine());
            int integerTree = int.Parse(Console.ReadLine());
            int result = PrintResult(integerOne, integerTwo, integerTree);
            Console.WriteLine(result);

        }
        static int PrintResult(int integerOne, int integerTwo, int integerTree)
        {
            int sum = integerOne + integerTwo;
            return Substraction(sum, integerTree);

        }
        static int Substraction(int sum, int integerTree)
        {
            return sum - integerTree;
        }

    }
}
