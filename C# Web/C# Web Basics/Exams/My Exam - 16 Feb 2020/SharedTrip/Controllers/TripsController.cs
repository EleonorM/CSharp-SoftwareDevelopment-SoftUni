namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Globalization;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.tripsService.GetAll();
            return this.View(model);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripsViewModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                return this.View();
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.View();
            }

            if (model.Description.Length > 80 || string.IsNullOrEmpty(model.Description))
            {
                return this.View();
            }

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                return this.View();
            }

            this.tripsService.Create(model.StartPoint, model.EndPoint, dateValue, model.Description, model.ImagePath, model.Seats);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.tripsService.GetTrip(tripId);
            return this.View(model);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (this.tripsService.UserIsInTrip(tripId, this.User))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            //Check if there are seats avaliable
            if (!this.tripsService.CheckForFreeSeats(tripId))
            {
                return this.Redirect("/Trips/All");
            }

            this.tripsService.AddUserToTrip(tripId, this.User);
            return this.Redirect("/Trips/All");
        }
    }
}
