using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
  public  interface IResortLogic
    {
        List<ResortViewModel> Read(ResortBindingModel model);
        void Database();
    }
}
