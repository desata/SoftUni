using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Contracts
{
    public interface ICallable
    {
        public string Number { get; set; }
        void Call();
    }
}
