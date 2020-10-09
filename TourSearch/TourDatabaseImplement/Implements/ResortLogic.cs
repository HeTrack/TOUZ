using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TourSearchBusinessLogic.Interfaces;
using TourSearchDatabaseImplement.Models;
using TourSearchBusinessLogic.ViewModel;
using TourSearchBusinessLogic.BindingModels;

namespace TourSearchDatabaseImplement.Implements
{
   public class ResortLogic : IResortLogic
    {
        private readonly string  ResortFileName = "D://TourData//Resorts.xml";
    public List<Resort> Resorts { get; set; }
    public ResortLogic()
    {
            Resorts = LoadResorts();
    }
    public List<Resort> LoadResorts()
    {
        var list = new List<Resort>();
        if (File.Exists(ResortFileName))
        {
            XDocument xDocument = XDocument.Load(ResortFileName);
            var xElements = xDocument.Root.Elements("resort").ToList();
            foreach (var elem in xElements)
            {
                list.Add(new Resort
                {
                    ResortId = Convert.ToInt32(elem.Attribute("id").Value),
                    ResortName = elem.Attribute("ResortName").Value,
                    CountryId = Convert.ToInt32(elem.Attribute("countryId").Value)
                });
            }
        }
        return list;
    }
    public void Database()
    {
        var resorts = LoadResorts();
        using (var context = new TourSearchDatabase())
        {
            foreach (var resort in resorts)
            {
              Resort element = context.Resorts.FirstOrDefault(rec => rec.ResortId == resort.ResortId);
                if (element != null)
                {
                    break;
                }
                else
                {
                    element = new Resort();
                    context.Resorts.Add(element);
                }
                    element.ResortId = resort.ResortId;
                    element.ResortName = resort.ResortName;
                    element.CountryId = resort.CountryId;
                context.SaveChanges();
            }
        }
    }
    public List<ResortViewModel> Read(ResortBindingModel model)
    {
        Database();
        return Resorts
        .Where(rec => model == null || rec.Id == model.Id)
        .Select(rec => new ResortViewModel
        {
            Id = rec.Id,
            ResortId = rec.ResortId,
            ResortName = rec.ResortName,
            CountryId = rec.CountryId,
        })
        .ToList();
    }
}
}