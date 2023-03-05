using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = GetAddressesByTown(dbContext);

            Console.WriteLine(result);

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            //Find all addresses, ordered by the number of employees who live there (descending), then by town name (ascending) and finally by address text (ascending).
            //Take only the first 10 addresses.
            //For each address return it in the format "<AddressText>, <TownName> - <EmployeeCount> employees"


            StringBuilder sb = new StringBuilder();

            var adresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town!.Name)
                    .Take(10)
                    .Select(a => new
                    {
                        Text = a.AddressText,
                        TownName = a.Town!.Name,
                        EmployeeCount = a.Employees.Count
                    })
                    .ToList();

            foreach (var a in adresses.OrderByDescending(a => a.EmployeeCount).ThenBy(a => a.TownName).ThenBy(a => a.Text))
            {
                sb.AppendLine($"{a.Text}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();

        }
    }

}