using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TourSearchWebClient.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public List<Country> Countries { get; set; }
        public List<TourOperator> TourOperators { get; set; }
        public List<Departure> Departures { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Star> Stars { get; set; }
    
    }
}
