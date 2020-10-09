using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class ProfileDeparture
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int DepartureId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Departure Departure { get; set; }
    }
}
