using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATLFF.Core.Model
{
    class Edge
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }    // TRUCK . TRAIN . SHIP . BARGE
        [JsonProperty("distance")]
        public int Distance { get; set; }   // Km

        public int Speed { get; set; }      // Km/h

        public float Emission { get; set; } // CO2 emission
    }
}
