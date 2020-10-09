using System;
using System.Collections.Generic;
using System.Text;
using TourSearchDatabaseImplement.Models;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.Interfaces;
using TourSearchBusinessLogic.ViewModel;
using System.Linq;

namespace TourSearchDatabaseImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            /*HotelLogic hotel = new HotelLogic();
            TourOperatorLogic tourOperator = new TourOperatorLogic();
            DepartureLogic departure = new DepartureLogic();
            CountryLogic country = new CountryLogic();
            ResortLogic resort = new ResortLogic();
            MealLogic meal = new MealLogic();
            RoomLogic room = new RoomLogic();
            StarLogic star = new StarLogic();           
            country.Database();
            hotel.Database();
            resort.Database();
            star.Database();
            departure.Database();
            tourOperator.Database();
            meal.Database();
            room.Database();*/
            using (var context = new TourSearchDatabase())
            {
                Client elem = model.Id.HasValue ? null : new Client();
                if (model.Id.HasValue)
                {
                    elem = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (elem == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    elem = new Client();
                    context.Clients.Add(elem);
                }
                elem.Login = model.Login;
                elem.ClientFIO = model.ClientFIO;
                elem.Email = model.Email;
                elem.Phone = model.Phone;
                elem.DataRegistration = model.DateRegistration;
                elem.Password = model.Password;
                context.SaveChanges();
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using (var context = new TourSearchDatabase())
            {
                Client elem = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);

                if (elem != null)
                {
                    context.Clients.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
           
            using (var context = new TourSearchDatabase())
            {
                return context.Clients
                 .Where(rec => model == null
                   || rec.Id == model.Id
                 || (rec.Login == model.Login || rec.Email == model.Email)
                        && (model.Password == null || rec.Password == model.Password))
               .Select(rec => new ClientViewModel
               {
                   Id = rec.Id,
                   Login = rec.Login,
                   ClientFIO = rec.ClientFIO,
                   Email = rec.Email,
                   Password = rec.Password,
                   Phone = rec.Phone
               })
                .ToList();
            }
        }
    }
}