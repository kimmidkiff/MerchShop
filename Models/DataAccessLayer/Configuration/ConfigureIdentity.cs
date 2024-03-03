using Microsoft.AspNetCore.Identity;

namespace MerchShop.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<MerchShopUser>>();

            string roleName = "StandardUser";
            string password = "MyPassword5!";
            string username = "jamie.brown";

            if (await roleManager.FindByIdAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            if (await userManager.FindByIdAsync(username) == null)
            {
                MerchShopUser user = new MerchShopUser { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }

        }
    }
}
