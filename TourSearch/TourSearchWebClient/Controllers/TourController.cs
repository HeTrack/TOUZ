using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.Interfaces;
using TourSearchDatabaseImplement.Models;
using TourSearchWebClient.Models;

namespace TourSearchWebClient.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourLogic _tour;
        private readonly ICountryLogic _country;
        public TourController(ITourLogic tour , ICountryLogic country)
        {
            _tour = tour;
            _country = country;
        }
        public IActionResult Tour()
        {
            ViewBag.Tours = _tour.Read(null,0);
            return View();
        }
        public IActionResult CreateTours()
        {
            ViewBag.Countries = _country.Read(null);
            return View();
        }

       /* [HttpPost]
        public ActionResult CreateTours(CreateTours model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EducationCourses = _tour.Read(null,0);
                return View(model);
            }*/

            //var tours = new List<TourBindingModel>();

          /*  foreach (var course in model.EducationCourses)
            {
                if (course.Value == true)
                {
                    edCourses.Add(new EducationCourseBindingModel
                    {
                        CourseId = course.Key
                    });
                }
            }

            if (edCourses.Count == 0)
            {
                ViewBag.EducationCourses = courseLogic.Read(null);
                ModelState.AddModelError("", "Ни один курс не выбран");
                return View(model);
            }
            edLogic.CreateOrUpdate(new EducationBindingModel
            {
                ClientId = Program.Client.Id,
                EdCreate = DateTime.Now,
                Status = EducationStatus.Принят,
                EdCost = CalculateSum(edCourses),
                EducationCourses = edCourses
            });
            return RedirectToAction("Education");*/
        //}
    }
}