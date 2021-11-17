using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Watering_App_Backend.Models
{
    public class Plant
    {

        public enum WateringStatus
        {
            Idle,
            Watering,
            Stopped
        }

        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public DateTime? lastWateredTime { get; set; }

        [Required]
        public int wateringPercentage { get; set; }

        [Required]
        public WateringStatus status { get; set; }

    }
}
