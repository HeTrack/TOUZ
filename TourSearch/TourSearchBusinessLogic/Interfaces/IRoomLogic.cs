using System;
using System.Collections.Generic;
using System.Text;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.ViewModel;

namespace TourSearchBusinessLogic.Interfaces
{
  public  interface IRoomLogic
    {
        List<RoomViewModel> Read(RoomBindingModel model);
        void Database();
    }
}
