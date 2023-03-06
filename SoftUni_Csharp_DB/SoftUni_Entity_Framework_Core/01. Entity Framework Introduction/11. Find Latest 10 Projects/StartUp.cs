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
            string result = GetLatestProjects(dbContext);

            Console.WriteLine(result);

        }

        public static string GetLatestProjects(SoftUniContext context)
        {

            //Write a program that returns information about the last 10 started projects.
            //Sort them by name lexicographically and return their name, description and start date, each on a new row. 


            StringBuilder sb = new StringBuilder();

            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(ep => new
                {
                        ProjectName = ep.Name,
                        Description = ep.Description,
                        StartDate = ep.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),

                })
                .ToArray();


                foreach (var p in latestProjects)
                {
                    sb.AppendLine($"{p.ProjectName}");
                    sb.AppendLine($"{p.Description}");
                    sb.AppendLine($"{p.StartDate}");
                }


            return sb.ToString().TrimEnd();

        }
    }

}