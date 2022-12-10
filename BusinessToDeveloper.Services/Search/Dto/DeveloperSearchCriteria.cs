using BusinessToDeveloper.Core.Entities;

namespace BusinessToDeveloper.Services.Search.Dto
{
    public class DeveloperSearchCriteria
    {
        public string Location { get; set; }
        public List<int> Skills { get; set; }
        public List<int> Expertise { get; set; }
    }
}
