namespace SULS.App.Services
{
    using SULS.App.Models;

    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        User GetUser(string username);

        bool IsEmailUsed(string email);

        string GetUserId(string username, string password);
    }
}
