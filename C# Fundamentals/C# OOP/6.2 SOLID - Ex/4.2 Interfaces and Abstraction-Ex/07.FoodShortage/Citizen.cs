namespace _07.FoodShortage
{
    public class Citizen : Habitant
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public string Birthday { get; set; }

        public string Id { get; set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
