using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class Profile
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual List<ProfileCountry> ProfileCountries { get; set; }
        [ForeignKey("ProfileId")]
        public virtual List<ProfileTourOperator> ProfileTourOperators { get; set; }
        [ForeignKey("ProfileId")]
        public virtual List<ProfileDeparture> ProfileDepartures { get; set; }
        [ForeignKey("ProfileId")]
        public virtual List<ProfileMeal> ProfileMeals { get; set; }
        [ForeignKey("ProfileId")]
        public virtual List<ProfileStar> ProfileStars { get; set; }
    }
}
