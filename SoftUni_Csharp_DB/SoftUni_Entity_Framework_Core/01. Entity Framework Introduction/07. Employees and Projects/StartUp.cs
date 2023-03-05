using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = GetEmployeesInPeriod(dbContext);

            Console.WriteLine(result);

        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            //Find the first 10 employees who have projects started in the period 2001 - 2003 (inclusive). Print each employee's first name, last name, manager's first name and last name. Then return all of their projects in the format "--<ProjectName> - <StartDate> - <EndDate>", each on a new row. If a project has no end date, print "not finished" instead.

            StringBuilder sb = new StringBuilder();

            var employeeProjects = context.Employees
               .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Project = e.EmployeesProjects.
                    Where(ep => ep.Project!.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project!.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                    ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToArray()
                })
                .ToArray();


            foreach (var eep in employeeProjects)
            {
                sb.AppendLine($"{eep.FirstName} {eep.LastName} - Manager: {eep.ManagerFirstName} {eep.ManagerLastName}");
                foreach (var p in eep.Project)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }                

            }

            return sb.ToString().TrimEnd();

        }
    }

}