using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.Interfaces;
using TourSearchBusinessLogic.ViewModel;
using TourSearchDatabaseImplement.Models;

namespace TourSearchDatabaseImplement.Implements
{
    public class HotelLogic : IHotelLogic
    {
        public readonly string HotelFileName = "D://TourData//Hotel.xml";
        public List<Hotel> Hotels { get; set; }
        public HotelLogic()
        {
            Hotels = LoadHotels();
        }
        public List<Hotel> LoadHotels()
        {
            var list = new List<Hotel>();
            if (File.Exists(HotelFileName))
            {
                XDocument xDocument = XDocument.Load(HotelFileName);
                var xElements = xDocument.Root.Elements("hotel").ToList();             
                foreach (var elem in xElements)
                {
                    list.Add(new Hotel
                    {
                        HotelId = Convert.ToInt32(elem.Attribute("id").Value),
                        HotelName = elem.Attribute("HotelName").Value,
                        ResortId = Convert.ToInt32(elem.Attribute("resortId").Value),
                        StarId = Convert.ToInt32(elem.Attribute("starId").Value),
                    });
                }
            }
            return list;
        }
        public void Database()
        {
            var Hotels = LoadHotels();
            using (var context = new TourSearchDatabase())
            {
                foreach (var Hotel in Hotels)
                {
                    Hotel element = context.Hotels.FirstOrDefault(rec => rec.HotelId == Hotel.HotelId);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new Hotel();
                        context.Hotels.Add(element);
                    }
                    element.HotelId = Hotel.HotelId;
                    element.HotelName = Hotel.HotelName;
                    element.ResortId = Hotel.ResortId;
                    element.StarId = Hotel.StarId;
                    context.SaveChanges();
                }
            }
        }
        public List<HotelViewModel> Read(HotelBindingModel model)
        {
            Database();
            return Hotels
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new HotelViewModel
            {
                Id = rec.Id,
                HotelId = rec.HotelId,
                HotelName = rec.HotelName,
                ResortId = rec.ResortId,
                StarId =rec.StarId,
            })
            .ToList();
        }
    }
}
  
 