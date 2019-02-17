using System;
using System.Collections.Generic;
using System.Text;
using Neo4j.Driver.V1;

namespace ATLFF.Core.Connection
{
    public class Settings : ISettings
    {
        public string Uri {get; private set; }
        public IAuthToken AuthToken {get; private set; }

        public Settings(string uri, IAuthToken authToken)
        {
            Uri = uri;
            AuthToken = authToken;
        }

        public static Settings CreateBasicAuth(string uri, string username, string password)
        {
            return new Settings(uri, AuthTokens.Basic(username, password));
        }
    }
}
