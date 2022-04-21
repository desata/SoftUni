using System;

namespace DataTypesandVariablesExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that receives four integer numbers.
            //You should perform the following operations:
            //•	Add first to the second.
            //•	Divide(integer) the result of the first operation by the third number.
            //•	Multiply the result of the second operation by the fourth number.
            //Print the result after the last operation.

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int result = ((firstNumber + secondNumber) / thirdNumber);
                result = result * fourthNumber;

            Console.WriteLine(result);

        }
    }
}
