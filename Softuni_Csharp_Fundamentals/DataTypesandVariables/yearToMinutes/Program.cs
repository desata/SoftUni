using System;

namespace yearToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //365.24
            //Create a program to enter an integer number of centuries and convert it to years, days, hours, and minutes.
            //1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes

            int centuries = int.Parse(Console.ReadLine());
            int years = (centuries * 100);
            int days = (int)(years*365.2422);
            int hours = (days * 24);
            int minutes = (hours * 60);

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");



        }
    }
}
