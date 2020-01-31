using IRunes.Models;
using System.Linq;
using System.Net;

namespace IRunes.App.Extensions
{
    public static class EntityExtensions
    {
        private static string GetTracks(Album album) => album.Tracks.Count == 0
            ? "There are currently no tracks in this album."
            : string.Join("", album.Tracks.Select((track, index) => track.ToHtmlAll(index+1)));

        public static string ToHtmlAll(this Album album)
        {
            return $"<div><a href=\"/Albums/Details?id={album.Id}\">{WebUtility.UrlDecode(album.Name)}</a></div>";
        }

        public static string ToHtmlDetails(this Album album)
        {
            return "<div class=\"album-details\">" +
                "<div>" +
                        $"<img src=\"{WebUtility.UrlDecode (album.Cover)}\"><br/>" +
                    $"<h1>Album Name: {WebUtility.UrlDecode(album.Name)}</h1>" +
                    $"<h1>Album Price: ${album.Price:f2}</h1>" +
                    "</br>" +
                "</div>" +
                "<div class=\"album - tracks\">" +
                "<h1>Tracks</h1>" +
                $"<a href=\"/Tracks/Create?albumId={album.Id}\">Create Track</a>"+
                "<hr style=\"height: 2px\" />"+
                "<ul class=\"tracks-list\">"+
                $"{GetTracks(album)}"+
            "</div>";

//            < div class="album-details d-flex justify-content-between row">
//        <div class="album-data col-md-5">
//            <img src = "@Model.Cover" class="img-thumbnail" />
//            <h1 class="text-center">Album Name: @Model.Name</h1>
//            <h1 class="text-center">Album Price: @Model.Price</h1>
//            <div class="d-flex justify-content-between">
//                <a class="btn bg-success text-white" href="/Tracks/Create?albumId=@Model.Id">Create Track</a>
//                <a class="btn bg-success text-white" href="/Albums/All">Back To All</a>
//            </div>
//        </div>
//        <div class="album-tracks col-md-6">
//            <h1>Tracks</h1>
//            @for(int index = 0; index<Model.Tracks.Count; index++) 
//            {
//            <li>
//                <strong>@{index+1}</strong>. <a href = "/Tracks/Details?albumId=@{Model.Id}&trackId=@{Model.Tracks[index].Id}" >< i > @Model.Tracks[index].Name </ i ></ a >

//</ li >
//            }
//        </div>
//    </div>


        }

        public static string ToHtmlAll(this Track track, int index)
        {
            return $"<li><a href=\"/Tracks/Details?=id{track.Id}\">{index}. {WebUtility.UrlDecode(track.Name)}</li>";
        }

        public static string ToHtmlDetails(this Track track)
        {
            return null;

        }
    }
}
