using Microsoft.AspNetCore.Identity;

namespace BusinessToDeveloper.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBusiness { get; set; }
        public bool IsDeveloper { get; set; }
    }
}
