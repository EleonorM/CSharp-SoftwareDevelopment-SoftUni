namespace SoftUniParking
{
    using System.Collections.Generic;

    public class Parking
    {
        private Dictionary<string,Car> cars;
        private int capacity;

        public int Count { get { return cars.Count; } }

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }

        public string AddCar(Car car)
        {
            if (!cars.ContainsKey(car.RegistrationNumber))
            {
                if (cars.Count < capacity)
                {
                    cars[car.RegistrationNumber] = car;
                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
                else
                {
                    return "Parking is full!";
                }
            }
            else
            {
                return "Car with that registration number, already exists!";

            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.ContainsKey(registrationNumber))
            {
                cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = null;
            if (cars.ContainsKey(registrationNumber))
            {
                car = cars[registrationNumber];
            }
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
