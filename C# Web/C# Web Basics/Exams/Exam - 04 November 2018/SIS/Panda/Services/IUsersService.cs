namespace Panda.Services
{
    using Panda.Models;

    public interface IUsersService
    {
        User GetUser(string username, string password);

        void Create(string username, string email, string password);
    }
}
