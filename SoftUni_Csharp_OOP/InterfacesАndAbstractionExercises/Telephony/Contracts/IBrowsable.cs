using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Contracts
{
    public interface IBrowseable
    {
        public string Website { get; set; }
        void Browse();
    }
}
