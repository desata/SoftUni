using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string action = Console.ReadLine();
            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();

            while (action != "Print")
            {
                string[] items = action.Split(';');

                string command = items[0];
                string filterType = items[1];
                string parameter = items[2];

                if (command == "Add filter")
                {

                    allFilters.Add(filterType + parameter, GetPredicate(filterType, parameter));

                }
                else 
                {
                    allFilters.Remove(filterType + parameter);

                }

                action = Console.ReadLine();
            }

            foreach (var (key, value) in allFilters)
            {
                names.RemoveAll(value);
            }
            Console.WriteLine(string.Join(" ", names));  
        }

        private static Predicate<string> GetPredicate(string filterType, string parameter)
        {
            if (filterType == "Starts with")
            {
                return x => x.StartsWith(parameter);

            }
            if (filterType == "Ends with")
            {
                return x => x.EndsWith(parameter);

            }
            if (filterType == "Contains")
            {
                return x => x.Contains(parameter);

            }
            
                int intParameter = int.Parse(parameter);

                return x => x.Length == intParameter;
            
            
        }
    }
}
