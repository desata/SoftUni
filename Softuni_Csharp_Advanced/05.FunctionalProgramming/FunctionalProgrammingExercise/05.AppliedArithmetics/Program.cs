using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that executes some mathematical operations on a given collection. On the first line, you are given a list of numbers. On the next lines you are passed different commands that you need to apply to all the numbers in the list:
            //•	"add"->add 1 to each number
            //•	"multiply"->multiply each number by 2
            //•	"subtract"->subtract 1 from each number
            //•	"print"->print the collection
            //•	"end"->ends the input
            // Note: Use functions.


            Action<int[]> addNum = x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] += 1;
                }
            };

            Action<int[]> subtractNum = x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] -= 1;
                }
            }; 
            Action<int[]> multiplyNum = x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] *= 2;
                }
            };
            Action<int[]> printNum = x => Console.WriteLine(String.Join(" ", x));
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    addNum(numbers);
                }
                else if (command == "subtract")
                {
                    subtractNum(numbers);
                }
                else if (command == "multiply")
                {
                    multiplyNum(numbers);
                }
                else if (command == "print")
                {
                    printNum(numbers);
                }

                command = Console.ReadLine();
            }

        }

    }
}
