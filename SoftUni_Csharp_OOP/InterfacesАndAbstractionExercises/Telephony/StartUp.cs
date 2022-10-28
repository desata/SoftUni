using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>();
            List<string> urls = new List<string>();

            numbers = Console.ReadLine().Split().ToList();
            urls = Console.ReadLine().Split().ToList();

            Phone phone = new Phone();
            Smartphone smartphone = new Smartphone();

            foreach (string number in numbers)
            {
                if (!number.All(c => Char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (number.Length == 7)
                {
                    phone.Call(number);
                }
                else
                {
                    smartphone.Call(number);
                }
            }
            foreach (var url in urls)
            {
                if (url.Any(c => Char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.Browse(url);
                }
                
            }
        }
    }
}
