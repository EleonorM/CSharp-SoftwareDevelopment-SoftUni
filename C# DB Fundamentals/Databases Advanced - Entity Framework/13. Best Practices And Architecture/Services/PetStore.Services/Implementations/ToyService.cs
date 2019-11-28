namespace PetStore.Services.Implementations
{
using System;
using System.Collections.Generic;
using System.Text;
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Toy;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;

        public ToyService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void BuyFromDistributor(string name, string description, decimal distributorPrice, double profit, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Toy name cannot be null or whitespace.");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException($"Profit must be higer than zero and lower than 500%.");
            }

            var toy = new Toy
            {
                Name = name,
                Description = description,
                DistributorPrice = distributorPrice,
                Price = distributorPrice * (1 + ((decimal)profit / 100m)),
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingToysServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException($"Toy name cannot be null or whitespace.");
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException($"Profit must be higer than zero and lower than 500%.");
            }

            var toy = new Toy
            {
                Name = model.Name,
                Description = model.Description,
                DistributorPrice = model.DistributorPrice,
                Price = model.Price + model.Price * (decimal)model.Profit,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            this.data.Add(toy);
            this.data.SaveChanges();
        }
    }
}
