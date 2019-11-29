namespace PetStore.Services.Implementations
{
    using Data.Models;
    using Models.Food;
    using Data;
    using System;
    using System.Linq;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;

        public FoodService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
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

            this.data.Food.Add(food);
            this.data.SaveChanges();
        }

        public bool Exists(int foodId)
        {
            return this.data.Food.Any(u => u.Id == foodId);
        }

        public void SellFoodToUser(int foodId, int userId)
        {
            if (!this.Exists(foodId))
            {
                throw new ArgumentException($"There is no food with id {foodId}");
            }

            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException($"There is no user with id {userId}");
            }

            var order = new Order
            {
                PurchasedDate = DateTime.Now,
                OrderStatus = OrderStatus.Done,
                UserId = userId
            };

            var foodOrder = new FoodOrder
            {
                Order = order,
                FoodId = foodId
            };

            data.Orders.Add(order);
            data.FoodOrders.Add(foodOrder);
            data.SaveChanges();
        }
    }
}
