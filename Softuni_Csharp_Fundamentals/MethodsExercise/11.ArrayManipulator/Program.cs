using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	On the first line, the initial array is received as a line of integers, separated by a single space
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command = "";


            //•	On the next lines, until the command "end" is received, you will receive the array manipulation commands
            while (command != "end")
            {
                command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                if (command.Contains("exchange"))
                {
                    Exchange(command, numbers);
                  
                }
            }

        }
        static string Exchange(string command, int[] numbers)
        {
            string result = "";
            string second = command.Split(' ')[1];
            int rotations = int.Parse(second);
            if (rotations < numbers.Length)
            {
                for (int i = 0; i < rotations; i++)
                {
                    int temp = numbers[0];

                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        numbers[j] = numbers[j + 1];
                    }
                    numbers[numbers.Length - 1] = temp;
                }

                result = (String.Join(" ", numbers)); ;

            }
            else
            {
                result = "Invalid index";

            }
            Console.WriteLine(result);
            return result;
        }


    }
}
