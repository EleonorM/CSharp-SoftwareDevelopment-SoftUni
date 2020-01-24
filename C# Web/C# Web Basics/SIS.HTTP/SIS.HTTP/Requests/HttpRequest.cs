namespace SIS.HTTP.Requests
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Sessions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestedString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestedString, nameof(requestedString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            ParseRequest(requestedString);
        }
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpSession Session { get; set; }

        private bool IsValidRequestLine(string[] reqestLine)
        {
            return reqestLine.Length == 3 && reqestLine[2] == GlobalConstants.HttpOneProtocolFragment;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            CoreValidator.ThrowIfNullOrEmpty(queryString, nameof(queryString));

            return true; //TODO: REGEX QUERY STRING
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod method;
            var parsed = HttpRequestMethod.TryParse(requestLine[0], true, out method);
            if (parsed)
            {
                RequestMethod = method;
            }
            else
            {
                throw new BadRequestException(string.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage, requestLine[0]));
            }

        }

        private void ParseRequestUrl(string[] requestLine)
        {
            Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            Path = Url.Split('?')[0];
        }

        private void ParseRequestHeaders(string[] plainHeaders)
        {
            plainHeaders.Select(plainHeader => plainHeader.Split(new[] { ": " }
                    , StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headerKeyValuePair => this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));
        }

        private void ParseCookies()
        {
            if (Headers.ContainsHeader(HttpHeader.Cookie))
            {
                var value = Headers.GetHeader(HttpHeader.Cookie).Value;
                var unprasedCookies = value.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string unparsedCookie in unprasedCookies)
                {
                    var cookieKVP = unparsedCookie.Split("=", 2);
                    var cookie = new HttpCookie(cookieKVP[0], cookieKVP[1]);

                    this.Cookies.AddCookie(cookie);
                }
            }
        }

        private void ParseQueryParameters()
        {
            if (this.HasQueryString())
            {
                Url.Split('?', '#')[1]
          .Split('&')
          .Select(x => x.Split('='))
          .ToList()
          .ForEach(y => QueryData.Add(y[0], y[1]));
            }


        }

        private bool HasQueryString()
        {
            return this.Url.Split('?').Length > 1;
        }

        private void ParseFormDataParameters(string formData)
        {
            //TODO:Format data with multiple parameters by name
            if (!string.IsNullOrEmpty(formData))
            {
                formData.Split('&')
                .Select(x => x.Split('='))
                .ToList()
                .ForEach(y => FormData.Add(y[0], y[1]));

            }
        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
            //TODO:Split
        }

        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);
            var requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            ParseRequestMethod(requestLine);
            ParseRequestUrl(requestLine);
            ParseRequestPath();

            ParseRequestHeaders(ParsePlainRequestHeaders(splitRequestContent).ToArray());
            ParseCookies();

            ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
