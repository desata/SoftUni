using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int puppets = int.Parse(Console.ReadLine());
            int tedybears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlePice = (2.60* puzzles);
            double puppetPrice = (3.00* puppets);
            double tedyPrice = (4.10* tedybears);
            double minionPrice = (8.20* minions);
            double truckPrice = (2.00 * trucks);

            double totalToysPrice = (puzzlePice + puppetPrice + tedyPrice + minionPrice + truckPrice);
           // double profit = 0;
            double discount = 0.25 * totalToysPrice;
            int toys = (puzzles + puppets + tedybears + minions + trucks);

            if (toys >= 50)
            {
                double rent = (totalToysPrice - discount) * 0.10;
                double profit = totalToysPrice - rent - discount;
                double diff = profit - tripPrice;
                if (profit >= tripPrice)
                {

                    Console.WriteLine($"Yes! {diff:f2} lv left.");
                }
                else
                {
                    double diff1 = tripPrice - profit;
                    Console.WriteLine($"Not enough money! {diff1:f2} lv needed.");
                }
            }

            else
            {
                {
                    double rent = totalToysPrice * 0.10;
                    double profit = totalToysPrice - rent;
                    double diff = profit - tripPrice;
                    if (profit >= tripPrice)
                    {

                        Console.WriteLine($"Yes! {diff:f2} lv left.");
                    }
                    else
                    {
                        double diff1 = tripPrice - profit;
                        Console.WriteLine($"Not enough money! {diff1:f2} lv needed.");
                    }
                }
            }
        }
    }
}

/*
Петя има магазин за детски играчки. Тя получава голяма поръчка, която трябва да изпълни. 
С парите, които ще спечели иска да отиде на екскурзия. 
Да се напише програма, която пресмята печалбата от поръчката.

Цени на играчките:
•	Пъзел - 2.60 лв.
•	Говореща кукла - 3 лв.
•	Плюшено мече - 4.10 лв.
•	Миньон - 8.20 лв.
•	Камионче - 2 лв.
Ако поръчаните играчки са 50 или повече магазинът прави отстъпка 25% от общата цена. 
От спечелените пари Петя трябва да даде 10% за наема на магазина. 
Да се пресметне дали парите ще ѝ стигнат да отиде на екскурзия.
От конзолата се четат 6 реда:
1.	Цена на екскурзията - реално число в интервала [1.00 … 10000.00]
2.	Брой пъзели - цяло число в интервала [0… 1000]
3.	Брой говорещи кукли - цяло число в интервала [0 … 1000]
4.	Брой плюшени мечета - цяло число в интервала [0 … 1000]
5.	Брой миньони - цяло число в интервала [0 … 1000]
6.	Брой камиончета - цяло число в интервала [0 … 1000]
На конзолата се отпечатва:
•	Ако парите са достатъчни се отпечатва:
o	"Yes! {оставащите пари} lv left."
•	Ако парите НЕ са достатъчни се отпечатва:
o	"Not enough money! {недостигащите пари} lv needed."

 */