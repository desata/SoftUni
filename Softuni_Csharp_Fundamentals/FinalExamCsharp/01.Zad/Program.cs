using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Zad 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //01. String Manipulator
            string list = Console.ReadLine();
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input[0] == "Translate")
                {
                    string characterInput = input[1];
                    string replacementInput = input[2];
                    list = list.Replace(characterInput, replacementInput);
                    Console.WriteLine(list);
                }
                if (input[0] == "Includes")
                {
                    string substring = input[1];
                    if (list.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                                    
                }
                if (input[0] == "Start")
                {
                    string substring = input[1];

                    if (list.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                if (input[0] == "Lowercase")
                {
                    list = list.ToLower();
                    Console.WriteLine(list);
                }
                if (input[0] == "FindIndex")
                {
                    string characterInput = input[1];
                    int index = list.LastIndexOf(characterInput);
                    Console.WriteLine(index);
                }
                if (input[0] == "Remove")
                {
                    int startIndex = int.Parse(input[1]);
                    int count = int.Parse(input[2]);

                    list= list.Remove(startIndex, count);
                    Console.WriteLine(list);
                }


                input = Console.ReadLine().Split();
            }
           // Console.WriteLine(list);
        }
    }
}
