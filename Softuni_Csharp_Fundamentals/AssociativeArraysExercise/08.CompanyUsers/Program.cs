using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");

            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string companyName = input[0];
                string employeeId = input[1];

                if (!company.ContainsKey(companyName))
                {
                    company.Add(companyName, new List<string>());
                }
                if (!company[companyName].Contains(employeeId))
                {
                    company[companyName].Add(employeeId);
                }

                input = Console.ReadLine().Split(" -> ");
            }
            foreach (var item in company)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var id in item.Value)
                {

                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}


