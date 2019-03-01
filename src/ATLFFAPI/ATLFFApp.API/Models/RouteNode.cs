using System;
using System.ComponentModel.DataAnnotations;

namespace ATLFFApp.API.Models
{
    public class RouteNode
    {
        [Key]
        public Guid Node_Id { get; set; }
        public Guid Route_Id { get; set; }
        public string Name { get; set; }
    }
}
