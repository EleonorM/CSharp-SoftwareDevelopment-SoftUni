namespace IRunes.App.Services
{
    using IRunes.App.Models;
    using IRunes.App.ViewModels.Albums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AlbumsService : IAlbumsService
    {
        private readonly IRunesDbContext db;

        public AlbumsService(IRunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public AllOutputViewModel GetAllModel()
        {
            return new AllOutputViewModel
            {
                Albums = this.db.Albums.Select(x => new AlbumViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList(),
            };
        }

        public DetailsOutputViewModel GetDetails(string id)
        {
            return this.db.Albums.Where(x => x.Id == id).Select(x => new DetailsOutputViewModel
            {
                Id = x.Id,
                Cover = x.Cover,
                Name = x.Name,
                Price = $"{(x.Tracks.Sum(t => t.Price) * 0.87M):f2}",
                Tracks = x.Tracks.Select(y => new TrackOutputViewModel
                {
                    Id = y.Id,
                    Name = y.Name,
                }).ToList(),
            }).FirstOrDefault();
        }
    }
}
