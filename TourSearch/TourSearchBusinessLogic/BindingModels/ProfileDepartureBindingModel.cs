﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
    public class ProfileDepartureBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
        [DataMember]
        public int DepartureId { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string DepartureName { get; set; }
    }
}
