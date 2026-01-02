using Microsoft.AspNetCore.Identity;

namespace FirstApplicationClass.Service
{
    public class SeedData
    {

        public static async Task SeedDataDefault(UserManager<IdentityUser> user, RoleManager<IdentityRole> rolemanager)
        {
            string[] role = { "Admin", "User" };
            foreach(var rolee in role)
            {

            if(!await rolemanager.RoleExistsAsync(rolee))
                {
                    await rolemanager.CreateAsync(new IdentityRole(rolee));
                }
                var users = await user.FindByEmailAsync("admin@gmail.com");
                if (users == null)
                {
                    users = new IdentityUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com"

                    };
                    
                 var result= await  user.CreateAsync(users,"admin123");
                    if (result.Succeeded)
                    {
                        if(!await user.IsInRoleAsync(users, "Admin"))
                        {
                            await user.AddToRoleAsync(users, "Admin");
                        }
                    }
                }
                
            }
        }
    }
}
