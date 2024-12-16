using API.Data.feedData;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DbInitial
    {
        public static async Task Seed(StoreContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            };

            if (context.Categories.Any()) return;
            var categories = CategorySeedData.Categories;

            context.Categories.AddRange(categories);
            context.SaveChanges();

            if (context.Products.Any()) return;

            var products = ProductSeedData.GetProducts(categories);

            context.Products.AddRange(products);
            context.SaveChanges();

            if (context.Foods.Any()) return;
            var foods = FoodSeedData.Foods;
            context.Foods.AddRange(foods);
            context.SaveChanges();
        }
    }
}