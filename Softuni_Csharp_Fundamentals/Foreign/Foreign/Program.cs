using System;

namespace Foreign
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            switch (country)
            {
              case "England":
              case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }
            
        }
    }
}
/* 
Foreign Languages
Write a program, which prints the language, that a given country speaks. You can receive only the following combinations: 
English is spoken in England and USA; 
Spanish is spoken in Spain, Argentina and Mexico; 
for the others, we should print "unknown".
Input
You will receive a single country name on a single line.
Output
Print the language, which the country speaks, or if it is unknown for your program, print "unknown".
*/