using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttributes : MyValidationAttribute
    {

        private int minValue;
        private int maxValue;

        public MyRangeAttributes(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int inputInteger = (int)obj;

            if (inputInteger < minValue || inputInteger > maxValue)
            {
                return false;
            }
            return true;
        }
    }
}
