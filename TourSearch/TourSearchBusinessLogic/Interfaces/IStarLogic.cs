using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
    public interface IStarLogic
    {
        List<StarViewModel> Read(StarBindingModel model);
        void Database();
    }
}
