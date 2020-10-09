using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class ProfileMeal
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int MealId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
