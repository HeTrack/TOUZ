using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
   public interface ICountryLogic
    {
        List<CountryViewModel> Read(CountryBindingModel model);
        void Database();
    }
}
