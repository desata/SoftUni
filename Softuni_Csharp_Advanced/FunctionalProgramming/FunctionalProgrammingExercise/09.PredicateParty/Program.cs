using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();



            while (command != "Party!")
            {
                string[] item = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Predicate<string> startsWith = x => x.StartsWith(item[2]);
                Predicate<string> endsWith = x => x.EndsWith(item[2]);
                Predicate<string> lengthFilter = x => x.Length == int.Parse(item[2]);

                
                if (item[0] == "Remove")
                {
                    string arg = item[1];

                    if (arg == "StartsWith")
                    {
                        names.RemoveAll(startsWith);
                    }
                    else if (arg == "EndsWith")
                    {
                        names.RemoveAll(endsWith);
                    }
                    else if (arg == "Length")
                    {
                        
                        names.RemoveAll(lengthFilter);
                    }
                }
                if (item[0] == "Double")
                {
                    List<string> doubledNames = new List<string>();
                    string arg = item[1];

                    if (arg == "StartsWith")
                    {
                        doubledNames = names.FindAll(startsWith);
                        if (!doubledNames.Any())
                        {
                            command = Console.ReadLine();
                            //continue;
                        }
                        else
                        {
                            int index = names.FindIndex(startsWith);
                            names.InsertRange(index, doubledNames);
                        }
                    }
                    else if (arg == "EndsWith")
                    {

                        doubledNames = names.FindAll(endsWith);
                        if (!doubledNames.Any())
                        {

                            command = Console.ReadLine(); 
                        }
                        else
                        {
                            int index = names.FindIndex(endsWith);
                            names.InsertRange(index, doubledNames);
                        }
                    }
                    else if (arg == "Length")
                    {
                        doubledNames = names.FindAll(lengthFilter);
                        if (!doubledNames.Any())
                        {
                            command = Console.ReadLine(); 
                        }
                        else
                        {
                            int index = names.FindIndex(lengthFilter);
                            names.InsertRange(index, doubledNames);
                        }

                    }
                }

                command = Console.ReadLine();
            }
            if (names.Any())
            {
                Console.Write(String.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
