namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.App.Services;

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
                var viewModels = this.homeService.GetProblem();

                return this.View(viewModels, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
