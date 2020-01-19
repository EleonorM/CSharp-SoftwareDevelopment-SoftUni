namespace SIS.HTTP.Headers
{
    using SIS.HTTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            if (ContainsHeader(key))
            {
                return headers[key];
            }
            else
            {
                return null;
            }
        }

        public override string ToString() => string.Join("\r\n",
             this.headers.Values.Select(header => header.ToString()));

    }
}
