using System;

namespace sumOfOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 2*n -1;

            for (int i = 1; i <= count; i+=2)
            {
                Console.WriteLine(i);
                
                sum = sum + i;
            }

            
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
/*9.	Sum of Odd Numbers
Write a program that prints the next n odd numbers (starting from 1) and on the last row prints the sum of them.
Input
On the first line, you will receive a number – n. This number shows how many odd numbers you should print.
Output
Print the next n odd numbers, starting from 1, separated by new lines. On the last line, print the sum of these numbers.
Constraints
•	n will be in the interval [1…100]
*/