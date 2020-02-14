namespace Panda.Services
{
    using Panda.Models;
    using Panda.Models.Enums;
    using Panda.ViewModels.Packages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext db;

        public PackagesService(PandaDbContext db)
        {
            this.db = db;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipient)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == recipient);
            var package = new Package
            {
                Description = description,
                ShippingAddress = shippingAddress,
                Weight = weight,
                Recipient = user,
                Status = Status.Pending,
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public ICollection<string> GetAllUsers()
        {
            var users = this.db.Users.Select(x => x.Username).ToList();
            return users;
        }

        public PackagesPendingInputModel GetPending()
        {
            return new PackagesPendingInputModel
            {
                Packages = this.db.Packages.Where(x => x.Status == Status.Pending).Select(x => new PackageModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    RecipientName = x.Recipient.Username,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                }).ToList(),
            };
        }

        public PackagesPendingInputModel GetDelivered()
        {
            return new PackagesPendingInputModel
            {
                Packages = this.db.Packages.Where(x => x.Status == Status.Delivered).Select(x => new PackageModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    RecipientName = x.Recipient.Username,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                }).ToList(),
            };
        }

        public void MakePackageDelivered(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);
            package.Status = Status.Delivered;
            var receipt = new Receipt
            {
                Package = package,
                IssuedOn = DateTime.Now,
                Fee = package.Weight * 2.67m,
                RecipientId = package.RecipientId,
            };
            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }
    }
}
