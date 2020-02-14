namespace Panda.Controllers
{
    using Panda.Services;
    using Panda.ViewModels.Packages;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class PackagesController : Controller
    {
        private readonly IPackagesService packageService;

        public PackagesController(IPackagesService packageService)
        {
            this.packageService = packageService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.packageService.GetAllUsers();
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(PackagesCreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Description.Length < 5 || input.Description.Length > 20)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packageService.Create(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);
            return this.Redirect("/");
        }

        public HttpResponse Pending()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.packageService.GetPending();
            return this.View(model);
        }

        public HttpResponse Delivered()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.packageService.GetDelivered();
            return this.View(model);
        }

        public HttpResponse Deliver(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.packageService.MakePackageDelivered(id);
            return this.Redirect("/Packages/Delivered");
        }
    }
}
