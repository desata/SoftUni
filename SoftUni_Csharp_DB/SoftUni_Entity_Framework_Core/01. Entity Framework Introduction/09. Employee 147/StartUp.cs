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
            //string result = GetAddressesByTown(dbContext);
            string result = GetEmployee147(dbContext);

            Console.WriteLine(result);

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            //Get the employee with id 147.
            //Return only his/her first name, last name, job title and projects (print only their names).
            //The projects should be ordered by name (ascending).
            //Format of the output.

            StringBuilder sb = new StringBuilder();

            var Employee147 = context.Employees
                .Where(a => a.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Project = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project!.Name,
                    }
                    ).ToList()
                }
                ).ToList();

            foreach (var e in Employee147)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var p in e.Project.OrderBy(p => p.ProjectName))
                {
                    sb.AppendLine($"{p.ProjectName}");
                }
            }


            return sb.ToString().TrimEnd();

        }
    }

}