using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
    [DataContract]
    public class ProfileBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public List <ProfileCountryBindingModel> ProfileCountries { get; set; }
        [DataMember]
        public List<ProfileTourOperatorBindingModel> ProfileTourOperators { get; set; }
        [DataMember]
        public List<ProfileDepartureBindingModel> ProfileDepartures { get; set; }
        [DataMember]
        public List<ProfileMealBindingModel> ProfileMeals { get; set; }
        [DataMember]
        public List<ProfileStarBindingModel> ProfileStars { get; set; }
        
    }

}
