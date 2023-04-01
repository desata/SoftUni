namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AutoMapper;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Utils;
    using SoftJail.DataProcessor.ImportDto;
    using System.Runtime.CompilerServices;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString, Mapper mapper)
        {
            StringBuilder sb = new StringBuilder();

            var departamentDtos = JsonConvert.DeserializeObject<ImportDepartamentWithCellsDto[]>(jsonString);

            ICollection<Department> validDepartments = new List<Department>();


            foreach (var departamentDto in departamentDtos)
            {
                if (!IsValid(departamentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!departamentDto.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }
                
                if (!departamentDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = departamentDto.Name,

                };

                foreach (var cellDto in departamentDto.Cells)
                {
                    Cell cell = Mapper.Map<Cell>(cellDto);

                    department.Cells.Add(cell);
                }

                validDepartments.Add(department);

                sb.AppendLine(String.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));

            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}