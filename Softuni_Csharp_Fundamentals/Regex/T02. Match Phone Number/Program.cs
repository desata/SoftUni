using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //(e.g. +359 2-111 111  -> space or -
            List<string> numbers = new List<string>();
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"(?<prefix>[\+][359]{3})(?<separator>[\-\s+])(?<code>[2])\k<separator>(?<number>[0-9]{3})\k<separator>(?<lastnumber>[0-9]{4}\b)");

            foreach (Match match in matches)
            {
                numbers.Add(match.Value);
               // Console.Write(", ");

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
