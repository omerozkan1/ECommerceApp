using DreamsBytes.ECommerce.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DreamsBytes.ECommerce.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });

                var memberRole = await roleManager.FindByNameAsync("Member");

                if (memberRole == null)
                {
                    await roleManager.CreateAsync(new AppRole { Name = "Member" });
                }

                var adminUser = await userManager.FindByNameAsync("omer");

                if (adminUser == null)
                {
                    AppUser user = new AppUser
                    {
                        Name = "Ömer",
                        SurName = "Özkan",
                        UserName = "omerozkan",
                        Email = "omer@gmail.com"
                    };
                    await userManager.CreateAsync(user, "1");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
