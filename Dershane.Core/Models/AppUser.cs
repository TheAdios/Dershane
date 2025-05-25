using Microsoft.AspNetCore.Identity;

namespace W3CRM.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join("", FirstName, LastName);
    }
}
