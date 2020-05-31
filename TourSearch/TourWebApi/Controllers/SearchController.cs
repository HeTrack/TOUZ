using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TourWebApi.Controllers
{
    [Route("api/[controller]")]
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
            var filter = StartCity(request.StartCity)
                & City(request.City)
                & StartDate(request.StartDate)
                & DaysRange(request.MinDays, request.MaxDays);

            return Ok(await searchService.Search(request.PeopleCount, filter, request.Order, token));
        }
    }
}