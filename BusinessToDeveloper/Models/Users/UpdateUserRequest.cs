using System.ComponentModel.DataAnnotations;

namespace BusinessToDeveloper.Models.Users
{
    public class UpdateUserRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public  bool IsDeveloer { get; set; }
        public  bool IsBusiness { get; set; }

    }
}
