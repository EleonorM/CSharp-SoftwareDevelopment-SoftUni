namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var model = this.productsService.GetAll();
                return this.View(model, "Home");
            }

            return this.View();
        }
    }
}
