using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
  public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int ResortId { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public int StarId { get; set; }
    }
}
