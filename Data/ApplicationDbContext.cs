using LibraryInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet properties for the entities
    public DbSet<Book> Books { get; set; }
}