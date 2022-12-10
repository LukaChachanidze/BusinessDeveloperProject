using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Repositories.Repository;
using BusinessToDeveloper.Repositories.UOW;
using BusinessToDeveloper.Services.Search.Dto;

namespace BusinessToDeveloper.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Business> _businessRepository;
        private readonly IGenericRepository<Developer> _developerRepository;

        public SearchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _businessRepository = _unitOfWork.GetRepository<Business>();
            _developerRepository = _unitOfWork.GetRepository<Developer>();
        }
        public async Task<List<Developer>> SearchDevelopers(DeveloperSearchCriteria criteria)
        {
            var query = await _developerRepository.GetAllAsync();

            // Apply search criteria
            if (criteria.Location != null)
            {
                query = query.Where(d => d.Location == criteria.Location);
            }
            if (criteria.Skills != null && criteria.Skills.Any())
            {
                query = query.Where(d => criteria.Skills.All(skillId => d.Skills.Any(s => s.SkillId == skillId)));
            }
            if (criteria.Expertise != null && criteria.Expertise.Any())
            {
                query = query.Where(d => criteria.Expertise.All(expertiseId => d.Expertise.Any(e => e.ExpertiseId == expertiseId)));
            }

            // Order search results by relevance

            var results = query.OrderByDescending(d =>
                (criteria.Location == null || d.Location == criteria.Location ? 1 : 0) +
                (criteria.Skills == null || criteria.Skills.All(skillId => d.Skills.Any(s => s.SkillId == skillId)) ? 1 : 0) +
                (criteria.Expertise == null || criteria.Expertise.All(expertiseId => d.Expertise.Any(e => e.ExpertiseId == expertiseId)) ? 1 : 0)).ToList();

            return results;
        }

        public async Task<List<Business>> SearchBusinesses(BusinessSearchCriteria criteria)
        {
            var query = await _businessRepository.GetAllAsync();

            // Apply search criteria
            if (criteria.Location != null)
            {
                query = query.Where(b => b.Location == criteria.Location);
            }
            if (criteria.Skills != null && criteria.Skills.Any())
            {
                query = query.Where(b => criteria.Skills.All(skillId => b.Skills.Any(s => s.SkillId == skillId)));
            }
            if (criteria.Expertise != null && criteria.Expertise.Any())
            {
                query = query.Where(b => criteria.Expertise.All(expertiseId => b.Expertise.Any(e => e.ExpertiseId == expertiseId)));
            }

            // Order search results by relevance

            var results = query.OrderByDescending(b =>
                (criteria.Location == null || b.Location == criteria.Location ? 1 : 0) +
                (criteria.Skills == null || criteria.Skills.All(skillId => b.Skills.Any(s => s.SkillId == skillId)) ? 1 : 0) +
                (criteria.Expertise == null || criteria.Expertise.All(expertiseId => b.Expertise.Any(e => e.ExpertiseId == expertiseId)) ? 1 : 0)).ToList();
            
            return results;
        }
    }
}
