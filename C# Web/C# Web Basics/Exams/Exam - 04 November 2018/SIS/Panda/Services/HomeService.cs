namespace Panda.Services
{
    using Panda.ViewModels.Home;

    public class HomeService : IHomeService
    {
        private PandaDbContext db;

        public HomeService(PandaDbContext db)
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
