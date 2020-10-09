using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class ProfileMealViewModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
    }
}
