using System;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enter a number in range 1-7 and print out the word representing it or &quot;Invalid Day!&quot;. Use an array of strings.

            int n = int.Parse(Console.ReadLine());

            string[] daysOfTheWeek = new string[]
            {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
            };

            if (n < 1 || n > 7 )
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                
                Console.WriteLine(daysOfTheWeek[n - 1]);
            }
        }
    }
}
