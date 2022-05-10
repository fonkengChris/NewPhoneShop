using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NewPhoneShop2.Data;
using NewPhoneShop2.Data.Static;
using NewPhoneShop2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPhoneShop2.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "iphone 13pro",
                            Category = Category.Phone,
                            BrandName = BrandName.Apple,
                            Properties = "none",
                            Price = 13.4,
                            ProfilePictureURL = "data:image/jpeg;base64,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"

                        }
                    }


                        );
                context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles configuration
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

                //Users Configuration
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@phoneshop.com";

                var adminUser = await userManager.FindByNameAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "@Pass4wd");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "customer@phoneshop.com";

                var appUser = await userManager.FindByNameAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "App User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    

                    await userManager.CreateAsync(newAppUser, "@Pass4wd");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Customer);
                    
                }
            }
        }
    }
}
