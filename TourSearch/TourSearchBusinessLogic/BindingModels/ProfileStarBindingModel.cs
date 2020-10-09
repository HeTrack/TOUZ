using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
   public class ProfileStarBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
        [DataMember]
        public int StarId { get; set; }
        [DataMember]
        public string StarName { get; set; }
    }
}
