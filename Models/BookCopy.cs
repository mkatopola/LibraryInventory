namespace LibraryInventory.Models;

public class BookCopy
{
    public List<Reservation> Reservations { get; set; } = new();
    public int Id { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; }

    public string Barcode { get; set; } = string.Empty;

    public string? Location { get; set; }          // e.g. "Shelf A-12"

    public string Condition { get; set; } = "Good"; // Good, Fair, Damaged

    public string Status { get; set; } = "Available"; 
    // Possible values: Available, CheckedOut, Reserved, Lost, Damaged, InRepair

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}