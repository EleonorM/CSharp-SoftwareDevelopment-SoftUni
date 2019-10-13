namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Factory;
    using MXGP.Models.Races.Factory;
    using MXGP.Models.Riders;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private IRiderFactory riderFactory;
        private IMotorcycleFactory motorcycleFactory;
        private IRaceFactory raceFactory;

        private MotorcycleRepository motorcycleRepository;
        private RiderRepository riderRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.riderFactory = new RiderFactory();
            this.motorcycleFactory = new MotorcycleFactory();
            this.raceFactory = new RaceFactory();

            this.motorcycleRepository = new MotorcycleRepository();
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);
            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            else if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);
            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var race = this.raceRepository.GetByName(raceName);
            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            else if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            var motorcycle = motorcycleFactory.CreateInstance(type, model, horsePower);
            this.motorcycleRepository.Add(motorcycle);
            return string.Format(OutputMessages.MotorcycleCreated, type + "Motorcycle", model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = raceFactory.CreateInstance(name, laps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            var rider = riderFactory.CreateInstance(riderName);
            this.riderRepository.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var riders = this.riderRepository.GetAll();
            var top3 = riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();
            this.raceRepository.Remove(race);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, top3[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, top3[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, top3[2].Name, race.Name));
            return sb.ToString().TrimEnd();
        }
    }
}
