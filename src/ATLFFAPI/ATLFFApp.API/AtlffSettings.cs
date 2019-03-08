using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFApp.API
{
    public class AtlffSettings
    {
        public Neo4j Neo4j { get; set; }
    }

    public class Neo4j
    {
        [JsonProperty("Uri")]
        public string Uri { get; set; }
        [JsonProperty("User")]
        public string User { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
