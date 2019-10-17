namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public void IncreaseSalary(decimal persentage)
        {
            if (this.Age < 30)
            {
                persentage = persentage / 2;
            }

            this.Salary = this.Salary * (1 + (0.01m * persentage));
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
