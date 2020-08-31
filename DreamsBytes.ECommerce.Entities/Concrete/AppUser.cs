using Microsoft.AspNetCore.Identity;

namespace DreamsBytes.ECommerce.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
    }
}
