namespace FacadeDemo
{
    public class CarAddressBulider : CarBuilderFacade
    {
        public CarAddressBulider(Car car)
        {
            Car = car;
        }

        public CarAddressBulider InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddressBulider AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
