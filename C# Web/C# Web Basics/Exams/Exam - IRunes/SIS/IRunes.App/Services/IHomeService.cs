namespace IRunes.App.Services
{
    using IRunes.App.ViewModels.Home;

    public interface IHomeService
    {
        IndexViewModel GetUsername(string userId);
    }
}
