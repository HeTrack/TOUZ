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
    public class CountryLogic : ICountryLogic
    {
        private readonly string CountryFileName = "D://TourData//Countries.xml";
        public List<Country> Countries { get; set; }
        public CountryLogic()
        {
            Countries = LoadCountries();
        }
        public List<Country> LoadCountries()
        {
            var list = new List<Country>();
            if (File.Exists(CountryFileName))
            {
                XDocument xDocument = XDocument.Load(CountryFileName);
                var xElements = xDocument.Root.Elements("Country").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Country
                    {
                        CountryId = Convert.ToInt32(elem.Attribute("id").Value),
                        CountryName = elem.Attribute("CountryName").Value,
                    });
                }
            }
            return list;
        }
        public void Database()
        {
            var Countries = LoadCountries();
            using (var context = new TourSearchDatabase())
            {
                foreach (var Country in Countries)
                {
                    Country element = context.Countries.FirstOrDefault(rec => rec.CountryId == Country.CountryId);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new Country();
                        context.Countries.Add(element);
                    }
                    element.CountryId = Country.CountryId;
                    element.CountryName = Country.CountryName;
                    context.SaveChanges();
                }
            }
        }
        public List<CountryViewModel> Read(CountryBindingModel model)
        {
            Database();
            return Countries
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new CountryViewModel
            {
                Id = rec.Id,
                CountryId = rec.CountryId,
                CountryName = rec.CountryName,
            })
            .ToList();
        }
    }
}
  