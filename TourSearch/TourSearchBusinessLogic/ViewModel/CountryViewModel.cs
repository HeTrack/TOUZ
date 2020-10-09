using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class CountryViewModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        [DisplayName("Страна")]
        public string CountryName { get; set; }
    }
}
