namespace PetStore.Services
{
    using Models.Food;
    using System;

    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId);

        void BuyFromDistributor(AddingFoodServiceModel model);

        bool Exists(int foodId);

        void SellFoodToUser(int foodId, int userId);
    }
}
