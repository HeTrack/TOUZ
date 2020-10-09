using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class ResortViewModel
    {
        public int Id { get; set; }
        public int ResortId { get; set; }
        public int CountryId { get; set; }
        [DisplayName("Название курорта")]
        public string ResortName { get; set; }
    }
}
