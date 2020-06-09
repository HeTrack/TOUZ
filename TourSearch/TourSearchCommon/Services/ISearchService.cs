using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TourSearchCommon.Model;
using TourSearchCommon.Specification;

namespace TourSearchCommon.Services
{
    public enum SearchOrder
    {
        byPrice,
        byPriceDesc,
        byName,
        byDate,
        byDateDesc
    }

    public interface ISearchService
    {
        Task<IEnumerable<Tour>> Search(int? peopleCount, FilterSpecification<Tour> filter, SearchOrder? order, CancellationToken token = default);
    }
}