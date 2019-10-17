namespace _01._intro
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //3.Employees Full Information

            //using (var context = new SoftUniContext())
            //{
            //    var emplyees = context.Employees;
            //    foreach (var employee in emplyees)
            //    {
            //        Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            //    }
            //}

            //4.Employees with Salary Over 50 000

            //using (var context = new SoftUniContext())
            //{
            //    var emplyees = context.Employees
            //        .Where(x=>x.Salary>50000)
            //        .OrderBy(n=>n.FirstName);
            //    foreach (var employee in emplyees)
            //    {
            //        Console.WriteLine($"{employee.FirstName}");
            //    }
            //}
        }
    }
}
