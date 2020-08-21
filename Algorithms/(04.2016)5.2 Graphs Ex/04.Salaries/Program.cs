namespace _04.Salaries
{
    using System;
    using System.Linq;

    public class Program
    {

        private static Employee[] employees;

        public static void Main()
        {
            ReadInput();

            var bossEmpolyees = employees.Where(x => x.Managers.Count == 0);
            foreach (var bossEmpolyee in bossEmpolyees)
            {
                DFS(bossEmpolyee);
            }
            Console.WriteLine(employees.Sum(x => x.Salary));
        }

        private static void DFS(Employee employee)
        {
            if (employee.Salary != 0)
            {
                return;
            }

            foreach (var managedEmployee in employee.ManagedEmployees)
            {
                DFS(managedEmployee);
            }

            if (employee.ManagedEmployees.Count == 0)
            {
                employee.Salary = 1;
            }
            else
            {
                employee.Salary = employee.ManagedEmployees.Sum(x => x.Salary);
            }
        }

        private static void ReadInput()
        {
            var employeesCount = int.Parse(Console.ReadLine());
            employees = new Employee[employeesCount];
            for (int i = 0; i < employeesCount; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = new Employee();
                }

                var employeeManager = Console.ReadLine().ToCharArray();
                for (int col = 0; col < employeeManager.Length; col++)
                {
                    if (employeeManager[col] == 'Y')
                    {
                        if (employees[col] == null)
                        {
                            employees[col] = new Employee();
                        }
                        employees[i].ManagedEmployees.Add(employees[col]);
                        employees[col].Managers.Add(employees[i]);
                    }
                }
            }
        }
    }
}
