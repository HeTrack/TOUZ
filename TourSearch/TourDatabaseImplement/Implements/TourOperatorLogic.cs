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
   public class TourOperatorLogic : ITourOperator
    {
        private readonly string TourOperatorFileName = "D://TourData//touroperators.xml";
        public List<TourOperator> TourOperators { get; set; }
        public TourOperatorLogic()
        {
            TourOperators = LoadTourOperators();
        }
        public List<TourOperator> LoadTourOperators()
        {
            var list = new List<TourOperator>();
            if (File.Exists(TourOperatorFileName))
            {
                XDocument xDocument = XDocument.Load(TourOperatorFileName);
                var xElements = xDocument.Root.Elements("touroperator").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new TourOperator
                    {
                        TourOperatorId = Convert.ToInt32(elem.Attribute("id").Value),
                        TourOperatorName = elem.Attribute("TourOperatorName").Value,
                    });
                }
            }
            return list;
        }
        public void Database()
        {
            var tourOperators = LoadTourOperators();
            using (var context = new TourSearchDatabase())
            {
                foreach (var tourOperator in tourOperators)
                {
                    TourOperator element = context.TourOperators.FirstOrDefault(rec => rec.TourOperatorId == tourOperator.TourOperatorId);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new TourOperator();
                        context.TourOperators.Add(element);
                    }
                    element.TourOperatorId = tourOperator.TourOperatorId;
                    element.TourOperatorName = tourOperator.TourOperatorName;
                    context.SaveChanges();
                }
            }
        }
        public List<TourOperatorViewModel> Read(TourOperatorBindingModel model)
        {
            Database();
            return TourOperators
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new TourOperatorViewModel
            {
                Id = rec.Id,
                TourOperatorId = rec.TourOperatorId,
                TourOperatorName = rec.TourOperatorName,
            })
            .ToList();
        }
    }
}



