using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TourSearchCommon.Model;
using TourSearchCommon.Services;
using TourSearchCommon.Specification;
using TourSearchTuiProvider.Storages;
using TourSearchTuiProvider.Utilities;

namespace TourSearchTuiProvider.Services
{
    public class MemorySearchService : ISearchService
    {
        public MemorySearchService(MemoryTourStorage storage)
        {
            this.Storage = storage;
        }
        private readonly MemoryTourStorage Storage;

        public async Task<IEnumerable<Tour>> Search(int? peopleCount, FilterSpecification<Tour> filter, SearchOrder? order, CancellationToken cancellation = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(new Random().NextDouble(3, 17)), cancellation);

            return Storage.Tours
                .Where(filter & TourCategory.PeopleCount(peopleCount))
                .Select(tour => tour.With(fullPrice: tour.PriceByOnePeople * (peopleCount ?? 1)))
                .OrderBy(order)
                .Take(1000)
                .ToArray();
        }
    }

}