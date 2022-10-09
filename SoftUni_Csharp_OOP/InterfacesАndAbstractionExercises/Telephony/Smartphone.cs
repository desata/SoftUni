using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Contracts;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone(string number, string website)
        {
            Number = number;
            Website = website;
        }

        public string Number { get; set; }
        public string Website { get; set; }

        public void Browse()
        {
            throw new NotImplementedException();
        }

        public void Call()
        {
            throw new NotImplementedException();
        }
    }
}
