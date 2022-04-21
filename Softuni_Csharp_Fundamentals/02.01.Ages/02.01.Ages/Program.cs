using System;

namespace _02._01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());
            if (ages >= 0 && ages <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (ages >= 3 && ages <= 13)
            {
                Console.WriteLine("child");
            }
            else if (ages >= 14 && ages <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (ages >= 20 && ages <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (ages >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
/*
 * Write a program that determines if a person is baby, child, teenager, adult, elder based on the given age. The bounders are:
•	0-2 – baby
•	3-13 – child
•	14-19 – teenager
•	20-65 – adult
•	>= 66 – elder
•	All the values are inclusive.
*/
