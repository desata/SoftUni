using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System.Diagnostics.Metrics;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            //string result = GetEmployeesFullInformation(dbContext);
            string result = GetEmployeesWithSalaryOver50000(dbContext);
            Console.WriteLine(result);


        }
        //public static string GetEmployeesFullInformation(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees.OrderBy(e => e.EmployeeId).ToArray();

        //    foreach (var employee in employees) 
        //    {
        //        sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            //Your task is to extract all employees with salary over 50000.
            //Return their first names and salaries in format "{firstName} – {salary}".
            //Salary must be rounded to 2 symbols, after the decimal separator.
            //Sort them alphabetically by first name.

            //Brian - 72100.00

            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Salary>50000).OrderBy(s => s.FirstName).ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }
    }

}