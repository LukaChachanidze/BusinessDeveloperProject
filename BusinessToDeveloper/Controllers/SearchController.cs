using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Services.Search;
using BusinessToDeveloper.Services.Search.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessToDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet(nameof(SearchDevelopers))]
        public async Task<ActionResult<List<Developer>>> SearchDevelopers(DeveloperSearchCriteria criteria)
        {
            var results = await _searchService.SearchDevelopers(criteria);
            return Ok(results);
        }

        [HttpGet(nameof(SearchBusinesses))]
        public async Task<ActionResult<List<Business>>> SearchBusinesses(BusinessSearchCriteria criteria)
        {
            var results = await _searchService.SearchBusinesses(criteria);
            return Ok(results);
        }
    }
}
