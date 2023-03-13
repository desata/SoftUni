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
            string result = RemoveTown(dbContext);

            Console.WriteLine(result);

        }

        public static string RemoveTown(SoftUniContext context)
        {
            //Write a program that deletes a town with name "Seattle".
            //Also, delete all addresses that are in those towns.
            //Return the number of addresses that were deleted in format "{count} addresses in Seattle were deleted".
            //There will be employees living at those addresses, which will be a problem when trying to delete the addresses.
            //So, start by setting the AddressId of each employee for the given address to null.
            //After all of them are set to null, you may safely remove all the addresses from the context and finally remove the given town.

            var townForDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var address = context.Addresses.Where(a => a.Town!.Name == "Seattle").ToList();

            foreach (var employee in context.Employees)
            {
                if (address.Any(a => a.AddressId == employee.AddressId))
                {
                    employee.AddressId = null;
                }
            }

            int numberOfDeletedAddresses = address.Count;

            context.Addresses.RemoveRange(address);
            context.Towns.Remove(townForDelete);

            context.SaveChanges();
            return $"{numberOfDeletedAddresses} addresses in Seattle were deleted";

        }
    }
}