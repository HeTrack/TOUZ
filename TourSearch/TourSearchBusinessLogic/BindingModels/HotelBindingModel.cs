using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
   public class HotelBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HotelId { get; set; }
        [DataMember]
        public string HotelName { get; set; }
        [DataMember]
        public int ResortId { get; set; }
        [DataMember]
        public int StarId { get; set; }
    }
}
