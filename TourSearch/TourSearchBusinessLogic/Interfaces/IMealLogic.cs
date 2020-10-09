using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
   public  interface IMealLogic
    {
        List<MealViewModel> Read(MealBindingModel model);
        void Database();
    }
}
