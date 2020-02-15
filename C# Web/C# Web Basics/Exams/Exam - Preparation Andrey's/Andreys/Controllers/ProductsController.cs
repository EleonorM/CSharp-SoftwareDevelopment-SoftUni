namespace Andreys.Controllers
{
    using Andreys.Models;
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
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
        public HttpResponse Add(AddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Description.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (!Enum.TryParse(input.Category, true, out Category categoryParsed))
            {
                return this.Redirect("/Products/Add");
            }

            if (!Enum.TryParse(input.Gender, true, out Gender genderParsed))
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.Create(input.Name, input.Description, input.Price, input.ImageUrl, categoryParsed, genderParsed);
            return this.View();
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.productsService.GetProduct(id);
            return this.View(model);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.productsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
