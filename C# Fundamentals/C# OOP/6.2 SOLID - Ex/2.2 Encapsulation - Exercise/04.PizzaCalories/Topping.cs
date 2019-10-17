using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "sauce" && value.ToLower() != "veggies" && value.ToLower() != "cheese")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            return 2 * this.ToppingTypeModifier() * Weight;
        }

        private double ToppingTypeModifier()
        {
            if (this.ToppingType.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (this.ToppingType.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (this.ToppingType.ToLower() == "cheese")
            {
                return 1.1;
            }
            else if (this.ToppingType.ToLower() == "sauce")
            {
                return 0.9;
            }
            else
            {
                return 1.0;
            }
        }
    }
}
