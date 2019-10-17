namespace _03.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(int quantityFood)
        {
            this.Weight += 0.25 * quantityFood;
            this.FoodEaten += quantityFood;
        }

        public override string ProduceASound()
        {
            return "Hoot Hoot";
        }
    }
}
