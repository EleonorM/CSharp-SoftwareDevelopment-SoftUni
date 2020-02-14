namespace Panda.Controllers
{
    using Panda.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.receiptsService.GetReceipts();
            return this.View(model);
        }
    }
}
