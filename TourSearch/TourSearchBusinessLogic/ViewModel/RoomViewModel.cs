using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
  public  class RoomViewModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        [DisplayName("Тип номера")]
        public string RoomName { get; set; }
    }
}
