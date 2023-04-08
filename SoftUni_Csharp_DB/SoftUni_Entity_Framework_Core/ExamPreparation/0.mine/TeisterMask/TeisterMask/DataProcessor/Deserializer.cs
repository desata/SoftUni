// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using TeisterMask.Utilities;
    using System.Text;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();

            StringBuilder sb = new StringBuilder();

            var projectDtos = xmlHelper.Deserialize<ImportProjectsDto[]>(xmlString, "Projects");

            ICollection<Project> validProjects = new List<Project>();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out projectOpenDate);
                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = null;

                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime pDueDate;
                    bool isprojectDueDateValid = DateTime.TryParseExact(projectDto.DueDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out pDueDate);

                    if (!isprojectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    projectDueDate = pDueDate;

                }

                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,

                };

                foreach (var t in projectDto.Tasks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool istaskOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out taskOpenDate);
                    if (!istaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool istaskDueDateValid = DateTime.TryParseExact(projectDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out taskDueDate);
                    if (!istaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    
                    if (projectDueDate.HasValue && taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = t.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)t.ExecutionType,
                        LabelType = (LabelType)t.LabelType
                    };

                    project.Tasks.Add(task);
                }

                validProjects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));

            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportEmployeesDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            List<Employee> employees = new List<Employee>();

            foreach (ImportEmployeesDto employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task t = context.Tasks.Find(taskId);

                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    e.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = t
                    });
                }

                employees.Add(e);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}