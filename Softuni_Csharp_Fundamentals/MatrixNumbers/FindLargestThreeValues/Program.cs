using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int largest = int.MinValue;
        int secondLargest = int.MinValue;
        int thirdLargest = int.MinValue;

        for (int j = 1; j <= N; j++)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > largest)
            {
                thirdLargest = secondLargest;
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest)
            {
                thirdLargest = secondLargest;
                secondLargest = num;
            }
            else if (num > thirdLargest)
            {
                thirdLargest = num;
            }
        }
        Console.WriteLine($"{largest}, {secondLargest} and {thirdLargest}");
    }
}
