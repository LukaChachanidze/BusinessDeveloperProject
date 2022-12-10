using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Services.Search.Dto;

namespace BusinessToDeveloper.Services.Search
{
    public interface ISearchService
    {
        Task<List<Developer>> SearchDevelopers(DeveloperSearchCriteria criteria);
        Task<List<Business>> SearchBusinesses(BusinessSearchCriteria criteria);
    }
}
