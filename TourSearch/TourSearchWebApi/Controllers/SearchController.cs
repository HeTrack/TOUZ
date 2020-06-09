using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourSearchAggregator;
using TourSearchCommon.Model;
using TourSearchCommon.Services;
using TourSearchWebApi.Models;

namespace TourSearchWebApi.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        public SearchController(AggregatorService searchService)
        {
            this.searchService = searchService;
        }
        public readonly ISearchService searchService;

        [HttpPost("api/search")]
        public async Task<ActionResult<IEnumerable<Tour>>> Search(SearchRequest request, CancellationToken token = default)
        {
            var filter = TourCategory.StartCity(request.StartCity)
                & TourCategory.City(request.City)
                & TourCategory.StartDate(request.StartDate)
                & TourCategory.DaysRange(request.MinDays, request.MaxDays);

            return Ok(await searchService.Search(request.PeopleCount, filter, request.Order, token));
        }
    }
}