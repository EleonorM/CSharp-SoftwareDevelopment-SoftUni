namespace _08.MilitaryElite.Models
{
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Enumerations;
    using _08.MilitaryElite.Exceptions;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            bool parsed = Enum.TryParse(corpsStr, out Corps corps);

            if (!parsed)
            {
                throw new InvalidCorseException();
            }
            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine+ $"Corps: {this.Corps}";
        }
    }
}
