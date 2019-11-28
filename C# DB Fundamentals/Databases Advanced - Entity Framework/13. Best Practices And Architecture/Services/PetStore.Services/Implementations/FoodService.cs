namespace PetStore.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Food;
    using Data.Models;
    using PetStore.Data;
    using System.Linq;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;

        public FoodService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Food name cannot be null or whitespace.");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException($"Profit must be higer than zero and lower than 500%.");
            }

            var food = new Food
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price * (1 + ((decimal)profit / 100m)),
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Food.Add(food);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException($"Food name cannot be null or whitespace.");
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException($"Profit must be higer than zero and lower than 500%.");
            }

            var food = new Food
            {
                Name = model.Name,
                Weight = model.Weigth,
                DistributorPrice = model.DistributorPrice,
                Price = model.Price + model.Price * (decimal)model.Profit,
                ExpirationDate = model.ExpirationDate,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            this.data.Add(food);
            this.data.SaveChanges();
        }
    }
}
