namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Salad
    {
        private List<Vegetable> vegetables;
        public Salad(string name)
        {
            this.Name = name;
            this.vegetables = new List<Vegetable>();
        }
        public string Name { get; set; }

        public int GetTotalCalories()
        {
            return vegetables.Sum(x => x.Calories);
        }

        public int GetProductCount()
        {
            return vegetables.Count;
        }

        public void Add(Vegetable product)
        {
            vegetables.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"* Salad { this.Name} is { this.GetTotalCalories() } calories and have { this.GetProductCount()} products:");
            foreach (var vegetable in vegetables)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
