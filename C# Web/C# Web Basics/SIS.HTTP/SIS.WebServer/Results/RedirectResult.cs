namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
