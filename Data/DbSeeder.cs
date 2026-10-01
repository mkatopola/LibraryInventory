using LibraryInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Only seed if the table is empty
        if (await context.Books.AnyAsync())
            return;

        var books = new List<Book>
        {
            new Book
            {
                Title = "Clean Code",
                Author = "Robert C. Martin",
                ISBN = "9780132350884",
                PublicationYear = 2008,
                Description = "A Handbook of Agile Software Craftsmanship"
            },
            new Book
            {
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                ISBN = "9780135957059",
                PublicationYear = 2019,
                Description = "Your Journey to Mastery"
            },
            new Book
            {
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                ISBN = "9780321125217",
                PublicationYear = 2003,
                Description = "Tackling Complexity in the Heart of Software"
            }
        };

        context.Books.AddRange(books);
        await context.SaveChangesAsync();
    }
}