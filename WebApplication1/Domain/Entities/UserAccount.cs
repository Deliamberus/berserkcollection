using Microsoft.AspNetCore.Identity;

namespace BerserkCollection.Domain.Entities
{
    public class UserAccount : IdentityUser
    {
        public string? City { get; set; }
        public List<UserCards> Cards { get; set; }
    }
}