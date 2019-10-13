namespace _07.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Car
    {
        public string Model;
        public Engine Engine;
        public Cargo Cargo;
        public Tire Tire1;
        public Tire Tire2;
        public Tire Tire3;
        public Tire Tire4;

        public Car(string model, 
            double engineSpeed, 
            double enginePower, 
            double cargoWeight, 
            string cargoType, 
            double tire1Pressure, 
            double tire1Age,
            double tire2Pressure,
            double tire2Age,
            double tire3Pressure,
            double tire3Age,
            double tire4Pressure,
            double tire4Age)
        {
            Model = model;
            Engine = new Engine();
            Engine.Speed = engineSpeed;
            Engine.Power = enginePower;
            Cargo = new Cargo();
            Cargo.Weight = cargoWeight;
            Cargo.Type = cargoType;
            Tire1 = new Tire();
            Tire1.TirePressure = tire1Pressure;
            Tire1.TireAge = tire1Age;
            Tire2 = new Tire();
            Tire2.TirePressure = tire2Pressure;
            Tire2.TireAge = tire2Age;
            Tire3 = new Tire();
            Tire3.TirePressure = tire3Pressure;
            Tire3.TireAge = tire3Age;
            Tire4 = new Tire();
            Tire4.TirePressure = tire4Pressure;
            Tire4.TireAge = tire4Age;
        }
    }
}
