using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourSearchDatabaseImplement.Models
{
   public class Room
    {
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; }
    }
}
