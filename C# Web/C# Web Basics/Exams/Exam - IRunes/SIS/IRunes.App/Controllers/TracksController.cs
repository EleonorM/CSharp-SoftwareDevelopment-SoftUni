namespace IRunes.App.Controllers
{
    using IRunes.App.Services;
    using IRunes.App.ViewModels.Tracks;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            var model = new CreateOutputViewModel { AlbumId = albumId };
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }
            if (input.Price < 0)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            this.tracksService.CreateTrack(input.Name, input.Link, input.Price, input.AlbumId);
            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            var model = this.tracksService.GetTrack(albumId, trackId);
            return this.View(model);
        }
    }
}
