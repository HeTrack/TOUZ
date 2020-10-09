using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
    public interface IDepartureLogic
    {
        List<DepartureViewModel> Read(DepartureBindingModel model);
        void Database();
    }
}
