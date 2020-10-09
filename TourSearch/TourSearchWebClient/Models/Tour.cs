using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourSearchWebClient.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string TourOperatorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DepartureName { get; set; }
        public string CountryName { get; set; }
        public string ResortName { get; set; }
        public string HotelName { get; set; }
        public string StarName { get; set; }
        public string MealName { get; set; }
        public string RoomName { get; set; }
        public int CountPlaces { get; set; }
        public decimal Cost { get; set; }


    }
}
