namespace _06.BirthdayCelebrations
{
    public class Citizen : Habitant
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}
