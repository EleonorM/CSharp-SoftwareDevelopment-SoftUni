namespace _08.MilitaryElite.Models
{
    using _08.MilitaryElite.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString()).AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                sb.AppendLine($"  {repair.ToString().TrimEnd()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
