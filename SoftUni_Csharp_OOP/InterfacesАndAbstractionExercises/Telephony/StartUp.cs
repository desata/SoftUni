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

            try
            {
                foreach (var num in numbers)
                {

                }
            }
            catch (Exception ex)
            {

                throw new Exception;
            }

            Smartphone smartphone = new Smartphone();

        }
    }
}
