namespace IRunes.App.Services
{
    using IRunes.App.ViewModels.Albums;

    public interface IAlbumsService
    {
        AllOutputViewModel GetAllModel();

        void Create(string name, string cover);

        DetailsOutputViewModel GetDetails(string id);
    }
}
