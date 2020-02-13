namespace IRunes.App.Services
{
    using IRunes.App.ViewModels.Tracks;

    public interface ITracksService
    {
        void CreateTrack(string name, string link, decimal price, string albumId);

        DetailsInputViewModel GetTrack(string albumId, string trackId);
    }
}
