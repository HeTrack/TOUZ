using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
    public interface IProfileLogic
    {
        List<ProfileViewModel> Read(ProfileBindingModel model);
        void CreateOrUpdate(ProfileBindingModel model);
    }
}
