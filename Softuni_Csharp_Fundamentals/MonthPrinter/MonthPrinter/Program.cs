using System;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 12)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine("January");
                        break;
                    case 2:
                        Console.WriteLine("February");
                        break;
                    case 3:
                        Console.WriteLine("March");
                        break;
                    case 4:
                        Console.WriteLine("April");
                        break;
                    case 5:
                        Console.WriteLine("May");
                        break;
                    case 6:
                        Console.WriteLine("June");
                        break;
                    case 7:
                        Console.WriteLine("July");
                        break;
                    case 8:
                        Console.WriteLine("August");
                        break;
                    case 9:
                        Console.WriteLine("September");
                        break;
                    case 10:
                        Console.WriteLine("October");
                        break;
                    case 11:
                        Console.WriteLine("November");
                        break;
                    case 12:
                        Console.WriteLine("December");
                        break;
                    default:
                       // Console.WriteLine("Error!");
                        break;
                }

            }

        }
    }
}
/*
 1.	Month Printer
Write a program, which takes an integer from the console and prints the corresponding month. If the number is more than 12 or less than 1 print "Error!".
Input
You will receive a single integer on a single line.
Output
If the number is within the boundaries print the corresponding month, otherwise print "Error!".

 */
