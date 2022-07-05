using System;

namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //read
            //1.Депозирана сума – реално число в интервала [100.00 … 10000.00]
            //2.Срок на депозита(в месеци) – цяло число в интервала[1…12]
            //3.Годишен лихвен процент – реално число в интервала[0.00 …100.00]

            double depositSum = double.Parse(Console.ReadLine());
            int due = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine()) / 100;
            double totalSum = depositSum + due * ((depositSum * interest) / 12);

            //сума = депозирана сума  + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)

            Console.WriteLine(totalSum);
        }
    }
}
