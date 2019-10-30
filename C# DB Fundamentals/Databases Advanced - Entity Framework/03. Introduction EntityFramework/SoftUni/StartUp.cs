namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesFullInformation(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var emplyees = context.Employees;
            foreach (var employee in emplyees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Select(e => new { e.FirstName, e.Salary })
                    .Where(x => x.Salary > 50000)
                    .OrderBy(n => n.FirstName);
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .Where(d => d.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                Town = context.Towns.Find(4)
            };

            var employeeNakov = context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
            employeeNakov.Address = address;
            context.SaveChanges();

            var sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new { e.Address.AddressText, e.AddressId })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(pe => pe.Project.StartDate.Year > 2000 && pe.Project.StartDate.Year < 2004))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Manager = new
                    {
                        e.Manager.FirstName,
                        e.Manager.LastName
                    },
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();


            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");
                foreach (var prj in employee.Projects)
                {
                    sb.AppendLine($"--{prj.Name} - {prj.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {(prj.EndDate != null ? prj.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished")}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    Employee = a.Employees.Count
                })
                .OrderByDescending(e => e.Employee)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Employee} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employee = context
                .Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => p.Project).OrderBy(p => p.Name)
                })
                .Where(e => e.EmployeeId == 147)
                .FirstOrDefault();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context
                .Departments
                .Select(d => new
                {
                    d.Name,
                    Manager = new
                    {
                        d.Manager.FirstName,
                        d.Manager.LastName
                    },
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName),
                    d.Employees.Count
                })
                .Where(d => d.Count > 5)
                .OrderBy(d => d.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName}  {department.Manager.LastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context
                .Projects
                .Select(p => new
                {
                    p.Description,
                    p.Name,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList()
                .OrderBy(d => d.Name);

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(d => d.Department.Name == "Tool Design"
                || d.Department.Name == "Engineering"
                || d.Department.Name == "Marketing"
                || d.Department.Name == "Information Services");

            foreach (var empl in employees)
            {
                empl.Salary += empl.Salary * 0.12m;
            }

            context.SaveChanges();
            var employeesToPrint = employees
                 .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                 .OrderBy(e => e.FirstName)
                 .ThenBy(e => e.LastName);

            foreach (var employee in employeesToPrint)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var idToDelete = 2;
            var project = context
                .Projects
                .Find(idToDelete);
            var emplInEmplProj = context
                .EmployeesProjects
                .Where(p => p.ProjectId == idToDelete);

            foreach (var employee in emplInEmplProj)
            {
                context.EmployeesProjects.Remove(employee);
            }
            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context
                .Projects
                .Select(p => p.Name)
                .Take(10);

            foreach (var prj in projects)
            {
                sb.AppendLine(prj);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var townNameToDelete = "Seattle";
            var town = context
                .Towns
                .First(t => t.Name == townNameToDelete);

            var addressesInTown = context
                .Addresses
                .Where(a => a.TownId == town.TownId)
                .ToList();

            var employeesInTown = context
                .Employees
                .Where(e => addressesInTown.Contains(e.Address));

            foreach (var empl in employeesInTown)
            {
                empl.AddressId = null;
            }

            foreach (var address in addressesInTown)
            {
                address.TownId = null;
            }

            context.Towns.Remove(town);
            context.SaveChanges();
            sb.AppendLine($"{addressesInTown.Count} addresses in Seattle were deleted");
            return sb.ToString().TrimEnd();
        }
    }
}
