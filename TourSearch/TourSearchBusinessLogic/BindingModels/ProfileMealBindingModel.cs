using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TourSearchBusinessLogic.BindingModels
{
   public class ProfileMealBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
        [DataMember]
        public int MealId { get; set; }
        [DataMember]
        public string MealName { get; set; }
    }
}
