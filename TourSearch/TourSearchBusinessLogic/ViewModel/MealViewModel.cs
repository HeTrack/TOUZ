using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class MealViewModel
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        [DisplayName("Тип питания")]
        public string MealName { get; set; }
    }
}
