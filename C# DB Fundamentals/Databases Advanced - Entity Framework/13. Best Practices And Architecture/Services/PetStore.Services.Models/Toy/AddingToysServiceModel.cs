namespace PetStore.Services.Models.Toy
{
    using System;

    public class AddingToysServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public double Profit { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
