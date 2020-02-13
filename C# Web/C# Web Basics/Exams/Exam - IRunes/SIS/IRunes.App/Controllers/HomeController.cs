namespace IRunes.App.Controllers
{
    using IRunes.App.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View(this.homeService.GetUsername(this.User), "Home");
            }

            return this.View();
        }

    }
}
