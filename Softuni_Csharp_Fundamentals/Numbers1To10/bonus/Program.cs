using System;

namespace bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonus = 0.0;

            if (number <= 100)
            {
                bonus = 5;
                //even-odd
                if (number % 2 == 0)
                {
                    bonus = bonus + 1;
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
                else if (number % 10 == 5)
                {
                    bonus = bonus + 2;
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
                else
                {
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
            }
            else if (number > 1000)
            {
                bonus = number * 0.1;
                //even-odd
                if (number % 2 == 0)
                {
                    bonus = bonus + 1;
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
                else if (number % 10 == 5)
                {
                    bonus = bonus + 2;
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
                else
                {
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
            }
            else
            {
                bonus = number * 0.2;
                //even-odd
                if (number % 2 == 0)
                {
                    bonus = bonus + 1;
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
                else if (number % 10 == 5)
                {
                    bonus = bonus + 2;
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
                else
                {
                    Console.WriteLine(bonus);
                    Console.WriteLine(number + bonus);
                }
            }
        }
    }
}
/*
Дадено е цяло число – начален брой точки. Върху него се начисляват бонус точки по правилата, описани по-долу. 
Да се напише програма, която пресмята бонус точките, които получава числото и общия брой точки (числото + бонуса).
•	Ако числото е до 100 включително, бонус точките са 5.
•	Ако числото е по-голямо от 100, бонус точките са 20% от числото.
•	Ако числото е по-голямо от 1000, бонус точките са 10% от числото.

•	Допълнителни бонус точки (начисляват се отделно от предходните):
o	За четно число > + 1 т.
o	За число, което завършва на 5 > + 2 т.

 */