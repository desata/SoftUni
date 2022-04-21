using System;

namespace _6._2MidExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BlackFlag
            //If the gained plunder is more or equal to the target, print the following:
            //"Ahoy! {totalPlunder} plunder gained."
            //If the gained plunder is less than the target. Calculate the percentage left and print the following:
            //"Collected only {percentage}% of the plunder."
            //Both numbers should be formatted to the 2nd decimal place.

            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double tempPlunder = dailyPlunder;
            double expectedPlunder = double.Parse(Console.ReadLine());

            double gatherPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                gatherPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    gatherPlunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    gatherPlunder -= gatherPlunder * 0.3;

                }

            }
            if (gatherPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {gatherPlunder:f2} plunder gained.");
            }
            else
            {
                double percentage = (gatherPlunder/ expectedPlunder)*100;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }

        }
    }
}
