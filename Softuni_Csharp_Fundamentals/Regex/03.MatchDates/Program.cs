using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"(?<day>[0-9]{2})(?<separator>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<separator>([0-9]{4})");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups[1]}");
            }

        }
    }
}