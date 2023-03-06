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
            string result = DeleteProjectById(dbContext);

            Console.WriteLine(result);

        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            //Let's delete the project with id 2.
            //Then, take 10 projects and return their names, each on a new line.
            //Remember to restore your database after this task.

            IQueryable<EmployeeProject> epToDelete = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(epToDelete);

            Project projectToDelete = context.Projects.Find(2)!;
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            string[] projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();
            return String.Join(Environment.NewLine, projectNames);

        }
    }
}