using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidatorProgram
{
    public class Summator
    {
        public int SumOfDigits(long a)
        {
            int sum = 0;
            a = Math.Abs(a);
            while (a > 0)
            {
                sum += (int)(a % 10);
                a /= 10;
            }

            return sum;
        }
    }
}
