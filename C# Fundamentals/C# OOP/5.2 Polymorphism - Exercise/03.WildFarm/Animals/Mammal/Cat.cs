namespace _03.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void EatFood(int quantityFood)
        {
            this.Weight += 0.3 * quantityFood;
            this.FoodEaten += quantityFood;
        }

        public override string ProduceASound()
        {
            return "Meow";
        }
    }
}
