namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
                this.AggressiveMode = false;
            }
            else
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.AggressiveMode == true)
            {
                sb.AppendLine($" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine($" *Aggressive: OFF");
            }

            return sb.ToString();
        }
    }
}
