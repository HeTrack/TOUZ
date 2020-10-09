using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
   public interface IHotelLogic
    {
        List<HotelViewModel> Read(HotelBindingModel model);
        void Database();
    }
}
