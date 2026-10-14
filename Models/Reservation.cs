namespace LibraryInventory.Models;

public class Reservation
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public int BookCopyId { get; set; }
    public BookCopy? BookCopy { get; set; }

    public DateTime ReservedAt { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }

    // Active, Cancelled, Completed
    public string Status { get; set; } = "Active";

    public DateTime? ReturnedAt { get; set; }
}