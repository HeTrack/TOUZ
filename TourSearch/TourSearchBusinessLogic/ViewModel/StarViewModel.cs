using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
 public class StarViewModel
    {
        public int Id { get; set; }
        public int StarId { get; set; }
        [DisplayName("Кол-во звёзд")]
        public string StarName { get; set; }
    }
}
