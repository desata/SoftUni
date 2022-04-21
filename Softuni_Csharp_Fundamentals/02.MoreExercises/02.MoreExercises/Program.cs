using System;

namespace _02.MoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a program that receives three real numbers and sorts them in descending order. Print each number on a new line.
            int first = int.MinValue;
            int second = int.MinValue;
            int third = int.MinValue;

            for (int i = 0; i < 3; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num > first)
                {
                    third = second;
                    second = first;
                    first = num;
                }
                else if (num > second)
                {
                    third = second;
                    second = num;
                }
                else if (num > third)
                {
                    third = num;
                }
                
            }
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);


        }
    }
}
