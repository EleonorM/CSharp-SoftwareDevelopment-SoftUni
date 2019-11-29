namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using System;
    using System.Linq;

    public class PetService : IPetService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IBreedService breedService;

        public PetService(PetStoreDbContext data, IUserService userService, ICategoryService categoryService, IBreedService breedService)
        {
            this.data = data;
            this.userService = userService;
            this.categoryService = categoryService;
            this.breedService = breedService;
        }

        public void BuyPet(Gender gender, DateTime birthDate, decimal price, string description, int breedId, int categoryId)
        {
            if (description.Length > DataValidation.DescriptionMaxLength)
            {
                throw new InvalidOperationException($"Breed description cannot be more than {DataValidation.DescriptionMaxLength} characters.");
            }

            if (price < 0)
            {
                throw new ArgumentException($"Price cannot be less than zero.");
            }

            if (!breedService.Exists(breedId))
            {
                throw new ArgumentException($"There is no breed with id {breedId}");
            }

            if (!categoryService.Exists(categoryId))
            {
                throw new ArgumentException($"There is no category with id {categoryId}");
            }

            var pet = new Pet
            {
                Gender = gender,
                DateOfBirth = birthDate,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId
            };

            this.data.Pets.Add(pet);
            this.data.SaveChanges();
        }

        public bool Exists(int petId)
        {
            return this.data.Pets.Any(u => u.Id == petId);
        }

        public void SellToUser(int userId, int petId)
        {
            if (!this.Exists(petId))
            {
                throw new ArgumentException($"There is no pet with id {petId}");
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

            var pet = this.data.Pets.First(x => x.Id == petId);
            pet.Order = order;

            data.Orders.Add(order);
            data.SaveChanges();
        }
    }
}
