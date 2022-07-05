using System;

namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //

            int tax = int.Parse(Console.ReadLine());
            double snickers = tax * 0.6;
            double set = snickers * 0.8;
            double ball = set * 0.25;
            double accssessories = ball * 0.2;

            double totalSum = tax + snickers+set+ball+ accssessories;

            Console.WriteLine(totalSum);
        }
    }
}
