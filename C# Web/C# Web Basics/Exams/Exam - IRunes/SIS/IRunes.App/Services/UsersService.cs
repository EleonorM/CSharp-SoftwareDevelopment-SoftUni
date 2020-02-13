namespace IRunes.App.Services
{
    using IRunes.App.Models;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private IRunesDbContext db;

        public UsersService(IRunesDbContext db)
        {
            this.db = db;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Create(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Password = this.Hash(password),
                Email = email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public User GetUser(string username, string password)
        {
            var passwordHashed = this.Hash(password);
            return this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == passwordHashed);

        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
