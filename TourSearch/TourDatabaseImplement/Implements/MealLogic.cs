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
    public class MealLogic : IMealLogic
    {
        private readonly string MealFileName = "D://TourData//Meals.xml";
        public List<Meal> Meals { get; set; }
        public MealLogic()
        {
            Meals = LoadMeals();
        }
        public List<Meal> LoadMeals()
        {
            var list = new List<Meal>();
            if (File.Exists(MealFileName))
            {
                XDocument xDocument = XDocument.Load(MealFileName);
                var xElements = xDocument.Root.Elements("meal").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Meal
                    {
                        MealId = Convert.ToInt32(elem.Attribute("id").Value),
                        MealName = elem.Attribute("MealName").Value,
                    });
                }
            }
            return list;
        }
        public void Database()
        {
            var Meals = LoadMeals();
            using (var context = new TourSearchDatabase())
            {
                foreach (var Meal in Meals)
                {
                    Meal element = context.Meals.FirstOrDefault(rec => rec.MealId == Meal.MealId);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new Meal();
                        context.Meals.Add(element);
                    }
                    element.MealId = Meal.MealId;
                    element.MealName = Meal.MealName;
                    context.SaveChanges();
                }
            }
        }
        public List<MealViewModel> Read(MealBindingModel model)
        {
            Database();
            return Meals
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new MealViewModel
            {
                Id = rec.Id,
                MealId = rec.MealId,
                MealName = rec.MealName,
            })
            .ToList();
        }
    }
}
  
 
    