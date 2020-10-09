using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
    public class Departure
    {
        public int Id { get; set; }
        [Required]
        public int DepartureId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string DepartureName { get; set; }
    }
}
