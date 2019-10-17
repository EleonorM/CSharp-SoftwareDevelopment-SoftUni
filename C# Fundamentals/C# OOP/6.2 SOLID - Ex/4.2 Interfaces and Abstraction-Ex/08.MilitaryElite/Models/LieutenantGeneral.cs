namespace _08.MilitaryElite.Models
{
    using _08.MilitaryElite.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params Soldier[] privates) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddPrivate(ISoldier soldier)
        {
            this.privates.Add(soldier);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString()).AppendLine("Privates:");
            foreach (var priv in privates)
            {
                sb.AppendLine($"  {priv.ToString().TrimEnd()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

