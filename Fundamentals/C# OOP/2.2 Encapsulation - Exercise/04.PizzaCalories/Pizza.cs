namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }


        public int NumberOfToppings { get => toppings.Count; }


        public double TotalCalories()
        {
            return this.toppings.Sum(x => x.CalculateCalories()) + this.Dough.CalculateCalories();
        }

        public void AddTopng(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            if (this.toppings.Count != 0)
            {
                return $"{this.Name} - {this.TotalCalories():f2} Calories.";
            }

            throw new InvalidOperationException("Number of toppings should be in range [0..10].");
        }
    }
}
