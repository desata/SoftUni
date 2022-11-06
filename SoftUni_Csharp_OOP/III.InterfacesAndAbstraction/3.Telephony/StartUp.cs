using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> urls = Console.ReadLine().Split().ToList(); ;

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.All(char.IsDigit))
                {
                    if (number.Length > 7)
                    {
                        smartphone.Call(number);
                    }
                    else
                    {
                        stationaryPhone.Call(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var site in urls)
            {
                if (site.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.Browse(site);
                }
            }

        }
    }
}
