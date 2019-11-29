namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using System;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;

        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public int Create(string name, string description)
        {
            if (name == null)
            {
                throw new ArgumentNullException(name, $"Category name cannot be null.");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Category name cannot be more than {DataValidation.NameMaxLength} characters.");
            }

            if (description.Length > DataValidation.DescriptionMaxLength)
            {
                throw new InvalidOperationException($"Category description cannot be more than {DataValidation.DescriptionMaxLength} characters.");
            }

            if (this.data.Categories.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Category name {name} already exists.");
            }

            var category = new Category
            {
                Name = name,
                Description = description
            };
            this.data.Categories.Add(category);
            this.data.SaveChanges();

            return category.Id;
        }

        public bool Exists(int categoryId)
        {
            return this.data.Categories.Any(u => u.Id == categoryId);
        }
    }
}
