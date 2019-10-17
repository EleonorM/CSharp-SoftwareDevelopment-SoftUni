namespace Restaurant.Food
{
    public class Cake : Dessert
    {
        private const double Grams = 250;

        private const double Calories = 1000;

        private const decimal PriceCake = 5m;

        public Cake(string name) : base(name, PriceCake, Grams, Calories)
        {
        }
    }
}
