namespace Panda.Controllers
{
    using Panda.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var username = this.homeService.GetUsername(this.User);
                return this.View(username, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
