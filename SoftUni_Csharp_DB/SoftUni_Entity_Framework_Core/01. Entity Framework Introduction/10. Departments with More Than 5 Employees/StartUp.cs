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

            string result = GetDepartmentsWithMoreThan5Employees(dbContext);

            Console.WriteLine(result);

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            //Find all departments with more than 5 employees.
            //Order them by employee count (ascending), then by department name (alphabetically).
            //For each department, print the department name and the manager's first and last name on the first row.
            //Then print the first name, the last name and the job title of every employee on a new row.
            //Order the employees by first name (ascending), then by last name (ascending).

            //Format of the output:
            //For each department print it in the format "<DepartmentName> - <ManagerFirstName>  <ManagerLastName>"
            //for each employee print it in the format "<EmployeeFirstName> <EmployeeLastName> - <JobTitle>".

            StringBuilder sb = new StringBuilder();

            var employee5 = context.Departments
                .Where(a => a.Employees.Count > 5)
                .OrderBy(a => a.Employees.Count)
                .Select(d => new
                {
                    countE = d.Employees.Count,
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employee = d.Employees
                    .Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        e.JobTitle,
                        EmployeeCount = d.Employees.Count

                    })
                    .ToList()
                }).ToList();

            foreach (var em in employee5)
            {
                sb.AppendLine($"{em.DepartmentName} - {em.ManagerFirstName}  {em.ManagerLastName}");

                foreach (var et in em.Employee.OrderBy(e => e.EmployeeFirstName))
                {
                    sb.AppendLine($"{et.EmployeeFirstName} {et.EmployeeLastName} {et.JobTitle}");
                }
            }


            return sb.ToString().TrimEnd();

        }
    }

}