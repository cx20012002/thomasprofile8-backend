using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class User : IdentityUser
    {
        public string ProviderId { get; set; }
        public string Provider { get; set; }
        public string ImageUrl { get; set; }
    }
}