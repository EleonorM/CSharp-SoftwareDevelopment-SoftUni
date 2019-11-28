using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Food
{
    public class AddingFoodServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public double Profit { get; set; }

        public double Weigth { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
