namespace SharedTrip.Services
{
    using SharedTrip.Models;

    public interface IUsersService
    {
        User GetUser(string username, string password);

        void Create(string username, string email, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);
    }
}
