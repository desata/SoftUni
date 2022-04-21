using System;

namespace backIn30
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (hours == 23)
            {
                if (minutes >= 40 && minutes < 60)
                {
                    minutes = minutes - 30;
                    Console.WriteLine($"0:{minutes}");
                }
                else if (minutes >= 30 && minutes <= 39)
                {
                    minutes = minutes - 30;
                    Console.WriteLine($"0:0{minutes}");
                }
                else
                {
                    minutes = minutes + 30;
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }
            else if(hours >= 0 && hours <= 9)
            {
                if (minutes >= 40 && minutes < 60)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                    Console.WriteLine($"{hours}:{minutes}");
                }
                else if (minutes >= 30 && minutes <= 39)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                    Console.WriteLine($"{hours}:0{minutes}");
                }
                else
                {
                    minutes = minutes + 30;
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }
            else
            {
                if (minutes >= 40 && minutes < 60)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                    Console.WriteLine($"{hours}:{minutes}");

                }
                else if (minutes >= 30 && minutes <= 39)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                    Console.WriteLine($"{hours}:0{minutes}");
                }
                else
                {
                    minutes = minutes + 30;
                    Console.WriteLine($"{hours}:{minutes}");
                }
                
            }        
        }
    }
}
/*
Back in 30 Minutes
Every time Stamat tries to pay his bills C sees on the cash desk the sign: "I will be back in 30 minutes". 
One day Stamat was sick of waiting and decided he needs a program, which prints the time after 30 minutes. 
That way he won’t have to wait on the desk and come at the appropriate time. He gave the assignment to you, so you have to do it. 
Input
The input will be on two lines. On the first line, you will receive the hours and on the second you will receive the minutes. 
Output
Print on the console the time after 30 minutes. The result should be in format hh:mm. The hours have one or two numbers and the minutes have always two numbers (with leading zero).
Constraints
•	The hours will be between 0 and 23.
•	The minutes will be between 0 and 59.
*/
