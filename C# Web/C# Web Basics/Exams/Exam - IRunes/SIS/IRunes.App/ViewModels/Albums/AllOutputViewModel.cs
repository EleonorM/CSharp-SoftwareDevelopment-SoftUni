namespace IRunes.App.ViewModels.Albums
{
    using System.Collections.Generic;

    public class AllOutputViewModel
    {
        public AllOutputViewModel()
        {
            Albums = new HashSet<AlbumViewModel>();
        }

        public string Message { get; set; } = string.Empty;

        public ICollection<AlbumViewModel> Albums { get; set; }
    }

    public class AlbumViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
