using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required]
        public int MealId { get; set; }
        [Required]
        public string MealName { get; set; }
    }
}
