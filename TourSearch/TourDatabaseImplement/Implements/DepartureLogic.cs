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
   public class DepartureLogic  : IDepartureLogic
    {
    private readonly string DepartureFileName = "D://TourData//DepartureCities.xml";
    public List<Departure> Departures { get; set; }
    public DepartureLogic()
    {
      Departures = LoadDepartures();
    }
    public List<Departure> LoadDepartures()
    {
        var list = new List<Departure>();
        if (File.Exists(DepartureFileName))
        {
            XDocument xDocument = XDocument.Load(DepartureFileName);
            var xElements = xDocument.Root.Elements("departureCity").ToList();
            foreach (var elem in xElements)
            {
                list.Add(new Departure
                {
                    DepartureId = Convert.ToInt32(elem.Attribute("id").Value),
                    DepartureName = elem.Attribute("DepartureName").Value,
                    CountryId = Convert.ToInt32(elem.Attribute("countryId").Value)
                });
            }
        }
        return list;
    }
    public void Database()
    {
        var Departures = LoadDepartures();
        using (var context = new TourSearchDatabase())
        {
            foreach (var Departure in Departures)
            {
                Departure element = context.Departures.FirstOrDefault(rec => rec.DepartureId == Departure.DepartureId);
                if (element != null)
                {
                    break;
                }
                else
                {
                    element = new Departure();
                    context.Departures.Add(element);
                }
                element.DepartureId = Departure.DepartureId;
                element.DepartureName = Departure.DepartureName;
                element.CountryId = Departure.CountryId;

                context.SaveChanges();
            }
        }
    }
    public List<DepartureViewModel> Read(DepartureBindingModel model)
    {
        Database();
        return Departures
        .Where(rec => model == null || rec.Id == model.Id)
        .Select(rec => new DepartureViewModel
        {
            Id = rec.Id,
            DepartureId = rec.DepartureId,
            DepartureName = rec.DepartureName,
            CountryId = rec.CountryId,
        })
        .ToList();
    }
}
}
  
  