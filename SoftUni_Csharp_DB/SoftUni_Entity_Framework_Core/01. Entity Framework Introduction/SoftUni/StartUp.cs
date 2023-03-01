using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine("Connection success!");
        }
    }
}