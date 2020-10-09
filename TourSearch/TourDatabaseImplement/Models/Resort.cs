using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
    public class Resort
    {
        public int Id { get; set; }
        [Required]
        public int ResortId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string ResortName { get; set; }
    }
}
