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
   public class StarLogic : IStarLogic
    {
        private readonly string StarFileName = "D://TourData//Stars.xml";
        public List<Star> Stars { get; set; }
        public StarLogic()
        {
            Stars = LoadStars();
        }
        private List<Star> LoadStars()
        {
            var list = new List<Star>();
            if (File.Exists(StarFileName))
            {
                XDocument xDocument = XDocument.Load(StarFileName);
                var xElements = xDocument.Root.Elements("star").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Star
                    {
                        StarId = Convert.ToInt32(elem.Attribute("id").Value),
                        StarName = elem.Attribute("StarName").Value,
                    });
                }
            }
            return list;
        }
        public void Database()
        {
            var stars = LoadStars();
            using (var context = new TourSearchDatabase())
            {
                foreach (var star in stars)
                {
                    Star element = context.Stars.FirstOrDefault(rec => rec.StarId == star.StarId);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new Star();
                        context.Stars.Add(element);
                    }
                    element.StarId = star.StarId;
                    element.StarName = star.StarName;
                    context.SaveChanges();
                }
            }
        }
        public List<StarViewModel> Read(StarBindingModel model)
        {
            Database();
            return Stars
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new StarViewModel
            {
                Id = rec.Id,
                StarId = rec.StarId,
                StarName = rec.StarName,
            })
            .ToList();
        }
    }
}

