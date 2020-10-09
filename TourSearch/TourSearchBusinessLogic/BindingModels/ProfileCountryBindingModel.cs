using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
   public class ProfileCountryBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string CountryName { get; set; }
    }
}
