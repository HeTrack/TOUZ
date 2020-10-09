using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
   public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
