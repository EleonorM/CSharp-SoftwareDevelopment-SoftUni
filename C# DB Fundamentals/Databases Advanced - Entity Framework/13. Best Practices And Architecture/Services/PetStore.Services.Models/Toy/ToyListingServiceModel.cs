namespace PetStore.Services.Models.Toy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ToyListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int TotalOrders { get; set; }
    }
}
