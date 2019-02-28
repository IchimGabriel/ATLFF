using System;
using System.ComponentModel.DataAnnotations;

namespace ATLFFApp.API.Models
{
    public class Detail
    {
        [Key]
        public Guid Detail_Id  { get; set; }
        public Guid Shipment_Id { get; set; } 
        public Guid Container_Id { get; set; }
        public int Quantity { get; set; }
    }
}