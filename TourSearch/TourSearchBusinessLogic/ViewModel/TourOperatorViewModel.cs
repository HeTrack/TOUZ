using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
    public class TourOperatorViewModel
    {
        public int Id { get; set; }
        public int TourOperatorId { get; set; }
        [DisplayName("Название тур - оператора")]
        public string TourOperatorName { get; set; }
    }
}
