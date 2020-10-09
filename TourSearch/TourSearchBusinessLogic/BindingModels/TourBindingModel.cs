using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
    [DataContract]
    public class TourBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TourId { get; set; }
        [DataMember]
        public string TourOperatorName { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string DepartureName { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public string ResortName { get; set; }
        [DataMember]
        public string HotelName { get; set; }
        [DataMember]
        public string StarName { get; set; }
        [DataMember]
        public string MealName { get; set; }
        [DataMember]
        public string RoomName { get; set; }
        [DataMember]
        public int CountPlaces { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
    }
}