namespace TeisterMask.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects =
                 context
                 .Projects
                 .Where(x => x.Tasks.Any())
                 .Select(x => new ExportProjectDto
                 {
                     TasksCount = x.Tasks.Count(),
                     ProjectName = x.Name,
                     HasEndDate = x.DueDate == null ? "No" : "Yes",
                     Tasks = x.Tasks.Select(y => new TaksDto
                     {
                         Name = y.Name,
                         Label = y.LabelType.ToString()
                     })
                     .OrderBy(y => y.Name)
                     .ToArray()
                 })
                 .OrderByDescending(x => x.TasksCount)
                 .ThenBy(x => x.ProjectName)
                 .ToArray();

            var xmlSeriazlizer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            xmlSeriazlizer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                            .Employees
                            .Where(x => x.EmployeesTasks.Any(y => y.Task.OpenDate >= date))
                            .Select(x => new
                            {
                                Username = x.Username,
                                Tasks = x.EmployeesTasks
                                .Where(y => y.Task.OpenDate >= date)
                                .OrderByDescending(y => y.Task.DueDate)
                                .ThenBy(y => y.Task.Name)
                                .Select(t => new
                                {
                                    TaskName = t.Task.Name,
                                    OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                    DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                    LabelType = t.Task.LabelType.ToString(),
                                    ExecutionType = t.Task.ExecutionType.ToString(),
                                }),
                            })
                            .OrderByDescending(p => p.Tasks.Count())
                            .ThenBy(p => p.Username)
                            .Take(10)
                            .ToArray();

            var jsonResult = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }
    }
}