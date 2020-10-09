using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TourSearchDatabaseImplement.Models;
using TourSearchBusinessLogic.ViewModel;
using TourSearchDatabaseImplement.Implements;
using TourSearchDatabaseImplement;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TourSearchDatabaseImplement.Implements
{
    public class TourLogic : ITourLogic
    {
        public List<Tour> Tours { get; set; }
        HotelLogic hotel = new HotelLogic();
        TourOperatorLogic tourOperator = new TourOperatorLogic();
        DepartureLogic departure = new DepartureLogic();
        CountryLogic country = new CountryLogic();
        ResortLogic resort = new ResortLogic();
        MealLogic meal = new MealLogic();
        RoomLogic room = new RoomLogic();
        StarLogic star = new StarLogic();
        /* 
          public TourLogic()
         {
             Tours = LoadTours();
         }
        */
         private List<Tour> LoadTours()
         {
             Random rnd = new Random();
            hotel.Database();
             country.Database();
             resort.Database();
             star.Database();
             var list = new List<Tour>();
             var hotelList = hotel.LoadHotels();
             var tourOperatorList = tourOperator.LoadTourOperators();
             var departurelist = departure.LoadDepartures();
             var countryList = country.LoadCountries();
             var resortList = resort.LoadResorts();
             var mealList = meal.LoadMeals();
             var roomList = room.LoadRooms();

                 var context = new TourSearchDatabase();
                 int counterId = 0;
                 foreach (var elem in hotelList)
                 {
                 var hotelname = elem;
                 for (int i = 0; i < 15; i++)
                 {
                     DateTime date = DateTime.Now.AddDays(rnd.Next(0, 365));
                   list.Add(new Tour
                     {
                         Id = counterId + 1,
                         TourOperatorName = tourOperatorList[rnd.Next(0, tourOperatorList.Count)].TourOperatorName,
                         StartDate = date,
                         EndDate = date.AddDays(rnd.Next(5, 14)),
                         DepartureName = departurelist[rnd.Next(0, departurelist.Count)].DepartureName,
                         CountryName = context.Countries.FirstOrDefault(rec => rec.CountryId == context.Resorts.FirstOrDefault(recR => recR.ResortId == elem.ResortId).CountryId).CountryName,
                         ResortName = context.Resorts.FirstOrDefault(rec => rec.ResortId == elem.ResortId).ResortName,
                         HotelName = elem.HotelName,
                         StarName = context.Stars.FirstOrDefault(rec => rec.StarId == elem.StarId).StarName,
                         MealName = mealList[rnd.Next(0, mealList.Count)].MealName,
                         RoomName = roomList[rnd.Next(0, roomList.Count)].RoomName,
                         CountPlaces = rnd.Next(2, 4),
                         Cost = (decimal)Math.Round(10000 + rnd.NextDouble() * (30000 + 10000), 2)
                     });
                     counterId++;
                 }             
             }
             return list;
         }
     
        public void Database()
        {
            var tours = LoadTours();
            using (var context = new TourSearchDatabase())
            {
                foreach (var tour in tours)
                {
                    Tour element = context.Tours.FirstOrDefault(rec => rec.Id == tour.Id);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new Tour();
                        context.Tours.Add(element);
                    }
                    element.TourOperatorName = tour.TourOperatorName;
                    element.StartDate = tour.StartDate;
                    element.EndDate = tour.EndDate;
                    element.DepartureName = tour.DepartureName;
                    element.CountryName = tour.CountryName;
                    element.ResortName = tour.ResortName;
                    element.HotelName = tour.HotelName;
                    element.StarName = tour.StarName;
                    element.MealName = tour.MealName;
                    element.RoomName = tour.RoomName;
                    element.CountPlaces = tour.CountPlaces;
                    element.Cost = tour.Cost;
                    context.SaveChanges();
                }
            }
        }
       
        public List<TourViewModel> Read(TourBindingModel model, int from)
        {     
            using (var context = new TourSearchDatabase())              
            return context.Tours.Select (rec => new TourViewModel 

            {
                Id = rec.Id,
                TourOperatorName = rec.TourOperatorName,
                StartDate = rec.StartDate,
                EndDate = rec.EndDate,
                DepartureName = rec.DepartureName,
                CountryName = rec.CountryName,
                ResortName = rec.ResortName,
                HotelName = rec.HotelName,
                StarName = rec.StarName,
                MealName = rec.MealName,
                RoomName = rec.RoomName,
                CountPlaces = rec.CountPlaces,
                Cost = rec.Cost,
            })
            .ToList();
        }
    }
}
