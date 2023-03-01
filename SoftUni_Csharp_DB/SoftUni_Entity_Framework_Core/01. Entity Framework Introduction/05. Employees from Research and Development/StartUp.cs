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
            string result = GetEmployeesFromResearchAndDevelopment(dbContext);



            Console.WriteLine(result);


        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(d => d.Department.Name == "Research and Development")
                .Select(f => new
                {
                    f.FirstName,
                    f.LastName,
                    f.Department.Name,
                    f.Salary
                })
                .OrderBy(s => s.Salary).ThenByDescending(t => t.FirstName).ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }
    }

}