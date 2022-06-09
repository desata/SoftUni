using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Create a class DateModifier, which stores the difference of the days between two dates. It should have a method that takes two string parameters representing a date as strings and calculates the difference in the days between them

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int result = DateModifier.CalculateDifference(firstDate, secondDate);

            Console.WriteLine(result);
        }
    }
}
