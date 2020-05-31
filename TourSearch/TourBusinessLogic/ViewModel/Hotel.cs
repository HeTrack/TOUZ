using System;
using System.Collections.Generic;
using System.Text;

namespace TourBusinessLogic.ViewModel
{
    public class Hotel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public City City { get; private set; }
        public int BuildingYear { get; private set; }
    }
}
