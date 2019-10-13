namespace _04.PizzaCalories
{
    using System;

    public class Engine
    {
        public void Run()
        {

            try
            {
                var pizzaInfo = Console.ReadLine().Split();
                var pizza = new Pizza(pizzaInfo[1]);
                while (true)
                {
                    var input = Console.ReadLine().Split();
                    if (input[0] == "END")
                    {
                        break;
                    }
                    if (input[0] == "Dough")
                    {
                        var flourType = input[1];
                        var bakingTechnique = input[2];
                        var doughWeight = double.Parse(input[3]);
                        var dought = new Dough(flourType, bakingTechnique, doughWeight);
                        pizza.Dough = dought;
                    }
                    else if (input[0] == "Topping")
                    {
                        var toppingType = input[1];
                        var toppingWeight = double.Parse(input[2]);
                        var topping = new Topping(toppingType, toppingWeight);
                        pizza.AddTopng(topping);
                    }
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
