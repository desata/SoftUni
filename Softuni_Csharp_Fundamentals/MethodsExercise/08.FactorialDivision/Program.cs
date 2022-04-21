using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read two integers.
            //Calculate the factorial of each number.
            //Divide the first result by the second and print the result of the division formatted to the second decimal point.

            int integerOne = int.Parse(Console.ReadLine());
            int integerTwo = int.Parse(Console.ReadLine());

            double firstFactorial = GetFactorial(integerOne);
            double secondFactorial = GetFactorial(integerTwo);
            double result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:f2}");

        }


        static double GetFactorial(int integer)
        {
            double sum = 1;
            for (int i = 1; i <= integer; i++)
            {
                sum *= i;
            }

            return sum;
        }
 

    }
}
