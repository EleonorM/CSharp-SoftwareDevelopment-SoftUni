using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using System;
using System.Globalization;
using System.Text;

namespace DemoApp
{
   public class Program
    {
       public static void Main()
        {
            //var newLine = "\r\n";
            //var request = @"POST /url/asd?name=kate&id=1#fragment HTTP/1.1" + newLine +
            //    "Authorization: Basic 23032" + newLine +
            //    "Date: " + DateTime.Now + newLine +
            //    "Host: localhost:5000" + newLine +
            //    newLine +
            //    "username=kate123&password=888888";
            //HttpRequest httpRequest = new HttpRequest(request);

            var statusCode = HttpResponseStatusCode.Unauthorized;
            HttpResponse response =new HttpResponse(HttpResponseStatusCode.InternalServerError);
            response.AddHeader(new HttpHeader("Host", "localhost:5000"));
            response.AddHeader(new HttpHeader("Date", DateTime.Now.ToString(CultureInfo.InvariantCulture)));

            response.Content = Encoding.UTF8.GetBytes("<h1>Hello World!<h1>");
            Console.WriteLine(Encoding.UTF8.GetString( response.GetBytes()));
            var a= 6;

        }
    }
}
