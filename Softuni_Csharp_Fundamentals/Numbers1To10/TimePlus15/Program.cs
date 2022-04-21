using System;

namespace TimePlus15
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());


            if (hour == 23)
            {
                if (minutes == 45)
                {
                    minutes = 0;
                    Console.WriteLine($"{0}:0{minutes}");
                }
                else if (minutes > 45 && minutes < 55)
                {
                    minutes = (minutes + 15) % 60;
                    Console.WriteLine($"{0}:0{minutes}");
                }
                else if (minutes < 45)
                {
                    minutes = (minutes + 15) % 60;
                    Console.WriteLine($"{hour}:{minutes}");
                }
                else
                {
                    minutes = (minutes + 15) % 60;
                    Console.WriteLine($"{0}:{minutes}");
                }
            }
            else
                if (minutes == 45)
            {
                hour = hour + 1;
                minutes = 0;
                Console.WriteLine($"{hour}:0{minutes}");
            }
            else if (minutes > 45 && minutes < 55)
            {
                hour = hour + 1;
                minutes = (minutes + 15) % 60;
                Console.WriteLine($"{hour}:0{minutes}");
            }
            else if (minutes < 45)
            {
                minutes = (minutes + 15) % 60;
                Console.WriteLine($"{hour}:{minutes}");
            }
            else
            {
                hour = hour + 1;
                minutes = (minutes + 15) % 60;
                Console.WriteLine($"{hour}:{minutes}");
            }
        }
    }
}
