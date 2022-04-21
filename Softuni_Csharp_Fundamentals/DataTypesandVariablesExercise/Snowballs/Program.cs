using System;
using System.Numerics;

namespace Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger snowballValue = 0;
            BigInteger snowballSnow = 0;
            BigInteger snowballTime = 0;
            int snowballQuality = 0;
            string rezult = "";


            for (int i = 1; i <= countOfSnowballs; i++)
            {
                snowballSnow = BigInteger.Parse(Console.ReadLine());
                snowballTime = BigInteger.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                BigInteger tempSnowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);


                if (snowballValue <= tempSnowballValue)
                {
                    snowballValue = tempSnowballValue;
                    rezult = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";

                }

            }
            Console.WriteLine(rezult);
        }
    }
}
