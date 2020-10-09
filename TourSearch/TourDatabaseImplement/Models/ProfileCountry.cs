using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class ProfileCountry
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int CountryId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Country Country { get; set; }
    }
}
