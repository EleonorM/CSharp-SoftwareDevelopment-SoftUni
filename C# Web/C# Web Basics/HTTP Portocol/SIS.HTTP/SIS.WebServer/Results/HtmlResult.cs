namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode = HttpResponseStatusCode.Ok)
           : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset=utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
