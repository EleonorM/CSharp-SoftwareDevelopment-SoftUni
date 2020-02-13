namespace IRunes.App.ViewModels.Albums
{
    using System.Collections.Generic;

    public class DetailsOutputViewModel
    {
        public DetailsOutputViewModel()
        {
            Tracks = new List<TrackOutputViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public string Price { get; set; }

        public ICollection<TrackOutputViewModel> Tracks { get; set; }
    }

    public class TrackOutputViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
