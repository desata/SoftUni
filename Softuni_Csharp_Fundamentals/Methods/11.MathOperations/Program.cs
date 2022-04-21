using System;

namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a method that receives two numbers and an operator, calculates the result, and returns it.
            //You will be given three lines of input.
            //The first will be the first number, the second one will be the operator and the last one will be the second number.
            //The possible operators are: /, *, +and -.

            int numberOne = int.Parse(Console.ReadLine());
            string sign = Console.ReadLine();
            int numberTwo = int.Parse(Console.ReadLine());
            Calculations(numberOne, sign, numberTwo);
           
        }

        static double Calculations(int numberOne, string sign, int numberTwo)
        {
            double result = 0;

            switch (sign)
            {
                case "+":
                    result = numberOne + numberTwo;
                    break;
                case "-":
                        result = numberOne - numberTwo;
                    break;
                case "*":
                    result = numberOne * numberTwo;
                    break;
                case "/":
                    result = numberOne / numberTwo;
                    break;

            }
            Console.WriteLine(result);
            return result;
        }

    }
}
