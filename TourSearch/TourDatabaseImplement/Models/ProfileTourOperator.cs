using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
  public class ProfileTourOperator
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int TourOperatorId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual TourOperator TourOperator { get; set; }
    }
}
