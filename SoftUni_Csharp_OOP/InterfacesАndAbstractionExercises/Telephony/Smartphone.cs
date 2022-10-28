using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Contracts;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {

        public string Number { get; set; }
        public string Website { get; set; }
        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
