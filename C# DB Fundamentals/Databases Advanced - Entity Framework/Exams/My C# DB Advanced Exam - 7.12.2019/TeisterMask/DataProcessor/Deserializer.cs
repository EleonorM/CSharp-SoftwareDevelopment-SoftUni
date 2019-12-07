namespace TeisterMask.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));

            var projectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projects = new List<Project>();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? duedateProject;
                var openDateProject = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (string.IsNullOrEmpty(projectDto.DueDate))
                {
                    duedateProject = null;
                }
                else
                {
                    duedateProject = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDateProject,
                    DueDate = duedateProject,
                };

                foreach (var currentTask in projectDto.Tasks)
                {
                    if (!IsValid(currentTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var dueDateTask = DateTime.ParseExact(currentTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var openDateTask = DateTime.ParseExact(currentTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (openDateTask < openDateProject)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDateTask > duedateProject)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var lTypes = new List<int>();
                    foreach (var t in Enum.GetValues(typeof(LabelType)))
                    {
                        lTypes.Add((int)t);
                    }

                    var eTypes = new List<int>();
                    foreach (var t in Enum.GetValues(typeof(ExecutionType)))
                    {
                        eTypes.Add((int)t);
                    }

                    if (!lTypes.Contains(currentTask.LabelType) || !eTypes.Contains(currentTask.ExecutionType))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    var labelType = (LabelType)currentTask.LabelType;
                    var executionType = (ExecutionType)currentTask.ExecutionType;
                    
                    var task = new Task
                    {
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        Name = currentTask.Name,
                        LabelType = labelType,
                        ExecutionType = executionType
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            var employees = new List<Employee>();
            var sb = new StringBuilder();
            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Phone = employeeDto.Phone,
                    Email = employeeDto.Email,
                };

                var taskIdDist = employeeDto.Tasks.Distinct();
                foreach (var taskId in taskIdDist)
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == taskId);
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var empTask = new EmployeeTask
                    {
                        Employee = employee,
                        Task = task
                    };
                    employee.EmployeesTasks.Add(empTask);
                }
                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
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