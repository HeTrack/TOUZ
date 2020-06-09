using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchCommon.Model
{
    partial class Hotel
    {
        public Hotel(Guid id, string name, string address, City city, int buildingYear)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            BuildingYear = buildingYear;
        }

        public Hotel With(Guid? id = null, string name = null, string address = null, City city = null, int? buildingYear = null)
        {
            return new Hotel(id ?? Id, name ?? Name, address ?? Address, city ?? City, buildingYear ?? BuildingYear);
        }
    }
}