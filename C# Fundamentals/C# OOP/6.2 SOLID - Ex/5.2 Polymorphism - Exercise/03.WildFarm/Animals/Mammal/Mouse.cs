namespace _03.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void EatFood(int quantityFood)
        {
            this.Weight += 0.1 * quantityFood;
            this.FoodEaten += quantityFood;
        }

        public override string ProduceASound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
