using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Media (TRUCK / TRAIN / SHIP / BARGE)")]
        public string Media { get; set; }          //  TRUCK / TRAIN / SHIP / BARGE 

        [Required]
        [Display(Name = "Number of Cities Transit (Int)")]
        public int NoNodes { get; set; }
    }
}
