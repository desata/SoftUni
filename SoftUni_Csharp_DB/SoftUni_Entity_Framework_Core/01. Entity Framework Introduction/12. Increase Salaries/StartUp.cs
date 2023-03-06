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
            string result = IncreaseSalaries(dbContext);

            Console.WriteLine(result);

        }

        public static string IncreaseSalaries(SoftUniContext context)
        {

            //Write a program that increases salaries of all employees that are in the Engineering, Tool Design, Marketing, or Information Services department by 12%.
            //Then return first name, last name and salary (2 symbols after the decimal separator) for those employees, whose salary was increased.
            //Order them by first name (ascending), then by last name (ascending).
            //Format of the output.

            StringBuilder sb = new StringBuilder();

            var salaryIncrease = context.Employees
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Where(a => a.Department.Name == "Engineering" || a.Department.Name == "Tool Design" || a.Department.Name == "Marketing" || a.Department.Name == "Information Services")

                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName =e.LastName,
                    Salary = e.Salary * 1.12m,
                    Department = e.Departments                  
                }).ToList();


            foreach (var s in salaryIncrease)
            {
                sb.AppendLine($"{s.FirstName} {s.LastName} (${s.Salary:F2})");
            }

            return sb.ToString().TrimEnd();

        }
    }
}