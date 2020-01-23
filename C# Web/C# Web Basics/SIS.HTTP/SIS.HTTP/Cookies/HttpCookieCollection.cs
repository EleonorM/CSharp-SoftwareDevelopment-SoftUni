namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Common;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private IDictionary<string, HttpCookie> httpCookiesCollection;
        private string HttpCookieStringSeparator = "; ";

        public HttpCookieCollection()
        {
            httpCookiesCollection = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));
            httpCookiesCollection.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (HasCookies() && httpCookiesCollection.ContainsKey(key))
            {
                return true;
            }

            return false;
        }

        public HttpCookie GetCookie(string key)
        {
            if (ContainsCookie(key))
            {
                var cookie = httpCookiesCollection[key];
                return cookie;
            }

            return null;
        }

        public bool HasCookies()
        {
            if (httpCookiesCollection.Count > 0)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return this.httpCookiesCollection.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var cookie in this.httpCookiesCollection.Values)
            {
                sb.Append($"Set-Cookie: {cookie}").Append(GlobalConstants.HttpNewLine);
            }

            return sb.ToString();
        }
    }
}
