using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
    public class ProfileTourOperatorBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
        [DataMember]
        public int TourOperatorId { get; set; }
        [DataMember]
        public string TourOperatorName { get; set; }
    }
}
