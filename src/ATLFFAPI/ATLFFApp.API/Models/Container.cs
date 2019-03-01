using System;
using System.ComponentModel.DataAnnotations;

namespace ATLFFApp.API.Models
{
    public class Container
    {
        [Key]
        public Guid Unit_Id { get; set; }
        public string Name { get; set; }
    }
}
