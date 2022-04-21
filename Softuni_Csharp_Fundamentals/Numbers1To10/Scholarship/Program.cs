using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averagePoints = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double soucialScolarship = Math.Round(minSalary * 0.35);
            double superScolarship = Math.Round(averagePoints * 25);
            string output = "";

            if (averagePoints >= 5.5)
            {
                if (income >= minSalary)
                {
                    output = $"You get a scholarship for excellent results {superScolarship} BGN";
                }
                else if (income <= minSalary && soucialScolarship <= superScolarship)
                {
                    output = $"You get a scholarship for excellent results {superScolarship} BGN";
                }
                else
                {
                   output = $"You get a Social scholarship {soucialScolarship} BGN";
                }
            }
            else if (averagePoints >= 4.5)
            {
                if (income >= minSalary)
                {
                    output = "You cannot get a scholarship!";
                }
                else
                {
                    output = $"You get a Social scholarship {soucialScolarship} BGN";
                }
            }
            else
            {
                output = "You cannot get a scholarship!";
            }

            Console.WriteLine(output);

        }
    }
}
/*
Учениците могат да кандидатстват за социална стипендия или за стипендия за отличен успех. 
Изискване за социална стипендия - доход на член от семейството по-малък от минималната работна заплата и успех над 4.5.
Размер на социалната стипендия - 35% от минималната работна заплата. 
Изискване за стипендия за отличен успех - успех над 5.5, включително. Размер на стипендията за отличен успех - успехът на ученика, умножен по коефициент 25.
Напишете програма, която при въведени доход, успех и минимална работна заплата, дава информация дали ученик има право да получава стипендия, и стойността на стипендията, която е по-висока за него.
Вход
Потребителят въвежда 3 числа, по едно на ред:
1.	Доход в лева - реално число в интервала [0.00..6000.00]
2.	Среден успех -  реално число в интервала [2.00...6.00]
3.	Минимална работна заплата - реално число в интервала [0.00..1000.00]
Изход
•	Ако ученикът няма право да получава стипендия, се извежда:
"You cannot get a scholarship!"
•	Ако ученикът има право да получава само социална стипендия:
"You get a Social scholarship {стойност на стипендия} BGN"
•	Ако ученикът има право да получава само стипендия за отличен успех:
"You get a scholarship for excellent results {стойност на стипендията} BGN"
•	Ако ученикът има право да получава и двата типа стипендии, ще получи по-голямата по сума, а ако са равни ще получи тази за отличен успех.
Резултатът се закръгля до по-малкото цяло число.

 */