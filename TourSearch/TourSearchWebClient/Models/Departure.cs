using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourSearchWebClient.Models
{
    public class Departure
    {
        public int DepartureId { get; set; }
        public int CountryId { get; set; }
        public string DepartureName { get; set; }
    }
}
