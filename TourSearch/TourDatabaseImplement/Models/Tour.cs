using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
    public class Tour
    {
        public int Id {get; set;}
        [Required]
        public string TourOperatorName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string  DepartureName { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string ResortName { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string StarName { get; set; }
        [Required]
        public string MealName { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public int CountPlaces { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}