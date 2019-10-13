namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {

            if (this.DefenseMode == true)
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.DefenseMode == true)
            {
                sb.AppendLine(" *Defense: ON");
            }
            else
            {
                sb.AppendLine(" *Defense: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
