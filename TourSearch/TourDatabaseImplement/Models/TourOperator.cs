using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class TourOperator
    {
        public int Id { get; set; }
        [Required]
        public int TourOperatorId { get; set; }
        [Required]
        public string TourOperatorName { get; set; }
    }
}
