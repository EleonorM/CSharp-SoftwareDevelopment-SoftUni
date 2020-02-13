namespace IRunes.App.Services
{
    using IRunes.App.Models;
    using IRunes.App.ViewModels.Tracks;
    using System.Linq;

    public class TracksService : ITracksService
    {
        private readonly IRunesDbContext db;

        public TracksService(IRunesDbContext db)
        {
            this.db = db;
        }
        public void CreateTrack(string name, string link, decimal price, string albumId)
        {
            var track = new Track
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId,
            };

            this.db.Tracks.Add(track);
            this.db.SaveChanges();
        }

        public DetailsInputViewModel GetTrack(string albumId, string trackId)
        {
            return this.db.Tracks.Where(x => x.Id == trackId).Select(x => new DetailsInputViewModel
            {
                Name = x.Name,
                Price = x.Price,
                AlbumId = albumId,
            }).FirstOrDefault();
        }
    }
}
