using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           SoftUniContext dbContext = new SoftUniContext();
            string result = GetEmployeesFullInformation(dbContext);
            Console.WriteLine(result);

            
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.OrderBy(e => e.EmployeeId).ToArray();

            foreach (var employee in employees) 
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
                
            }

            return sb.ToString().TrimEnd();
        }
    }
}