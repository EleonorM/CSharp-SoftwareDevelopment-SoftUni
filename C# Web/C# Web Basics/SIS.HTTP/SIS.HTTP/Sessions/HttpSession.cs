namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HttpSession : IHttpSession
    {
        private Dictionary<string, object> parameters;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNullOrEmpty(id, nameof(id));
            Id = id;
            parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));

            parameters[name] = parameter;
        }

        public void ClearParameters()
        {
            parameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            CoreValidator.ThrowIfNullOrEmpty(name, nameof(name));

            if (parameters.ContainsKey(name))
            {
                return true;
            }

            return false;
        }

        public object GetParameter(string name)
        {
            if (ContainsParameter(name))
            {
                var parameterSearched = parameters[name];
                return parameterSearched;
            }

            return null;
        }
    }
}
