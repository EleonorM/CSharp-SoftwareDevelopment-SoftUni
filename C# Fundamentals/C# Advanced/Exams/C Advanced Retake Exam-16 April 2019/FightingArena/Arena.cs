namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena()
        {
            this.gladiators = new List<Gladiator>();
        }

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string Name { get; set; }

        public int Count { get => this.gladiators.Count; }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var targetGladiator = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(targetGladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return gladiators.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return gladiators.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return gladiators.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Count} gladiators are participating.".ToString();
        }
    }
}
