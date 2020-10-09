using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.Interfaces;
using TourSearchDatabaseImplement.Models;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchDatabaseImplement.Implements
{
    public class ProfileLogic : IProfileLogic
    {
        public void CreateOrUpdate(ProfileBindingModel model)
        {
            using (var context = new TourSearchDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Profile elem = model.Id.HasValue ? null : new Profile();
                        if (model.Id.HasValue)
                        {
                            elem = context.Profiles.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (elem == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                            elem.ClientId = model.ClientId;
                            context.SaveChanges();
                        }
                        else
                        {
                            elem.ClientId = model.ClientId;
                            context.Profiles.Add(elem);
                            context.SaveChanges();

                            var countries = model.ProfileCountries
                               .GroupBy(rec => rec.CountryId)
                               .Select(rec => new
                               {
                                   CountryId = rec.Key
                               });

                            var tourOperators = model.ProfileTourOperators
                                .GroupBy(rec => rec.TourOperatorId)
                                .Select(rec => new
                                {
                                    TourOperatorId = rec.Key
                                });

                            var departures = model.ProfileDepartures
                                .GroupBy(rec => rec.DepartureId)
                                .Select(rec => new
                                {
                                    DepartureId = rec.Key
                                });

                            var meals = model.ProfileMeals
                                .GroupBy(rec => rec.MealId)
                                .Select(rec => new
                                {
                                    MealId = rec.Key
                                });

                            var stars = model.ProfileStars
                                .GroupBy(rec => rec.StarId)
                                .Select(rec => new
                                {
                                    StarId = rec.Key
                                });

                            foreach (var country in countries)
                            {
                                context.ProfileCountries.Add(new ProfileCountry
                                {
                                    ProfileId = elem.Id,
                                    CountryId = country.CountryId
                                });
                                context.SaveChanges();
                            }

                            foreach (var tourOperator in tourOperators)
                            {
                                context.ProfileTourOperators.Add(new ProfileTourOperator
                                {
                                    ProfileId = elem.Id,
                                    TourOperatorId = tourOperator.TourOperatorId
                                });
                                context.SaveChanges();
                            }

                            foreach (var departure in departures)
                            {
                                context.ProfileDepartures.Add(new ProfileDeparture
                                {
                                    ProfileId = elem.Id,
                                    DepartureId = departure.DepartureId
                                });
                            }

                            foreach (var meal in meals)
                            {
                                context.ProfileMeals.Add(new ProfileMeal
                                {
                                    ProfileId = elem.Id,
                                    MealId = meal.MealId
                                });
                            }

                            foreach (var star in stars)
                            {
                                context.ProfileStars.Add(new ProfileStar
                                {
                                    ProfileId = elem.Id,
                                    StarId = star.StarId
                                });
                            }

                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<ProfileViewModel> Read(ProfileBindingModel model)
        {
            using (var context = new TourSearchDatabase())
            {
                return context.Profiles.Where(rec => rec.Id == model.Id || (rec.ClientId == model.ClientId))
                .Select(rec => new ProfileViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ProfileCountries = GetCountries(rec),
                    ProfileTourOperators = GetTourOperators(rec),
                    ProfileDepartures = GetDepartures(rec),
                    ProfileMeals = GetMeals(rec),
                    ProfileStars = GetStars(rec),
                })
            .ToList();
            }
        }

        public static List<ProfileCountryViewModel> GetCountries(Profile profile)
        {
            using (var context = new TourSearchDatabase())
            {
                var ProfileCountries = context.ProfileCountries
                    .Where(rec => rec.ProfileId == profile.Id)
                    .Include(rec => rec.Country)
                    .Select(rec => new ProfileCountryViewModel
                    {
                        Id = rec.Id,
                        ProfileId = rec.ProfileId,
                        CountryId = rec.CountryId
                    }).ToList();
                foreach (var country in ProfileCountries)
                {
                    var countryData = context.Countries.Where(rec => rec.Id == country.CountryId).FirstOrDefault();
                    country.CountryName = countryData.CountryName;            
                }
                return ProfileCountries;
            }
        }

        public static List<ProfileTourOperatorViewModel> GetTourOperators(Profile profile)
        {
            using (var context = new TourSearchDatabase())
            {
                var ProfileTourOperators = context.ProfileTourOperators
                    .Where(rec => rec.ProfileId == profile.Id)
                    .Include(rec => rec.TourOperator)
                    .Select(rec => new ProfileTourOperatorViewModel
                    {
                        Id = rec.Id,
                        ProfileId = rec.ProfileId,
                        TourOperatorId = rec.TourOperatorId
                    }).ToList();
                foreach (var tourOperator in ProfileTourOperators)
                {
                    var tourOperatorData = context.TourOperators.Where(rec => rec.Id == tourOperator.TourOperatorId).FirstOrDefault();
                    tourOperator.TourOperatorName = tourOperatorData.TourOperatorName;
                }
                return ProfileTourOperators;
            }
        }

        public static List<ProfileDepartureViewModel> GetDepartures(Profile profile)
        {
            using (var context = new TourSearchDatabase())
            {
                var ProfileDepartures = context.ProfileDepartures
                    .Where(rec => rec.ProfileId == profile.Id)
                    .Include(rec => rec.Departure)
                    .Select(rec => new ProfileDepartureViewModel
                    {
                        Id = rec.Id,
                        ProfileId = rec.ProfileId,
                        DepartureId = rec.DepartureId
                    }).ToList();
                foreach (var departure in ProfileDepartures)
                {
                    var departureData = context.Departures.Where(rec => rec.Id == departure.DepartureId).FirstOrDefault();
                    departure.DepartureName = departureData.DepartureName;
                    departure.CountryId = departureData.CountryId;
                }
                return ProfileDepartures;
            }
        }

        public static List<ProfileMealViewModel> GetMeals(Profile profile)
        {
            using (var context = new TourSearchDatabase())
            {
                var ProfileMeals = context.ProfileMeals
                    .Where(rec => rec.ProfileId == profile.Id)
                    .Include(rec => rec.Meal)
                    .Select(rec => new ProfileMealViewModel
                    {
                        Id = rec.Id,
                        ProfileId = rec.ProfileId,
                        MealId = rec.MealId
                    }).ToList();
                foreach (var meal in ProfileMeals)
                {
                    var mealData = context.Meals.Where(rec => rec.Id == meal.MealId).FirstOrDefault();
                    meal.MealName = mealData.MealName;
                }
                return ProfileMeals;
            }
        }

        public static List<ProfileStarViewModel> GetStars(Profile profile)
        {
            using (var context = new TourSearchDatabase())
            {
                var ProfileStars = context.ProfileStars
                    .Where(rec => rec.ProfileId == profile.Id)
                    .Include(rec => rec.Star)
                    .Select(rec => new ProfileStarViewModel
                    {
                        Id = rec.Id,
                        ProfileId = rec.ProfileId,
                        StarId = rec.StarId
                    }).ToList();
                foreach (var star in ProfileStars)
                {
                    var starData = context.Stars.Where(rec => rec.Id == star.StarId).FirstOrDefault();
                    star.StarName = starData.StarName;
                }
                return ProfileStars;
            }
        }
    }
}
