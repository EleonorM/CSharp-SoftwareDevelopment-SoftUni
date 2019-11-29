namespace PetStore
{
    using Data;
    using Data.Models;
    using Services.Implementations;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            using var db = new PetStoreDbContext();

            //var brandService = new BrandService(db);
            //brandService.Create("Wiskas");
            //brandService.Create("ToysForCats");

            //var categoryService = new CategoryService(db);
            //categoryService.Create("Cats","");


            //var userService = new UserService(db);
            //var foodService = new FoodService(db,userService);

            // foodService.BuyFromDistributor("Pauch", 0.300, 1.1m, 3, DateTime.Now.AddDays(20), 1, 1);
            //userService.Register("Pesho", "pesho@abv.bg");
            //foodService.SellFoodToUser(1, 1);


            //var toyService = new ToyService(db, userService);

            //toyService.BuyFromDistributor("Ball", "", 10m, 2, 2, 1);
            //toyService.SellToyToUser(1, 1);


            //var breedService = new BreedService(db);
            //breedService.Add("British ShortHair");


            //var petService = new PetService(db, userService, categoryService, breedService);
            //petService.BuyPet(Gender.Male, DateTime.Now.AddDays(-365), 350m, "", 1, 1);
            //petService.SellToUser(1, 1);

        }
    }
}
