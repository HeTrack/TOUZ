using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
  public class ProfileDepartureViewModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int DepartureId { get; set; }
        public int CountryId { get; set; }
        public string DepartureName { get; set; }
    }
}
