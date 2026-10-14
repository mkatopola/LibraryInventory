using Microsoft.AspNetCore.Identity;

namespace LibraryInventory.Models;

public class ApplicationUser : IdentityUser
{
    public string? StudentId { get; set; }

    public string? FullName { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}