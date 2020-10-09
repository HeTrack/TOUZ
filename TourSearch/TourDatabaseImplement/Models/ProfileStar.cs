using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class ProfileStar
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int StarId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Star Star { get; set; }
    }
}
