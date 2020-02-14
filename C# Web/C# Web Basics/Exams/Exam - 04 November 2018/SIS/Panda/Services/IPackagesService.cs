namespace Panda.Services
{
    using Panda.ViewModels.Packages;
    using System.Collections.Generic;

    public interface IPackagesService
    {
        void Create(string description, decimal weight, string shippingAddress, string recipient);

        ICollection<string> GetAllUsers();

        PackagesPendingInputModel GetPending();

        PackagesPendingInputModel GetDelivered();

        void MakePackageDelivered(string id);
    }
}
