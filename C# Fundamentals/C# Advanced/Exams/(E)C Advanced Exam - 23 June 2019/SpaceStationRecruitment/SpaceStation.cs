namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            var targetAstronaut = data.FirstOrDefault(x => x.Name == name);
            if (targetAstronaut != null)
            {
                data.Remove(targetAstronaut);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
