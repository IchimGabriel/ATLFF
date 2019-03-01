﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFApp.API.Models
{
    public class City
    {
        //[JsonProperty("id")]
        public int Id { get; set; }
        //[JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lat")]
        public float Latitude { get; set; }
        [JsonProperty("lng")]
        public float Longitude { get; set; }
        [JsonProperty("iso")]
        public string iso { get; set; }     // iso3 - IRL . GBR
        [JsonProperty("port_city")]
        public bool Port { get; set; }          // true or false
        [JsonProperty("turnaround")]
        public int Turnaround { get; set; }     // overhead time - hours
    }
}
