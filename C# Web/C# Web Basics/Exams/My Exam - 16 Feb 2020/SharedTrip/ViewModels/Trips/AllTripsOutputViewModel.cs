namespace SharedTrip.ViewModels.Trips
{
    using System.Collections.Generic;

    public class AllTripsOutputViewModel
    {
        public ICollection<TripViewModel> Trips { get; set; } = new HashSet<TripViewModel>();
    }
}
