using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{

    public class ProfileViewModel
    {
        public int? Id { get; set; }
        public int ClientId { get; set; }
        public List<ProfileCountryViewModel> ProfileCountries { get; set; }
        public List <ProfileTourOperatorViewModel>ProfileTourOperators { get; set; }
        public List<ProfileDepartureViewModel> ProfileDepartures { get; set; }
        public List <ProfileMealViewModel> ProfileMeals { get; set; }
        public List <ProfileStarViewModel> ProfileStars { get; set; }
    }
}
