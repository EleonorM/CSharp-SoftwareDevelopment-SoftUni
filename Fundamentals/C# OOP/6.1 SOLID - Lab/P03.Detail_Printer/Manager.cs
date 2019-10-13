namespace P03.DetailPrinter
{
    using P03.Detail_Printer;
    using System;
    using System.Collections.Generic;

    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine(string.Join(Environment.NewLine, this.Documents));
        }
    }
}
