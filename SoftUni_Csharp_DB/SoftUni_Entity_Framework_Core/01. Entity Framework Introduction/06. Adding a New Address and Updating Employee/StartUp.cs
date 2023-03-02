using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
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
            string result = AddNewAddressToEmployee(dbContext);

            Console.WriteLine(result);


        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            //Create a new address with the text "Vitoshka 15" and TownId = 4. Set that address to the employee with last the name "Nakov".
            //Then order by descending all the employees by their Address' Id, take 10 rows and from them, take the AddressText.
            //Return the results each on a new line:

            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4

            };

            var employee = context.Employees.FirstOrDefault(d => d.LastName == "Nakov");
            employee.Address = newAddress;

            context.SaveChanges();

            var employeeAdresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employeeAdresse in employeeAdresses)
            {
                sb.AppendLine(employeeAdresse);
            }
            
            return sb.ToString().TrimEnd();

        }
    }

}