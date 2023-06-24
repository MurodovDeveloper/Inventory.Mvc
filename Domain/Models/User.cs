using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public DateOnly? BirthDate { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
