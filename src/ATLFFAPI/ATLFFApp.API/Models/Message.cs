using System;
using System.ComponentModel.DataAnnotations;

namespace ATLFFApp.API.Models
{
    public class Message
    {
        [Key]
        public Guid Message_Id { get; set; }
        public Guid Shipment_Id { get; set; }
        public string Details { get; set; }
    }
}