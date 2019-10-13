namespace P03.DetailPrinter
{
    using P03.Detail_Printer;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                employee.PrintInfo();
            }
        }
    }
}
