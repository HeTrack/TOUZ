using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class ProfileCountryViewModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
