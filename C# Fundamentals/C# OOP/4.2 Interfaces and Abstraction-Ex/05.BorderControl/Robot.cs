namespace _05.BorderControl
{
    public class Robot : Habitant
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
    }
}
