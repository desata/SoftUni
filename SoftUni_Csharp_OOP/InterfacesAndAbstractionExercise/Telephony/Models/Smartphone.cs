using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (!number.All(c => Char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberException);
            }

            return number.Length > 7 ? $"Calling... {number}" : $"Dialing... {number}";
        }
        public string Browse(string urls)
        {
            if (urls.Any(c => Char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlException);
            }

            return $"Browsing: {urls}!";
        }

    }
}
