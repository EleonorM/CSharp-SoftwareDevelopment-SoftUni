namespace Panda.Services
{
    using Panda.ViewModels.Home;

    public interface IHomeService
    {
        IndexViewModel GetUsername(string userId);
    }
}