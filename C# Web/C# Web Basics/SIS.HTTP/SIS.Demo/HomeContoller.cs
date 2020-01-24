namespace SIS.Demo
{
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;

    public class HomeContoller
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello World</h1>";
            var htmlResult = new HtmlResult(content, HttpResponseStatusCode.Ok);
            htmlResult.AddCookie(new HttpCookie("lang", "en"));
            return htmlResult;
        }

        //public IHttpResponse Login(IHttpRequest request)
        //{
        //    request.Session.AddParameter("username", "Eli");
        //    return Redirect("/");
        //}
    }
}
