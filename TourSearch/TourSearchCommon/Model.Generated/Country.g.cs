using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchCommon.Model
{
    partial class Country
    {
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Country With(int? id = null, string name = null)
        {
            return new Country(id ?? Id, name ?? Name);
        }
    }

}