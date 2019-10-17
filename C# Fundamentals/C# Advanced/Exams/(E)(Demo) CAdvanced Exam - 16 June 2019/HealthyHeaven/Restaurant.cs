namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> data;
        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }
        public string Name { get; set; }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }
        public bool Buy(string name)
        {
            var isThereSalad = false;
            var targetSalad = data.FirstOrDefault(x => x.Name == name);
            if (targetSalad != null)
            {
                isThereSalad = true;
                data.Remove(targetSalad);
            }

            return isThereSalad;
        }

        public Salad GetHealthiestSalad()
        {
            return data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} have {this.data.Count()} salads:");
            foreach (var salad in data)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}