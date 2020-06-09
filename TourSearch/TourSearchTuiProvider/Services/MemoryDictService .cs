using System;
using System.Collections.Generic;
using System.Text;
using TourSearchCommon.Model;
using TourSearchCommon.Services;
using TourSearchTuiProvider.Storages;

namespace TourSearchTuiProvider.Services
{
    public class MemoryDictService : IDictService
    {
        public MemoryDictService(MemoryDictStorage storage)
        {
            this.Storage = storage;
        }
        public readonly MemoryDictStorage Storage;

        public IEnumerable<City> StartCities()
        {
            //TODO разделить в Storage-е города вылета и города тура
            return Storage.Cities;
        }

        public IEnumerable<Country> Countries()
        {
            return Storage.Countries;
        }

        public IEnumerable<City> Cities()
        {
            return Storage.Cities;
        }

        public IEnumerable<City> FlyCities()
        {
            return Storage.FlyCities;
        }

        public IEnumerable<Hotel> Hotels()
        {
            return Storage.Hotels;
        }

        public Hotel FindHotel(Guid id)
        {
            return Storage.HotelIndex.Find(id);
        }
    }

}