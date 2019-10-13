namespace _03.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void EatFood(int quantityFood)
        {
            this.Weight += 1 * quantityFood;
            this.FoodEaten += quantityFood;
        }

        public override string ProduceASound()
        {
            return "ROAR!!!";
        }
    }
}
