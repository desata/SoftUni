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
                if ((minutes >= 40 && minutes < 60) || (minutes >= 30 && minutes <= 39))
                {
                    minutes = minutes - 30;
                    Console.WriteLine($"0:{minutes:D2}");
                }
                
                else
                {
                    minutes = minutes + 30;
                    Console.WriteLine($"{hours:D1}:{minutes:D2}");
                }
               
            }
            else if (hours >= 0 && hours <= 9)
            {
                if (minutes >= 40 && minutes < 60)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                //    Console.WriteLine($"{hours}:{minutes}");
                }
                else if (minutes >= 30 && minutes <= 39)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                  //  Console.WriteLine($"{hours}:0{minutes}");
                }
                else
                {
                    minutes = minutes + 30;
                //  Console.WriteLine($"{hours}:{minutes}");
                }
                Console.WriteLine($"{hours:D1}:{minutes:D2}");
            }
            else
            {
                if (minutes >= 40 && minutes < 60)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                }
                else if (minutes >= 30 && minutes <= 39)
                {
                    hours = hours + 1;
                    minutes = minutes - 30;
                 //   Console.WriteLine($"{hours}:{minutes}");
                }
                else
                {
                    minutes = minutes + 30;
                   // Console.WriteLine($"{hours}:{minutes}");
                }

                Console.WriteLine($"{hours:D1}:{minutes:D2}");

            }
           
        }
    }
}