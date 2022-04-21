using System;

namespace _02._03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();
            double dayprice = 0;
            double price = 0;

            if (typeOfPeople == "Students")
            {
                if (day == "Friday")
                {
                    dayprice = 8.45;
                }
                else if (day == "Saturday")
                {
                    dayprice = 9.80;
                }
                else if (day == "Sunday")
                {
                    dayprice = 10.46;
                }
                price = (dayprice * countOfPeople);

                if (countOfPeople >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (typeOfPeople == "Business")
            {
                if (day == "Friday")
                {
                    dayprice = 10.90;
                }
                else if (day == "Saturday")
                {
                    dayprice = 15.60;
                }
                else if (day == "Sunday")
                {
                    dayprice = 16;
                }
                price = (dayprice * countOfPeople);

                if (countOfPeople >= 100)
                {
                    price -= (10 * dayprice);
                }
            }
            else if (typeOfPeople == "Regular")
            {
                if (day == "Friday")
                {
                    dayprice = 15;
                }
                else if (day == "Saturday")
                {
                    dayprice = 20;
                }
                else if (day == "Sunday")
                {
                    dayprice = 22.50;
                }
                price = (dayprice * countOfPeople);

                if (countOfPeople <= 20 && countOfPeople >= 10)
                {
                    price *= 0.95;
                }                              
            }
            Console.WriteLine($"Total price: {price:F2}");
            
        }
    }
}
