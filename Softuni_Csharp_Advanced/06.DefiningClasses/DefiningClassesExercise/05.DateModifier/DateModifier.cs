using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class DateModifier
    {
        public static int CalculateDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            int result = Math.Abs((first - second).Days);
                       
            return result;

        }
    }
}
