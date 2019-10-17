namespace _03.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void EatFood(int quantityFood)
        {
            this.Weight += 0.4 * quantityFood;
            this.FoodEaten += quantityFood;
        }

        public override string ProduceASound()
        {
           return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
