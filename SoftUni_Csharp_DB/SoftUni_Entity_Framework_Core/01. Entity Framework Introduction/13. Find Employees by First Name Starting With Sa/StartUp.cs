using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            string result = GetEmployeesByFirstNameStartingWithSa(dbContext);

            Console.WriteLine(result);

        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            //Write a program that finds all employees whose first name starts with "Sa".
            //Return their first, last name, their job title and salary rounded to 2 symbols after the decimal separator in the format given in the example below.
            //Order them by the first name, then by last name (ascending).

            StringBuilder sb = new StringBuilder();

            var salaryIncrease = context.Employees
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Where(a => a.FirstName.StartsWith("Sa"))

                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName =e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary                 
                }).ToList();


            foreach (var s in salaryIncrease)
            {
                sb.AppendLine($"{s.FirstName} {s.LastName} - {s.JobTitle} - (${s.Salary:F2})");
            }

            return sb.ToString().TrimEnd();

        }
    }
}