using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATLFFApp.API.Models
{
    public enum Statuses { VALID, DELIVERED, TRANSIT, FAILURE, RETURNED }

    public class Shipment
    {
        [Key]
        public Guid Shipment_Id { get; set; }
        public Guid Customer_Id { get; set; }
        public Guid Employee_Id { get; set; }
        public Statuses Status { get; set; }
        public Guid Address_From_Id { get; set; }
        public Guid Address_To_Id { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Departure_Date { get; set; }
        public DateTime Arrival_Date { get; set; }
        public decimal Total_Price { get; set; }
        public Guid Route_Id { get; set; } 

        public ICollection<Message> Meessages { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
