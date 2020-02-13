namespace IRunes.App.Controllers
{
    using IRunes.App.Services;
    using IRunes.App.ViewModels.Albums;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumService;

        public AlbumsController(IAlbumsService albumService)
        {
            this.albumService = albumService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.albumService.GetAllModel();
            if (model == null)
            {
                model.Message = "There are currently no albums.";
                return this.View(model);
            }
            return this.View(model);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
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
                this.Redirect("/Albums/Create");
            }

            this.albumService.Create(input.Name, input.Cover);
            return this.View();
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.albumService.GetDetails(id);
            return this.View(model);
        }
    }
}
