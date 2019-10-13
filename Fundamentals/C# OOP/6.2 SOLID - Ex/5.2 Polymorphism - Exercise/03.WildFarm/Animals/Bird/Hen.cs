namespace _03.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(int quantityFood)
        {
            this.Weight += 0.35 * quantityFood;
            this.FoodEaten += quantityFood;
        }

        public override string ProduceASound()
        {
            return "Cluck"; 
        }
    }
}
