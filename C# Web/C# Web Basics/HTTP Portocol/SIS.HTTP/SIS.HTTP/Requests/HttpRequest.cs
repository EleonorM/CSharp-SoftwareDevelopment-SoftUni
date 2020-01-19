namespace SIS.HTTP.Requests
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers;
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

            ParseRequest(requestedString);
        }
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] reqestLine)
        {
            return reqestLine.Length == 3 && reqestLine[2] == GlobalConstants.HttpOnePortocolFragment;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            if (CoreValidator.ThrowIfNullOrEmpty(queryString))
            {

            }
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod method;
            var parsed = HttpRequestMethod.TryParse(requestLine[0], out method);
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

        }

        private void ParseRequestPath()
        {

        }

        private void ParseRequestHeaders(string[] requestContent)
        {

        }

        private void ParseCookies()
        {

        }

        private void ParseQueryParameters()
        {

        }

        private void ParseFormDataParameters(string formData)
        {

        }

        private void ParseRequestParameters(string formData)
        {

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

            ParseRequestHeaders(splitRequestContent.Skip(1).ToArray());
            ParseCookies();

            ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
