using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchCommon.Model
{
    partial class City
    {
        public City(int id, Country country, string name)
        {
            Id = id;
            Country = country;
            Name = name;
        }

        public City With(int? id = null, Country country = null, string name = null)
        {
            return new City(id ?? Id, country ?? Country, name ?? Name);
        }
    }

    partial class City_Id
    {
        public City_Id(int id)
        {
            Id = id;
        }

        public City_Id With(int? id = null)
        {
            return new City_Id(id ?? Id);
        }
    }

}