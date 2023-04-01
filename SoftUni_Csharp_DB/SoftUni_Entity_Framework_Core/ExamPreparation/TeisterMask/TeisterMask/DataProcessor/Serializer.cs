namespace TeisterMask.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using AutoMapper;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using ExportDto;

    using Formatting = Newtonsoft.Json.Formatting;
    using TeisterMask.DataProcessor.ImportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            ExportProjectDto[] projects = context
                .Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
            .Select(p => new ExportProjectDto()
            {
                Name = p.Name,
                HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                TasksCount = p.Tasks.Count,
                Tasks = p.Tasks
                    .ToArray()
                    .Select(t => new ExportProjectTaskDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
            })
            .OrderByDescending(p => p.TasksCount)
            .ThenBy(p => p.Name)
            .ToArray();

            /*ExportProjectDto[] projectDtos = Mapper.Map<ExportProjectDto[]>(projects)
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();*/

            xmlSerializer.Serialize(sw, projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .ToArray()
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}