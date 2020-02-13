namespace IRunes.App.Services
{
    using IRunes.App.Models;

    public interface IUsersService
    {
        void Create();

        User GetUser(string username, string password);
        void Create(string username, string email, string password);
    }
}
