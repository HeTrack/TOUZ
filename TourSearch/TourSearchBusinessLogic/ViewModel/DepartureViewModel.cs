using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class DepartureViewModel
    {
        public int Id { get; set; }
        public int DepartureId { get; set; }
        [DisplayName("Страна")]
        public int CountryId { get; set; }
        [DisplayName("Город Вылета")]
        public string DepartureName { get; set; }
    }
}
