using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_053503_Rusakovich.Data;
using System.Linq;

namespace Web_053503_Rusakovich.Entities
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "12345678910";
            string userEmail = "user@gmail.com";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new() { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                ApplicationUser user = new() { Email = userEmail, UserName = userEmail };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }

            if (!dbContext.Types.Any())
            {
                dbContext.Types.AddRange(
                    new List<ProductType>()
                    {
                        new ProductType { Name = "Фрукты" },
                        new ProductType { Name = "Овощи" },
                        new ProductType { Name = "Колбасы" },
                    }
                    );
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(
                new List<Product>
                {
                    new Product
                    {
                        TypeId = 1,
                        Name = "банан",
                        Description = "продолговатый и желтый",
                        Price = 5,
                        ImageName = "banana.jpg"
                    },
                    new Product
                    {
                        TypeId = 1,
                        Name = "арбуз",
                        Description = "зеленый в полосочку, круглый, не то ягода, не то фрукт",
                        Price = 15,
                        ImageName = "watermelon.jpg"
                    },
                    new Product
                    {
                        TypeId = 2,
                        Name = "помидор",
                        Description = "красная ягода, но овощ",
                        Price = 7,
                        ImageName = "tomato.jpg"
                    },
                    new Product
                    {
                        TypeId = 2,
                        Name = "огурец",
                        Description = "продолговатый и зеленый",
                        Price = 5,
                        ImageName = "cucumber.jpg"
                    },
                    new Product
                    {
                        TypeId = 3,
                        Name = "cabanos",
                        Description = "острые",
                        Price = 6,
                        ImageName = "cabanos.jpg"
                    },
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
