using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Engine
    {
        private Smartphone smartphone;
        private List<string> phoneNumber;
        private List<string> urls;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.phoneNumber = new List<string>();
            this.urls = new List<string>();
        }

        public void Run()
        {
            this.phoneNumber = Console.ReadLine().Split().ToList();
            this.urls = Console.ReadLine().Split().ToList();

            callPhonemunber();
            BrowseUrls();
        }

        private void BrowseUrls()
        {
            foreach (var url in this.urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }
        }

        private void callPhonemunber()
        {
            foreach (var number in this.phoneNumber)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
            }
        }
    }
}
