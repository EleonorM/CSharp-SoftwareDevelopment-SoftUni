namespace PetStore.Services.Implementations
{
    using Data;
    using Models.Toy;
    using Data.Models;
    using Models.Brand;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data) => this.data = data;

        public int Create(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(name, $"Brand name cannot be null.");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {DataValidation.NameMaxLength} characters.");
            }

            if (this.data.Brands.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Brand name {name} already exists.");
            }

            var brand = new Brand
            {
                Name = name
            };
            this.data.Brands.Add(brand);
            this.data.SaveChanges();

            return brand.Id;
        }

        public BrandWithToysServiceModel FindByIdWithToys(int id)
        => this.data.Brands
            .Where(br => br.Id == id)
            .Select(br => new BrandWithToysServiceModel
            {
                Name = br.Name,
                Toys = br.Toys.Select(t => new ToyListingServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    TotalOrders = t.Orders.Count
                })
            })
            .FirstOrDefault();

        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
        {
            return this
                .data
                .Brands
                .Where(x => x
                    .Name
                    .ToLower().Contains(name
                        .ToLower()))
                        .Select(x => new BrandListingServiceModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .ToList();
        }

        // internal Brand GetBrandByName(string name) => this.data.Brands.FirstOrDefault(br => br.Name.ToLower() == name.ToLower());
    }
}
