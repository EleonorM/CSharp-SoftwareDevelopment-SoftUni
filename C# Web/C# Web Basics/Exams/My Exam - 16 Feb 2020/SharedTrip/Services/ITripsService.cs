namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System;

    public interface ITripsService
    {
        AllTripsOutputViewModel GetAll();

        void Create(string startPoint, string endPoint, DateTime dateValue, string description, string imagePath, int seats);

        DetailsTripsOutputViewModel GetTrip(string tripId);

        void AddUserToTrip(string tripId, string userId);

        bool UserIsInTrip(string tripId, string userId);

        bool CheckForFreeSeats(string tripId);
    }
}
