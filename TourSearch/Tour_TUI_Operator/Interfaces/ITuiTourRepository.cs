using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourBusinessLogic.ViewModel;

namespace Tour_TUI_Operator.Interfaces
{
    public interface ITuiTourRepository : IRepository
    {
        Task<List<Tour>> Search(Specification<Tour> specification);
    }
}