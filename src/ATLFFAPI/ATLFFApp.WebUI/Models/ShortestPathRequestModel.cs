using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFApp.WebUI.Models
{
    public class ShortestPathRequestModel
    {
        [Required]
        [Display(Name = "Departure City")]
        public string DepartureCity { get; set; }

        [Required]
        [Display(Name = "Arrival City")]
        public string ArrivalCity { get; set; }

        [Required]
        [Display(Name = "Medium (TRUCK / TRAIN / SHIP / BARGE)")]
        public string Medium { get; set; }          //  TRUCK / TRAIN / SHIP / BARGE

        [Required]
        [Display(Name = "Number of Cities Transit (Int)")]
        public int NoNodes { get; set; }

    }
}
