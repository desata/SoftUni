using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool isChange = false;

            while (command[0] != "end")
            {

                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChange = true;
                        break;
                    case "Contains":
                        Console.WriteLine(numbers.Contains(int.Parse(command[1])) ? "Yes" : "No such number");
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string result = "";

                        switch (command[1])
                        {
                            case "<":
                                result = string.Join(" ", numbers.Where(n => n < int.Parse(command[2])));
                                break;
                            case ">":
                                result = string.Join(" ", numbers.Where(n => n > int.Parse(command[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", numbers.Where(n => n >= int.Parse(command[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", numbers.Where(n => n <= int.Parse(command[2])));
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine(result);
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (isChange)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}