using System;

namespace _01_ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}



/*
Първата задача от тази тема е да се напише конзолна програма, която чете оценка (десетично число), въведена от потребителя и отпечатва "Excellent!", ако оценката е 5.50 или по-висока.
вход	изход		вход	изход		вход	изход		вход	изход
6	Excellent!		5	(няма изход)		5.50    Excellent!      5.49(няма изход)
*/