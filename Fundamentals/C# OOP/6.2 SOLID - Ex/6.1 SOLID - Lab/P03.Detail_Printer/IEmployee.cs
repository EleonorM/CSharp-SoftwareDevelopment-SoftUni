namespace P03.Detail_Printer
{
    using System;
    public class IEmployee
    {
        public IEmployee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual void PrintInfo()
        {
            Console.WriteLine(this.Name);
        }
    }
}
