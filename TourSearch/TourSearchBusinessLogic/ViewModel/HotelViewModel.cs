using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class HotelViewModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [DisplayName("Отель")]
        public string HotelName { get; set; }
        public int ResortId { get; set; }
        public int StarId { get; set; }
    }
}
