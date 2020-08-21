namespace _04.Salaries
{
    using System.Collections.Generic;

    public class Employee
    {
        public List<Employee> Managers;

        public List<Employee> ManagedEmployees;

        public int Salary { get; set; }

        public Employee()
        {
            Managers = new List<Employee>();
            ManagedEmployees = new List<Employee>();
        }
    }
}
