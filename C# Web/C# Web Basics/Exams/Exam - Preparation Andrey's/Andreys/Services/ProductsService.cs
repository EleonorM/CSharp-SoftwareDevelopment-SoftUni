namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string description, decimal price, string imageUrl, Category categoryParsed, Gender genderParsed)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                Category = categoryParsed,
                Description = description,
                Gender = genderParsed,
                ImageUrl = imageUrl,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = this.db.Products.Find(id);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public ItemsOutputModel GetAll()
        {
            return new ItemsOutputModel
            {
                Items = this.db.Products.Select(x => new ItemModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Name = x.Name,
                    Price = x.Price,
                }).ToList(),
            };
        }

        public DetailsOutputModel GetProduct(string id)
        {
            return this.db.Products.Where(x => x.Id == id).Select(x => new DetailsOutputModel
            {
                Id = x.Id,
                Category = ((Category)x.Category).ToString(),
                Description = x.Description,
                Name = x.Name,
                Price = x.Price,
                Gender = ((Gender)x.Gender).ToString(),
                ImageUrl = x.ImageUrl,
            }).FirstOrDefault();
        }
    }
}
