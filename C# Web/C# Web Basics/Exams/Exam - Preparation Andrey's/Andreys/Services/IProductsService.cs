namespace Andreys.Services
{
    using Andreys.Models;
    using Andreys.ViewModels.Products;

    public interface IProductsService
    {
        void Create(string name, string description, decimal price, string imageUrl, Category categoryParsed, Gender genderParsed);

        DetailsOutputModel GetProduct(string id);

        ItemsOutputModel GetAll();

        void Delete(string id);
    }
}
