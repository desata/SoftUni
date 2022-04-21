using System;

namespace T08._Equal_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Дадени са 2*n-на брой числа.
            //Първото и второто формират двойка, третото и четвъртото също и т.н.
            //Всяка двойка има стойност – сумата от съставящите я числа.
            //Напишете програма, която проверява дали всички двойки имат еднаква стойност или печата максималната разлика между две последователни двойки. Ако всички двойки имат еднаква стойност, отпечатайте "Yes, value={Value}" + стойността. В противен случай отпечатайте "No, maxdiff={Difference}" + максималната разлика. 

            int number = int.Parse(Console.ReadLine());
            int oldPairSum = int.MinValue;
            int pairSum = 0;
            int diff = 0;
            int maxdiff = 0;

            for (int i = 0; i < number; i++)
            {
                int numberOne = int.Parse(Console.ReadLine());
                int numberTwo = int.Parse(Console.ReadLine());
                pairSum = numberOne + numberTwo;
                if (oldPairSum == int.MinValue)
                {
                    oldPairSum = pairSum;
                }
                if (oldPairSum != pairSum)
                {
                    diff = Math.Abs(oldPairSum - pairSum);
                    if (diff > maxdiff)
                    {
                        maxdiff = diff;
                    }
                }
                oldPairSum = pairSum;
            }
            if (maxdiff == 0)
            {
                Console.WriteLine($"Yes, value={pairSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
