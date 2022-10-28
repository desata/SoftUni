using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Contracts;

namespace Telephony
{
    public class Phone : ICallable
    {

        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
