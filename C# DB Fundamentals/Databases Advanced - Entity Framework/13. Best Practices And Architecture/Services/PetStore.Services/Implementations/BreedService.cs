namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using System;
    using System.Linq;

    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(name, $"Breed name cannot be null.");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Breed name cannot be more than {DataValidation.NameMaxLength} characters.");
            }

            var breed = new Breed
            {
                Name = name
            };

            this.data.Breeds.Add(breed);
            this.data.SaveChanges();
        }

        public bool Exists(int breedId)
        {
            return this.data.Breeds.Any(u => u.Id == breedId);
        }
    }
}
