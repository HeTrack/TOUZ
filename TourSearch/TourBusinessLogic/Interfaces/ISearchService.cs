using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TourBusinessLogic.BusinessLogic;
using TourBusinessLogic.Enums;
using TourBusinessLogic.ViewModel;

namespace TourBusinessLogic.Interfaces
{  
    public interface ISearchService
        {
            Task<IEnumerable<Tour>> Search(int? peopleCount, FilterLogic<Tour> filter, SearchOrder? order, CancellationToken token = default);
        }
    }