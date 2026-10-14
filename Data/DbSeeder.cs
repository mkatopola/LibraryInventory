using LibraryInventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // 1. Seed Roles
        string[] roles = { "Admin", "Student" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // 2. Seed Categories
        if (!await context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category { Name = "Software Engineering", Description = "Books about writing better software" },
                new Category { Name = "Architecture", Description = "Software architecture and design" },
                new Category { Name = "Programming", Description = "General programming books" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }

        // 3. Seed Books
        if (!await context.Books.AnyAsync())
        {
            var softwareEng = await context.Categories.FirstAsync(c => c.Name == "Software Engineering");
            var architecture = await context.Categories.FirstAsync(c => c.Name == "Architecture");

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "9780132350884",
                    PublicationYear = 2008,
                    Description = "A Handbook of Agile Software Craftsmanship",
                    CategoryId = softwareEng.Id
                },
                new Book
                {
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt, David Thomas",
                    ISBN = "9780135957059",
                    PublicationYear = 2019,
                    Description = "Your Journey to Mastery",
                    CategoryId = softwareEng.Id
                },
                new Book
                {
                    Title = "Domain-Driven Design",
                    Author = "Eric Evans",
                    ISBN = "9780321125217",
                    PublicationYear = 2003,
                    Description = "Tackling Complexity in the Heart of Software",
                    CategoryId = architecture.Id
                }
            };

            context.Books.AddRange(books);
            await context.SaveChangesAsync();
        }

        // 4. Create a default Admin user (optional but useful)
        var adminEmail = "admin@library.local";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FullName = "System Administrator",
                IsActive = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}