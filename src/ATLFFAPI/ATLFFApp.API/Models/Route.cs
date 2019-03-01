using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATLFFApp.API.Models
{
    public class Route
    {
        [Key]
        public Guid Route_Id { get; set; }
        public int Total_KM { get; set; }
        public float Total_CO2 { get; set; }
        public int Total_Time { get; set; }  // hours

        public ICollection<RouteNode> RouteNodes { get; set; }
    }
}