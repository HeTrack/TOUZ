using System;
using System.Collections.Generic;
using System.Text;

namespace TourBusinessLogic.ViewModel
{
   public class City
    {
        public int Id { get;  set; }
        public Country Country {get;set; }
        public string Name { get;  set; }
    }
}
