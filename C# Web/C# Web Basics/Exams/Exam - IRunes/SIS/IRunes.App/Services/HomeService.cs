namespace IRunes.App.Services
{
    using IRunes.App.ViewModels.Home;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HomeService : IHomeService
    {
        private IRunesDbContext db;

        public HomeService(IRunesDbContext db)
        {
            this.db = db;
        }
        public IndexViewModel GetUsername(string userId)
        {
            var user = this.db.Users.Find(userId);
            return new IndexViewModel
            {
                Username = user.Username,
            };
        }
    }
}
