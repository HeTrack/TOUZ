using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
   public class RoomBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public string RoomName { get; set; }
    }
}
