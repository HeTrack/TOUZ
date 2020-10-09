using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
   public class ResortBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ResortId { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string ResortName { get; set; }
    }
}
