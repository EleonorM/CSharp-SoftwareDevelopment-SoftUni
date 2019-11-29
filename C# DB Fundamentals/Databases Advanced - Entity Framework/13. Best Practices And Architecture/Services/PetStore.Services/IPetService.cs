namespace PetStore.Services
{
    using Data.Models;
    using System;

    public interface IPetService
    {
        void BuyPet(Gender gender, DateTime birthDate, decimal price, string description, int breedId, int categoryId);

        void SellToUser(int userId, int petId);

        bool Exists(int petId);
    }
}
