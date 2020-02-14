namespace Panda.Models
{
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
