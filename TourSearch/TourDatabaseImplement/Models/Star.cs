using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
    public class Star
    {
        public int Id { get; set; }
        [Required]
        public int StarId { get; set; }
        [Required]
        public string StarName { get; set; }
    }
}
