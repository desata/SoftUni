using System;

namespace _100_200
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());

            if (num < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (num > 200)
            {
                Console.WriteLine("Greater than 200");
            }
            else
            {
                Console.WriteLine("Between 100 and 200");
            }
        }
    }
}

/*
Да се напише програма, която чете цяло число, въведено от потребителя и проверява, дали е под 100, между 100 и 200 или над 200. 
Да се отпечатат съответно съобщения, като в примерите по-долу:
вход	изход		    вход	изход		            вход	изход
95	Less than 100		120	    Between 100 and 200		210	    Greater than 200

 */