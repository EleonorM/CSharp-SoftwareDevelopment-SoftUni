namespace _03._Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string Model => "488-Spider";

        public string DriverName { get ; set ; }

        public string Break()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Break()}/{this.Gas()}/{this.DriverName}";
        }
    }
}
