namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Linq;

    public class TripsService : ITripsService
    {
        private ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.Find(tripId);
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId,
            };

            trip.Seats = (trip.Seats) - 1;
            trip.UserTrips.Add(userTrip);
            this.db.Update(trip);
            this.db.SaveChanges();
        }

        public bool CheckForFreeSeats(string tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            return trip.Seats > 0;
        }

        public void Create(string startPoint, string endPoint, DateTime dateValue, string description, string imagePath, int seats)
        {
            var trip = new Trip
            {
                Seats = seats,
                ImagePath = imagePath,
                Description = description,
                DepartureTime = dateValue,
                EndPoint = endPoint,
                StartPoint = startPoint,
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public AllTripsOutputViewModel GetAll()
        {
            return new AllTripsOutputViewModel
            {
                Trips = this.db.Trips.Select(x => new TripViewModel
                {
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    Seats = x.Seats,
                    StartPoint = x.StartPoint
                }).ToList()
            };
        }

        public DetailsTripsOutputViewModel GetTrip(string tripId)
        {
            return this.db.Trips.Where(x => x.Id == tripId).Select(x => new DetailsTripsOutputViewModel
            {
                Id = tripId,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = x.Description,
                EndPoint = x.EndPoint,
                ImagePath = x.ImagePath,
                Seats = x.Seats,
                StartPoint = x.StartPoint
            })
                .FirstOrDefault();
        }

        public bool UserIsInTrip(string tripId, string userId)
        {
            var userTrip = this.db.UserTrips.Where(x=>x.TripId == tripId).Select(x => x.UserId).ToList();
            if (userTrip.Count == 0)
            {
                return false;
            }

            if (!userTrip.Contains(userId))
            {
                return false;
            }

            return true;
        }
    }
}
