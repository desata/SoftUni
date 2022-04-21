using System;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Enter a number in range 1-7 and print out the word representing it or "Invalid Day!".
            //Use an array of strings.

            int day = int.Parse(Console.ReadLine());
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (day >= 1 && day <= 7)
            {
                Console.WriteLine($"{daysOfWeek[day-1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
