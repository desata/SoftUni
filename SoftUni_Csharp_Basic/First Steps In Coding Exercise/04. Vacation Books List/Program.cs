using System;

namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Брой страници в текущата книга – цяло число в интервала [1…1000]
            //2.Страници, които прочита за 1 час – цяло число в интервала[1…1000]
            //3.Броят на дните, за които трябва да прочете книгата – цяло число в интервала[1…1000]

            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysToComplete = int.Parse(Console.ReadLine());
            double hoursPerDay = (pages / pagesPerHour) / daysToComplete;

            //Да се отпечата на конзолата броят часове, които трябва да се отделя за четене всеки ден.
            Console.WriteLine(hoursPerDay);
        }
    }
}
