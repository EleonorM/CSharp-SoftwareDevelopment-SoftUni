namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using Models.Toy;
    using System;
    using System.Linq;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;

        public ToyService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
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
            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }

        public bool Exists(int toyId)
        {
            return this.data.Toys.Any(u => u.Id == toyId);
        }

        public void SellToyToUser(int userId, int toyId)
        {
            if (!this.Exists(toyId))
            {
                throw new ArgumentException($"There is no toy with id {toyId}");
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

            var toyOrder = new ToyOrder
            {
                Order = order,
                ToyId = toyId
            };

            data.Orders.Add(order);
            data.ToyOrders.Add(toyOrder);
            data.SaveChanges();
        }
    }
}
