using System;

namespace _01._USD_to_BGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Напишете програма за конвертиране на щатски долари(USD) в български лева(BGN).
            // Използвайте фиксиран курс между долар и лев: 1 USD = 1.79549 BGN.

            decimal BGN = 1.79549m;
            decimal USD = decimal.Parse(Console.ReadLine());

            decimal result = BGN * USD;

            Console.WriteLine(result);
        }
    }
}
