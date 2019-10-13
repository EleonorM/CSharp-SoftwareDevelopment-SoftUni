namespace _07.FoodShortage
{
    public class Rebel : Habitant, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Group { get; set; }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
