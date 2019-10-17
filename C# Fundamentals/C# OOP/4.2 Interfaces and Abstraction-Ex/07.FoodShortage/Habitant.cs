namespace _07.FoodShortage
{
    public abstract class Habitant:IBuyer
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public int Food { get; set; }

        public abstract void BuyFood();
    }
}
