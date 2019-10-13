namespace _01._Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var firm = new List<Employee>();
            var maxSalaryIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var salary = double.Parse(input[1]);
                var department = input[2];
                var employee = new Employee();
                employee.Name = name;
                employee.Department = department;
                employee.Salary = salary;
                firm.Add(employee);
                if (salary > firm[maxSalaryIndex].Salary)
                {
                    maxSalaryIndex = i;
                }
            }

            var result = new List<Employee>();

            foreach (var item in firm)
            {
                if (item.Department == firm[maxSalaryIndex].Department)
                {
                    result.Add(item);
                }
            }

            result = result.OrderBy(o => o.Salary).Reverse().ToList();
            Console.WriteLine($"Highest Average Salary: {result[0].Department}");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} {item.Salary:F2}");
            }
        }
    }

    public class Employee
    {
        public string Name;
        public double Salary;
        public string Department;
    }
}
