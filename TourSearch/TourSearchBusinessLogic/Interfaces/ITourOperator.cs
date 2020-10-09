using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
   public interface ITourOperator
    {
        List<TourOperatorViewModel> Read(TourOperatorBindingModel model);
        void Database();
    }
}
